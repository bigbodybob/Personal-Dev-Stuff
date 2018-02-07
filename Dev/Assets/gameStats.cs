using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameStats : MonoBehaviour {
	public int bugs;
	public string name="";
	bool isNameUsed=false;

	public GameObject nameGamePanel;
	public GameObject fadePanel;
	public Animator nameGamePanelAnimator;
	public List<wordCount> finalWC;
	public GameObject invalidName;
	public static int gameScore=0;
	// Use this for initialization
	void Awake() {
		nameGamePanelAnimator = nameGamePanel.GetComponent<Animator> ();
	}
	//when someone types a word
	public void gameComplete()
	{
		GameControl.control.isGameOver = true;
		nameGamePanelAnimator.SetBool ("isZoomedIn", true);
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void addToGameList()
	{
		Debug.Log (isNameUsed);

		foreach (string n in GameControl.control.allGamesNames) {
		
			if (name.Equals (n)) {
				isNameUsed = true;
			} else {
				isNameUsed = false;
			}
		}
		Debug.Log (isNameUsed);
		if (name != "" && !isNameUsed) {
			
			CreatedGame game = new CreatedGame (name, bugs, finalWC, gameScore);
			GameControl.control.allGames.Add (game);
			GameControl.control.allGamesNames.Add (name);
			gameScore = 0;
			GameControl.control.isGameOver = false;
			isNameUsed = false;
			GameControl.control.changeScene (fadePanel);
		} else {
			TextMeshProUGUI[] textArray =nameGamePanel.GetComponentsInChildren<TextMeshProUGUI>();
			foreach(TextMeshProUGUI text in textArray)
			{
				if (text.text =="Name your Game:") {
					text.color = Color.red;
					text.text="Invalid Name";
				}
			}
		}

	}
	public void gameName(string name)

	{
		this.name = name;
	}
}
