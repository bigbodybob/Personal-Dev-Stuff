using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {
	public GameObject panel;
	public string placeToGo;
	void OnTriggerEnter2D()
	{
		panel.GetComponent<FadeControl>().levelChange(placeToGo,panel);

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
