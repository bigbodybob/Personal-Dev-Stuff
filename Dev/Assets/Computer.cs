using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Computer : MonoBehaviour {
	public GameObject computerDisplay;
	public TextMeshProUGUI prompt;
	public GameObject panel;
	public CanvasGroup promptCanvasGroup;
	// Use this for initialization
	void OnTriggerEnter2D()
	{
		promptCanvasGroup.alpha = 1;
	}
	void OnTriggerExit2D()
	{
		promptCanvasGroup.alpha = 0;

	}
	void Awake () {
		 promptCanvasGroup=prompt.GetComponent<CanvasGroup>();

	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && promptCanvasGroup.alpha==1) {
			GameControl.control.latestCharPositionInScene = transform.position;
			GameControl.control.latestScene = SceneManager.GetActiveScene().name;
			panel.GetComponent<FadeControl> ().levelChange ("programming", panel);

		}
	}
}
