using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBugs : MonoBehaviour {
	public int index;
	public GameObject gameSelectionArrow;
	public GameObject selectGamePrompt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.control.currentGameButtonSelectionIndex == 0) {
			if(GameControl.control.selectedButton!=gameObject)
			GameControl.control.selectedButton = gameObject;
			if (Input.GetKeyDown (KeyCode.Return)) {
				gameSelectionArrow.GetComponent<CanvasGroup> ().alpha = 1;
				selectGamePrompt.GetComponent<CanvasGroup> ().alpha = 1;
				GameControl.control.isClearBugsClicked = true;

			}
			if (Input.GetKeyDown(KeyCode.C) && GameControl.control.isClearBugsClicked) {
				gameSelectionArrow.GetComponent<CanvasGroup> ().alpha = 0;
				selectGamePrompt.GetComponent<CanvasGroup> ().alpha = 0;
				GameControl.control.isClearBugsClicked = false;
			}
		}
	}
}
