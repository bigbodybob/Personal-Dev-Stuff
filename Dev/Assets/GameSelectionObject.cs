using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionObject : MonoBehaviour {
	public int index;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (index == GameControl.control.currentGameSelectionIndex) {
			GameControl.control.selectedGame =gameObject;
		}
	}
}
