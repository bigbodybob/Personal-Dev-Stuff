using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameSelectcompete : MonoBehaviour {
	public GameObject layout;
	public TextMeshProUGUI noGameText;
	public GameObject gameActionBar;
	public GameObject gameContainer;
	public GameObject game;
	public float maxY;
	public float minY=-70;
	void Start () {
		maxY =- gameActionBar.transform.localPosition.y;	
		if (GameControl.control.allGames.Count == 0) {
			noGameText.GetComponent<CanvasGroup> ().alpha = 1;
			GetComponent<CanvasGroup> ().alpha = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		while (GameControl.control.gameCount < GameControl.control.allGames.Count) {
			GameObject gameObj = Instantiate (game, new Vector3 (0, 0), Quaternion.identity, gameContainer.transform);
			gameObj.GetComponent<GameSelectionObject> ().index = GameControl.control.gameCount;
			GameControl.control.gameCount++;
			transform.SetAsLastSibling ();
		}

			if (Input.GetKeyDown (KeyCode.DownArrow) && GameControl.control.allGames.Count>0&& GameControl.control.currentGameSelectionIndex!=GameControl.control.allGames.Count-1) {
				GameControl.control.currentGameSelectionIndex++;
				if (-transform.localPosition.y > maxY) {
					Vector3 newPos = layout.transform.localPosition;
					newPos.y += GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
					layout.transform.localPosition = newPos;
					maxY += GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
				}
				//transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);

			}
			if (Input.GetKeyDown (KeyCode.UpArrow)&&  GameControl.control.allGames.Count>0&& GameControl.control.currentGameSelectionIndex!=0) {
				GameControl.control.currentGameSelectionIndex--;			transform.position = new Vector3 (transform.position.x, GameControl.control.selectedGame.transform.position.y);
				//transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);
				if (-transform.localPosition.y < maxY) {
					Vector3 newPos = layout.transform.localPosition;
					newPos.y -= GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
					layout.transform.localPosition = newPos;
					maxY -= GameControl.control.selectedGame.GetComponent<RectTransform>().rect.height;
				}
				//	if (!screenRect.Contains (gameObject))
			}
			if(GameControl.control.selectedGame!=null)
				transform.position = new Vector3 (GameControl.control.selectedGame.transform.position.x-5, GameControl.control.selectedGame.transform.position.y);


	}
}
