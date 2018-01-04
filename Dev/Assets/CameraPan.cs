using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.Translate (3f*Time.deltaTime, 0f,0f);
	}
}
