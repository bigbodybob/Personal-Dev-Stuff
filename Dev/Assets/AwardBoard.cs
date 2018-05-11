using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardBoard : MonoBehaviour {
	//Tier1
	public SpriteRenderer buyWord;
	public SpriteRenderer placingMedal;
	public SpriteRenderer raising10k;
	public SpriteRenderer submitToLeaderboard;
	//Tier2
	public SpriteRenderer placeFirst;
	public SpriteRenderer buyAllWords;
	public SpriteRenderer raise500k;
	//FBLA ULTIMATE MEDAL
	public SpriteRenderer FblaExcellenceAward;

	// Use this for initialization
	void Start () {
		if (GameControl.control.buyWord) {
			buyWord.color = Color.white;
		}
		if (GameControl.control.placingMedal) {
			placingMedal.color = Color.white;
		}	
		if (GameControl.control.raising10k) {
			raising10k.color = Color.white;
		}	
		if (GameControl.control.submitToLeaderboard) {
			submitToLeaderboard.color = Color.white;
		}	
		if (GameControl.control.placeFirst) {
			placeFirst.color = Color.white;
		}
		if (GameControl.control.buyAllWords) {
			buyAllWords.color = Color.white;
		}	
		if (GameControl.control.raise500k) {
			raise500k.color = Color.white;
		}

		if (GameControl.control.FblaExcellenceAward) {
			FblaExcellenceAward.color = Color.white;
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
