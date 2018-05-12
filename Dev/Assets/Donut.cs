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
		GameControl.control.totalMoneyEver+= DonutsPerClick () / 10;
	}
	public void catchUp(){
		float timeElapse = (float) DateTime.Now.Subtract (GameControl.control.latestTime).TotalSeconds;
		GameControl.control.totalMoney += DonutsPerClick () * timeElapse;
		GameControl.control.totalMoneyEver += DonutsPerClick () * timeElapse;

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
		if(GameControl.control.totalMoneyEver>=10000 && !GameControl.control.raising10k)
		{
			GameControl.control.raising10k = true;
			GameControl.control.awardPointCount += 1;
			GameControl.control.checkForGoalPoints();
			GameControl.control.awardUnlocked ();


		}
		if(GameControl.control.totalMoneyEver>=500000 && !GameControl.control.raise500k)
		{
			GameControl.control.raise500k = true;
			GameControl.control.awardPointCount += 2;
			GameControl.control.checkForGoalPoints();

			GameControl.control.awardUnlocked ();
		}
		if (Input.GetKeyDown (GameControl.control.backInput)) {
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
				GameControl.control.totalMoneyEver += 1 + GameControl.control.moneyClickMultiplier;
			}
		}
	}
}
