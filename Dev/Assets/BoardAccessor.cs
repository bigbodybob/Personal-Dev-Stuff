using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAccessor : MonoBehaviour {
	public CanvasGroup text;
	public bool inRange;
	public GameObject panel;
	// Use this for initialization
	void OnTriggerEnter2D()
	{
		text.alpha= 1;
		inRange = true;
	}
	void OnTriggerExit2D()
	{
		text.alpha = 0;
		inRange = false;
	}

	void Update()
	{
		if(Input.GetKeyDown(GameControl.control.eInput) &&inRange)
			{
			//GameControl.control.latestCharPositionIndoors;
			panel.GetComponent<FadeControl> ().levelChange ("leaderboard", panel);
			}
	}
}
