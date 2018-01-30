using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {
	public GameObject panel;
	public string placeToGo;
	public int whichDoorId;
	void OnTriggerEnter2D()
	{
		GameControl.control.currentCharPosition = GameControl.control.charPositions [whichDoorId];
		panel.GetComponent<FadeControl>().levelChange(placeToGo,panel);

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
