using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public GameObject mainCharacter;
	public int numberOfBugs;
	public int score;
	public GameObject deathEffect;
	//how many available for instantiating
	public int numberOfUnkillableBugs;
	public int clearedBugCount;
	public int selectedGameIndex;
	public GameObject spikedMonster;
	public int tempCount = 0;
	public GameObject normalMonster;
	private float currentTime;
	public bool isGameStarted;
	public GameObject winMessage;
	public GameObject startMessage;
	public float spawnDelay=5f;
	public static EnemyManager control;
	// Use this for initialization
	void Awake () {
		
		control = this;
		selectedGameIndex = GameControl.control.currentGameSelectionIndex;
		numberOfUnkillableBugs = (int)Random.Range (20,30)-GameControl.control.bugCheckLevel ;
		//numberOfBugs = GameControl.control.allGames [selectedGameIndex].bugs-numberOfUnkillableBugs;

		numberOfBugs = 50-numberOfUnkillableBugs;
	}
	void Start()
	{
		mainCharacter.GetComponent<Platformer2DUserControl> ().isMovementEnabled = false;
	}
	public void gameOverWin()
	{
		mainCharacter.GetComponent<Platformer2DUserControl> ().isMovementEnabled = false;
		lifeManagerBugCheck.control.isGameOver = true;
		GameControl.control.allGames [GameControl.control.currentGameSelectionIndex].bugs -= EnemyManager.control.score;

		winMessage.GetComponent<CanvasGroup> ().alpha = 1;

	}
	// Update is called once per frame
	void Update () {
		if (isGameStarted) {
			currentTime -= Time.deltaTime;
			if (currentTime < 0) {
				if (tempCount == 5 && numberOfUnkillableBugs >= 1) {
					float range = Random.Range (-20, 20);
					while (range < PlatformerCharacter2D.control.transform.position.x + 2 && range > PlatformerCharacter2D.control.transform.position.x - 2) {
						range =Random.Range (-20, 20);
					}
					Instantiate (spikedMonster, new Vector3 (range, 0), Quaternion.identity);
					numberOfUnkillableBugs--;
					tempCount = 0;
				} else if (numberOfBugs >= 1) {
					float range = Random.Range (-20, 20);
					while (range < PlatformerCharacter2D.control.transform.position.x + 2 && range > PlatformerCharacter2D.control.transform.position.x - 2) {
						range =Random.Range (-20, 20);
					}
					Instantiate (normalMonster, new Vector3 (range, 0), Quaternion.identity);
					numberOfBugs--;
					tempCount++;

			
				}

				if (spawnDelay > 2) {
					spawnDelay -= .2f;
				}
				currentTime = spawnDelay;
			}
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			startMessage.GetComponent<CanvasGroup> ().alpha = 0;
			isGameStarted = true;
			mainCharacter.GetComponent<Platformer2DUserControl> ().isMovementEnabled = true;
		}
	}
}
