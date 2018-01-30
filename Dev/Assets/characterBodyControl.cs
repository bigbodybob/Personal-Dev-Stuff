using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterBodyControl : MonoBehaviour {
	public GameObject lowerarmS=null;
	public GameObject lowerarmleftS = null;
	public GameObject headS = null;
	public GameObject handS=null;
	public GameObject handleftS=null;
	public GameObject neckS=null;
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
	}
	public  void changeSkinToneChar()
	{


		headS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		lowerarmS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		lowerarmleftS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		neckS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		handS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;
		handleftS.GetComponent<SpriteRenderer> ().color = GameControl.control.skintone;

	}
	void Start () {
		
		changeSkinToneChar ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
