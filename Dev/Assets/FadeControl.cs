using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeControl : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator.SetBool ("fadeIn", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void levelChange(string scene, GameObject p)
	{
		StartCoroutine(loadScene (scene,p));
	}
	IEnumerator loadScene(string scene,GameObject p)
	{
		animator.SetBool ("fadeIn", true);

		while(p.GetComponent<CanvasGroup>().alpha<1)
		{
			yield return null;
		}
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
}
