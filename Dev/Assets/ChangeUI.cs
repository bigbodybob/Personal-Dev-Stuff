using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour {
	public Animator animator;
	public bool isOpen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (GameControl.control.eInput)) {
			if (isOpen) {

				animator.SetBool ("isZoomedIn", false);
				isOpen = false;
			}
			else if(!isOpen)
			{
				animator.SetBool("isZoomedIn", true);
				isOpen = true;
			}
		}

	}
}
