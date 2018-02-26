﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HelpScript : MonoBehaviour {
	public Animator animator;
	public TextMeshProUGUI[] texts;
	public TextMeshProUGUI header;
	// Use this for initialization
	void Start () {
		if (GameControl.control.hasMainHelpMenuBeenSeen) {
			animator.SetBool ("isZoomedIn", false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetBool ("isZoomedIn") && (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.H))) {
			if (SceneManager.GetActiveScene ().name == "main") {
				GameControl.control.hasMainHelpMenuBeenSeen = true;
			}
			animator.SetBool ("isZoomedIn", false);
		}
		else if (!animator.GetBool ("isZoomedIn") && (Input.GetKeyDown(KeyCode.H))) {
			animator.SetBool ("isZoomedIn", true);
		}
	}
}
