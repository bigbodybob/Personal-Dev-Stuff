using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class SubmitGameButton : MonoBehaviour {
	public TextMeshProUGUI text;
	public bool submitted =false;
	public GameObject panel;	// Use this for initialization
	void Start () {
		if (!GameControl.control.canCompete) {
			text.text="Sorry, you can't compete again yet. If you haven't already, go to your home to view your last competition results.";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!submitted&& GameControl.control.allGames.Count > 0 && Input.GetKeyDown (KeyCode.Return) &&GameControl.control.canCompete) {
			text.text = "Game Submitted! You can compete again 15 minutes after going home and viewing your results. Press 'B' to return";
			GameControl.control.rating=GameControl.control.allGames [GameControl.control.currentGameSelectionIndex].rating;
			GameControl.control.isCompeting = true;
			GameControl.control.canCompete=false;
			submitted = true;
		}
		else if(Input.GetKeyDown(KeyCode.B))
		{
			panel.GetComponent<FadeControl> ().levelChange ("fblabuilding", panel);	
		}
	}
}
