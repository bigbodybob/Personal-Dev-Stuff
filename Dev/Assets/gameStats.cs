using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStats : MonoBehaviour {
	public int bugs;
	public List<wordCount> finalWC;
	public static int gameScore=0;
	// Use this for initialization
	void Start () {
		
	}
	//when someone types a word
	public void gameComplete()
	{
		GameControl.allGames.Add (this);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
