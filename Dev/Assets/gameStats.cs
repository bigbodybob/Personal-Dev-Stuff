using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStats : MonoBehaviour {
	public int bugs;
	public string name="";
	bool isNameUsed=false;

	public GameObject nameGamePanel;
	public GameObject fadePanel;
	public Animator nameGamePanelAnimator;
	public List<wordCount> finalWC;
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
		foreach (string n in GameControl.control.allGamesNames) {
		
			if (name.Equals(n)) {
				isNameUsed=true;
			}
		}
		if (name != ""&& !isNameUsed) {
			
			CreatedGame game = new CreatedGame (name, bugs, finalWC, gameScore);
			GameControl.control.allGames.Add (game);
			GameControl.control.allGamesNames.Add (name);
			gameScore = 0;
			GameControl.control.changeScene (fadePanel);
		}


	}
	public void gameName(string name)

	{
		this.name = name;
	}
}
