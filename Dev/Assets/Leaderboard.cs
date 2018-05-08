using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
public class Leaderboard : MonoBehaviour {
	public int entryCount;
	private List<EntryDisplay> displayValues= new List<EntryDisplay>();
	public GameObject leaderboardDisplay;
	public GameObject entryPrefab;
	public List<LeaderboardEntry> allEntries = new List<LeaderboardEntry> ();
	// Use this for initialization
	void Awake () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl ("https://fblagame-3c891.firebaseio.com/");
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

	}
	void Start()
	{
		for (int x = 0; x < 3; x++) {
			GameObject entry= Instantiate (entryPrefab,new Vector3(0,0),Quaternion.identity, leaderboardDisplay.transform);
			EntryDisplay entryScript = entry.GetComponent<EntryDisplay> ();
			entryScript.rank.text = (x+1).ToString();
			entryScript.nameText.text="???";
			entryScript.rating.text = "???";
			displayValues.Add (entryScript);

		}
		updateLeaderboardCount();

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
		Debug.Log (entryCount);
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
		for(int x=0; x<3 && x<allEntries.Count; x++)			{
			displayValues[x].rank.text = (x+1).ToString();
			displayValues[x].nameText.text=allEntries[x].getName();
			displayValues[x].rating.text =allEntries[x].getRating().ToString();
			Debug.Log (allEntries[x].getName());
			}
	}
		
}