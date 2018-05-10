using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using TMPro;
public class Leaderboard : MonoBehaviour {
	public int entryCount;
	private List<EntryDisplay> displayValues= new List<EntryDisplay>();
	public GameObject leaderboardDisplay;
	public CanvasGroup text;
	public CanvasGroup connectToWifi;
	public GameObject entryPrefab;
	public List<LeaderboardEntry> allEntries = new List<LeaderboardEntry> ();
	// Use this for initialization
	void Awake () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl ("https://fblagame-3c891.firebaseio.com/");

		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

		StartCoroutine (checkInternetConnection ());
	}
	IEnumerator checkInternetConnection(){
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
			connectToWifi.alpha=1;
		} else {
			connectToWifi.alpha = 0;
		}
	} 

	void Start()
	{
		for (int x = 0; x < 5; x++) {
			GameObject entry= Instantiate (entryPrefab,new Vector3(0,0),Quaternion.identity, leaderboardDisplay.transform);
			EntryDisplay entryScript = entry.GetComponent<EntryDisplay> ();
			entryScript.rank.text = "?";
			entryScript.nameText.text="???";
			entryScript.rating.text = "???";
			displayValues.Add (entryScript);

		}
		//updateLeaderboardCount();
		FirebaseDatabase.DefaultInstance
			.GetReference("Leaderboard").Child("Scores")
			.ValueChanged += HandleValueChanged;
	}

	 void updateLeaderboardCount()
	{
		
		FirebaseDatabase.DefaultInstance.GetReference("Leaderboard").Child("entryCount").GetValueAsync().ContinueWith(task=> {
			if(task.IsFaulted){
				Debug.Log("Error");
			}
			else if(task.IsCompleted){

				DataSnapshot snapshot= task.Result;
				updateLeaderboardEntries(int.Parse(snapshot.Value.ToString()));
			}

			});
	// Update is called once per frame

}

	void updateLeaderboardEntries(int entryCount)
	{
		for (int x = 0; x < entryCount; x++) {
			FirebaseDatabase.DefaultInstance.GetReference ("Leaderboard").Child ("Scores").Child(x.ToString()).GetValueAsync ().ContinueWith (task => {
				
				if(task.IsFaulted)
				{
					Debug.Log("Error");

				}
				else if(task.IsCompleted)
				{
					DataSnapshot snapshot= task.Result;
					string JSONsnapshot= snapshot.GetRawJsonValue();
					LeaderboardEntry entry = JsonUtility.FromJson<LeaderboardEntry>(JSONsnapshot);
					allEntries.Add(entry);	

					LeaderboardEntry temp;
					for(int i=1; i<allEntries.Count;i++)
					{
						for(int j=i; j>0; j--)
						{
							if(allEntries[j].getRating()>allEntries[j-1].getRating())
							{
								temp=allEntries[j-1];
								allEntries[j-1]=allEntries[j];
								allEntries[j]=temp;
							}
						}
					}
					updateBoardDisplay();
				}
			}
			);

		}

	}
	void updateBoardDisplay()
	{
		CreatedGame topGame=new CreatedGame("NULL",-1);
		foreach (CreatedGame x in GameControl.control.allGames) {
			if (x.name == GameControl.control.topGameName) {
				topGame = x;
			}
		}

			for (int i = 0; i < allEntries.Count; i++) {
			if (allEntries [i].name == GameControl.control.topGameIdentifier) {
				FirebaseDatabase.DefaultInstance.GetReference ("Leaderboard").Child ("Scores").Child (i.ToString ()).Child ("rating").SetValueAsync (topGame.rating);

				}
			}
		
		for (int x = 1; x < allEntries.Count; x++) {
			allEntries [0].setRank(1);
			if (allEntries [x-1].rating == allEntries [x].rating) {
				allEntries [x].setRank (allEntries [x-1].getRank ());
			}
			else{ 
				allEntries[x].setRank((allEntries [x-1].getRank ()+1));
					}
		}
		for(int x=0; x<allEntries.Count;x++) {
			if (allEntries [x].name == GameControl.control.topGameIdentifier) {
				if (x < 5 && displayValues.Count < 6) {

					displayValues [x].rank.text = allEntries[x].getRank().ToString ();
					displayValues [x].rank.color = Color.yellow;
					displayValues [x].nameText.text = allEntries [x].getName ();
					displayValues [x].nameText.color = Color.yellow;
					displayValues [x].rating.text = allEntries [x].getRating ().ToString ();
					displayValues [x].rating.color = Color.yellow;
				} else if (displayValues.Count < 6) {

					GameObject entry = Instantiate (entryPrefab, new Vector3 (0, 0), Quaternion.identity, leaderboardDisplay.transform);
					EntryDisplay entryScript = entry.GetComponent<EntryDisplay> ();
					entryScript.rank.text =allEntries[x].getRank().ToString ();
					entryScript.nameText.text = allEntries [x].name;
				
					entryScript.rating.text = allEntries [x].getRating ().ToString ();
					displayValues.Add (entryScript);
				
					displayValues [displayValues.Count - 1].rank.color = Color.yellow;
					displayValues [displayValues.Count - 1].nameText.color = Color.yellow;
					displayValues [displayValues.Count - 1].rating.color = Color.yellow;
				} else {
					displayValues[displayValues.Count - 1].rank.text =allEntries[x].getRank().ToString ();
					displayValues[displayValues.Count - 1].nameText.text = allEntries [x].name;
					displayValues [displayValues.Count - 1].rating.text = allEntries [x].getRating ().ToString ();

				}
			} 
		}
		for(int x=0; x<5 && x<allEntries.Count; x++)			{
			displayValues[x].rank.text = allEntries[x].getRank().ToString();
			displayValues[x].nameText.text=allEntries[x].getName();
			displayValues[x].rating.text =allEntries[x].getRating().ToString();

			}
		text.alpha = 0;

	}
	void HandleValueChanged(object senders, ValueChangedEventArgs args)
	{allEntries.RemoveRange (0, allEntries.Count);
		text.alpha = 1;
		updateLeaderboardCount ();

	}
}