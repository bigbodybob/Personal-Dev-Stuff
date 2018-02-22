using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

	public WordManager wordManager;


	public int wordNum;
	public float timer = 5f;

	public float standardtime=5f;
	private void Start()
	{
		for(int i=0; i<wordNum;i++){
			wordManager.AddWord();

		}
	}
	void Update()
	{
		timer -= .05f;
		if (timer <= 0) {
			wordManager.AddWord ();
		
			timer =5f;

		}
	}
}
