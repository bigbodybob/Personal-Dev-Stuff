using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class results : MonoBehaviour {
	public TextMeshProUGUI text;
	public int rank;
	bool isTextAssigned=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
		
			Destroy (gameObject);
		}
		if (!isTextAssigned) {
			if (rank == 4) {
				text.text = "Sorry, you didn't win anything!";
				isTextAssigned = true;


			} 
			else{
				if (!GameControl.control.placingMedal) {
					GameControl.control.placingMedal = true;
					GameControl.control.awardPointCount += 1;
					GameControl.control.checkForGoalPoints();

				}
				if (rank == 1) {
				text.text = "Congratulations, you got 1st!";
				isTextAssigned = true;
				if(!GameControl.control.placeFirst)
						GameControl.control.placeFirst = true;{
						GameControl.control.awardPointCount += 2;
						GameControl.control.checkForGoalPoints();

					}

			} else if (rank == 2) {
				text.text = "Congratulations, you got 2nd!";
				isTextAssigned = true;

			} else if (rank == 3) {
				text.text = "Congratulations, you got 3rd!";
				isTextAssigned = true;
			}
			
			}
		}
	}
}
