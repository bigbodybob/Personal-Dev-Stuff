﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionArrow : MonoBehaviour {
	public GameObject layout;
	public GameObject gameActionBar;
	public float maxY;
	public float minY=0;
	void Start () {
		maxY =- gameActionBar.transform.localPosition.y;	

	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.control.isPCOpen && GameControl.control.isClearBugsClicked) {

			if (Input.GetKeyDown (KeyCode.DownArrow) && GameControl.control.allGames.Count>0&& GameControl.control.currentGameSelectionIndex!=GameControl.control.allGames.Count-1) {
				GameControl.control.currentGameSelectionIndex++;
				if (-transform.localPosition.y > maxY) {
					Vector3 newPos = layout.transform.localPosition;
					newPos.y += GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
					layout.transform.localPosition = newPos;
					maxY += GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
				}
				//transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);

				}
			if (Input.GetKeyDown (KeyCode.UpArrow)&&  GameControl.control.allGames.Count>0&& GameControl.control.currentGameSelectionIndex!=0) {
				GameControl.control.currentGameSelectionIndex--;			transform.position = new Vector3 (transform.position.x, GameControl.control.selectedGame.transform.position.y);
				//transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);
				if (-transform.localPosition.y < maxY) {
					Vector3 newPos = layout.transform.localPosition;
					newPos.y -= GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
					layout.transform.localPosition = newPos;
					maxY -= GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
				}
			//	if (!screenRect.Contains (gameObject))
			}
			if(GameControl.control.selectedGame!=null)
			transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);

		}
	}
}
