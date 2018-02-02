using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class characterBodyControl : MonoBehaviour {
	public GameObject lowerarmS=null;
	public GameObject lowerarmleftS = null;
	public GameObject headS = null;
	public GameObject handS=null;
	public GameObject handleftS=null;
	public GameObject neckS=null;
	public GameObject hair=null;
	public EntityRenderer spriteRenderer;
	void Awake()
	{
		if(GameObject.Find ("lower_002")!=null){
			lowerarmS = GameObject.Find ("lower_002");
		}
		if(GameObject.Find ("lower_001")!=null){
			lowerarmleftS = GameObject.Find ("lower_001");
		}
		if(GameObject.Find ("neck")!=null){
			neckS = GameObject.Find ("neck");
		}	if(GameObject.Find ("head")!=null){
			headS = GameObject.Find ("head");
		}
		if(GameObject.Find ("hand")!=null){
			handS = GameObject.Find ("hand");
		}
		if(GameObject.Find ("hand_000")!=null){
			handleftS = GameObject.Find ("hand_000");
		}
		hair = GameObject.Find ("hair");
	}
	public  void changeColorVals()
	{

		hair.GetComponent<SpriteRenderer> ().color = GameControl.control.hairColor;
		headS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		lowerarmS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		lowerarmleftS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		neckS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		handS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		handleftS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;

	}
	void Start () {
		transform.parent.position = GameControl.control.currentCharPosition;
		Color tmp= spriteRenderer.Color;
		tmp.a = 1f;
		spriteRenderer.Color = tmp;
		changeColorVals ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
