using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Donut : MonoBehaviour {
	public Image donut;
	public GameObject panel;
	public int itemCount=3;
	// Use this for initialization
	void Start () {
		StartCoroutine (addDonutCoroutine());
		catchUp ();
	}
	public  float DonutsPerClick()
	{
		float value = 0;
		for (int x = 0; x < itemCount; x++)
			value += GameControl.control.shopCounts [x] * GameControl.control.shopItemValue[x];
				return value;
	}
	public void addDonut(){
		GameControl.control.totalMoney += DonutsPerClick () / 10;
	}
	public void catchUp(){
		float timeElapse = (float) DateTime.Now.Subtract (GameControl.control.latestTime).TotalSeconds;
		GameControl.control.totalMoney += DonutsPerClick () * timeElapse;
	}
	IEnumerator addDonutCoroutine()
	{
		while(true)
			{
			addDonut ();
			yield return new WaitForSeconds (.1f);
		}
	}
	// Update is called once per frame
	void Update () {
		/*foreach(int x:numList)
		{
			
		}*/
		if (Input.GetKeyDown (KeyCode.B)) {
			GameControl.control.latestTime = DateTime.Now;
			panel.GetComponent<FadeControl> ().levelChange ("fblabuilding", panel);
		
		}
		GameControl.control.donutsPerSecond = DonutsPerClick();
		if (!GameControl.control.isDonutShopOpen) {
		
			if (Input.GetKeyDown (KeyCode.Space)) {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector2 (.8f, .8f);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				gameObject.GetComponent<RectTransform> ().localScale = new Vector2 (1, 1);
				GameControl.control.totalMoney += 1+GameControl.control.moneyClickMultiplier;
			}
		}
	}
}
