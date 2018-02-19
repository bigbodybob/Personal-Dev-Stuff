using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShop : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameControl.control.isDonutShopOpen && Input.GetKeyDown (KeyCode.E)) {
			animator.SetBool ("isSlidIn", true);
			GameControl.control.isDonutShopOpen = true;
		}
		else if (GameControl.control.isDonutShopOpen && Input.GetKeyDown (KeyCode.E)) {
			animator.SetBool ("isSlidIn", false);
			GameControl.control.isDonutShopOpen = false;

		}
	}
}
