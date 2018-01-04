using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {
	public GameObject testCastle;
	public Text text;
	public float fallSpeed = 1f;
	public GameObject spawnFX;
	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Instantiate (testCastle, Camera.main.ScreenToWorldPoint(new Vector3 (transform.position.x,transform.position.y,1)),Quaternion.identity);
		GameObject clone= Instantiate(spawnFX,Camera.main.ScreenToWorldPoint(new Vector3 (transform.position.x,transform.position.y,1)),Quaternion.identity);
		Destroy (clone, 5f);
		Destroy(gameObject);

	}

	private void Update()
	{
		transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
	}

}
