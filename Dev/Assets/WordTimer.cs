using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

	public WordManager wordManager;


	public int wordNum;
	private void Start()
	{
		for(int i=0; i<wordNum;i++){
			wordManager.AddWord();

		}
	}

}
