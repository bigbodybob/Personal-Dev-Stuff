using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnitySampleAssets._2D;
public class FadeControl : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator.SetBool ("fadeIn", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void floorChange(Vector3 pos, GameObject character)
	{
		StartCoroutine (floorChangeAnim (pos,character));
	}
	IEnumerator floorChangeAnim(Vector3 pos,GameObject character)
	{
		animator.SetBool ("fadeIn", true);
		while (gameObject.GetComponent<CanvasGroup> ().alpha < 1) {
			yield return null;
		}
		GameControl.control.isCharFlipCorrect = false;

		character.transform.position = pos;
			Camera.main.GetComponent<Camera2DFollow> ().damping=0.1f;
		animator.SetBool ("fadeIn", false);
		yield return new WaitForSeconds (1);
		Camera.main.GetComponent<Camera2DFollow> ().damping=1f;

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
