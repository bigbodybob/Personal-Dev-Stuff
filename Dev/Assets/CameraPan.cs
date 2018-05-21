using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float timer=30f;
	public float standTime=30f;
	// Update is called once per frame
	void Update () {
		if (GameControl.control.wordStarted) {
			transform.Translate (speed * Time.deltaTime, 0f, 0f);
			timer -= .05f;
			if (timer <= 0) {
				timer = standTime;
				if (speed < 30) {
					speed += .5f;
				}
			}
		}
}
}
