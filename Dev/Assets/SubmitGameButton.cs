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
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!submitted&& GameControl.control.allGames.Count > 0 && Input.GetKeyDown (KeyCode.Return)) {
			text.text = "Game Submitted! Results will be posted in 30 minutes. Press 'B' to return";
			GameControl.control.rating=GameControl.control.allGames [GameControl.control.currentGameSelectionIndex].rating;
			GameControl.control.isCompeting = true;
			GameControl.control.resultReleaseDate=DateTime.Now.AddMinutes(1);
			submitted = true;
		}
		else if(Input.GetKeyDown(KeyCode.B))
		{
			panel.GetComponent<FadeControl> ().levelChange ("fblabuilding", panel);	
		}
	}
}
