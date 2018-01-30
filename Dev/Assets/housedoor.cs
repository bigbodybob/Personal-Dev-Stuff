using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class housedoor : MonoBehaviour {
	public Animator animator;
	public CanvasGroup prompt;
	public GameObject panel;
	void OnTriggerEnter2D()
	{
		animator.SetBool ("isOpen", true);
		prompt.alpha = 1;

	}
	void OnTriggerExit2D()
	{
		animator.SetBool ("isOpen", false);	
		prompt.alpha = 0;


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && animator.GetBool("isOpen")) {
			panel.GetComponent<FadeControl>().levelChange("home",panel);
		}
	}
}
