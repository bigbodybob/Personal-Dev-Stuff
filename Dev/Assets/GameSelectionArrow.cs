using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionArrow : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.control.isPCOpen) {
			
			if (Input.GetKeyDown (KeyCode.UpArrow) && GameControl.control.currentGameSelectionIndex!=GameControl.control.allGames.Count) {
				GameControl.control.currentGameSelectionIndex++;
				transform.position = new Vector3 (transform.position.x, GameControl.control.selectedGame.transform.position.y);

			}
			if (Input.GetKeyDown (KeyCode.DownArrow)&& GameControl.control.currentGameSelectionIndex!=0) {
				GameControl.control.currentGameSelectionIndex--;			transform.position = new Vector3 (transform.position.x, GameControl.control.selectedGame.transform.position.y);


			}
		}
	}
}
