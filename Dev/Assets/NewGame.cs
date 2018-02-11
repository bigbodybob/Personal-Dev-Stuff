using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGame : MonoBehaviour {
	public GameObject panel;
	// Use this for initialization
	public 	void buttonClicked(){
		GameControl.control.latestCharPositionInScene = transform.position;
		GameControl.control.latestScene = SceneManager.GetActiveScene().name;
		panel.GetComponent<FadeControl> ().levelChange ("programming", panel);
	}
	 void Update()
	{
		if (GameControl.control.currentGameButtonSelectionIndex == 1) {
			if(GameControl.control.selectedButton!=gameObject)
			GameControl.control.selectedButton = gameObject;
			if (Input.GetKeyDown (KeyCode.Return)) {
				buttonClicked ();
			}
		}
	}
}
