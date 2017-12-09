using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public static  GameControl control;
	public int health;
	public int exp;
	// Use this for initialization
	void Start () {
		if (control == null)
			DontDestroyOnLoad (gameObject);
		else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "health" + health);
	}
}
