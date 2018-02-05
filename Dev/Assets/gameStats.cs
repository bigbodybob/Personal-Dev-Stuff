using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStats : MonoBehaviour {
	public int bugs;
	public string name;
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
		GameControl.control.allGames.Add (this);
		GameControl.control.changeScene ( fadePanel);

	}
	public void gameName(string name)

	{
		this.name = name;
	}
}
