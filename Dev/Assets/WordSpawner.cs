using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	public GameObject wordPrefab;
	public Transform wordCanvas;

	public WordDisplay SpawnWord (int spacing)
	{
		Vector3 randomPosition = new Vector3(500f+spacing,Random.Range(0+2f,Screen.height-100f),60);

		GameObject wordObj = Instantiate(wordPrefab, Camera.main.ScreenToWorldPoint(randomPosition), Quaternion.identity, wordCanvas);
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

		return wordDisplay;
	}

}
