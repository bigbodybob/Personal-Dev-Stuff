using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManager : MonoBehaviour {

	public int numLives = 3;
	public GameObject canvas;
	public GameObject heartPrefab;
	public GameObject[] hearts;
	private float spacing=0;
	void Start() {
		hearts = new GameObject[numLives];
		for (int i = 0; i < numLives; i++) {
			//GameObject temp =Instantiate (heartPrefab, new Vector3((Screen.width-50)-spacing, Screen.height-50,1), Quaternion.identity, canvas.transform) as GameObject;
				//hearts [i] = temp;
			hearts[i]=Instantiate (heartPrefab, new Vector3((Screen.width-50)-spacing, Screen.height-50,1), Quaternion.identity, canvas.transform) as GameObject;
			spacing += 75;
		}
	}
	public void removeLife(){
		hearts[numLives-1].GetComponent<heart>().dead=true;
		numLives--;
	}
	
	// Update is called once per frame

}
