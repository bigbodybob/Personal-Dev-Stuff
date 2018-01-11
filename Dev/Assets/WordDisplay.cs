using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordDisplay : MonoBehaviour {
	public GameObject testCastle;
	public TextMeshProUGUI text;
	public float fallSpeed = 1f;
	public GameObject spawnFX;
	public bool wordDestroyed;
	// has word entered screen?
	private bool wordInView;
	private string itemType;
	public void SetWord (string word)
	{
		text.text = word;
		itemType = word;
	}

	public void RemoveLetter ()
	{
		
			text.text = text.text.Remove (0, 1);
			text.color = Color.red;

	}

	public void RemoveWord ()
	{

		Destroy(gameObject);

	}
	//creates whatever gaemobject text equals
	public void CreateObject()
	{

		GameObject item= (GameObject)Instantiate (Resources.Load("wordgame/"+itemType), new Vector3 (transform.position.x,transform.position.y,1),Quaternion.identity);
		Image itemImage =(Image) item.GetComponent<Image>();
		GameObject clone= Instantiate(spawnFX,new Vector3 (transform.position.x,transform.position.y,1),Quaternion.identity);
		ParticleSystem clonePart = clone.transform.Find("Particle System").GetComponent<ParticleSystem> ();
		ParticleSystem.MainModule main = clonePart.main;
		float itemWidth = itemImage.rectTransform.rect.width;
		main.startSpeed =itemWidth;
		Destroy (clone, 5f);
	}
	private void Update()
	{
		if (Camera.main.WorldToViewportPoint (transform.position).x > -.05 && Camera.main.WorldToViewportPoint (transform.position).x < 1) {
			wordInView = true;
		
		}
		if (wordInView && !(Camera.main.WorldToViewportPoint (transform.position).x > -.05 && Camera.main.WorldToViewportPoint (transform.position).x < 1)) {
			RemoveWord();
			wordDestroyed = true;
			GameObject.Find ("LifeManager").GetComponent<lifeManager>().removeLife();
		}
	}


}