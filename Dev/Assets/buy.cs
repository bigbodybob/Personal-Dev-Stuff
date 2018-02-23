using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameControl.control.isShopItselfOpen && GameControl.control.selectedItem!=null && Input.GetKeyDown(KeyCode.Return))
		{
			if(GameControl.control.totalMoney>=GameControl.control.shopItemsCosts[GameControl.control.selectedItemIndex])
			{
				GameControl.control.totalMoney-=GameControl.control.shopItemsCosts[GameControl.control.selectedItemIndex];
				GameControl.control.unlockedWordList.Add (GameControl.control.gameShopItems [GameControl.control.selectedItemIndex]);
				GameControl.control.gameShopItems.RemoveAt(GameControl.control.selectedItemIndex);
				GameControl.control.shopItemsCosts.RemoveAt(GameControl.control.selectedItemIndex);
				Destroy(GameControl.control.selectedItem);
				if (GameControl.control.selectedItemIndex == 0) {
					GameControl.control.selectedItemIndex++;
				} else {
					GameControl.control.selectedItemIndex--;
				}
			}

		}	
	}
}
