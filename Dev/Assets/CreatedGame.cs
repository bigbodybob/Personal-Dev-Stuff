using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CreatedGame {
	public string name;
	public int bugs;
	public double rating;
	public List<wordCount> wordCount;
	public int score;
	// Use this for initialization
	public CreatedGame(string name, int bugs,List<wordCount> wordC, int score)
	{
		this.name=name;
		this.bugs = bugs;
		this.bugs = Random.Range(40, 55) - (GameControl.control.bugCheckLevel*3);
		wordCount = wordC;
		this.score = score;
		rating = (GameControl.control.programmingLevel*.25)-(this.bugs*.07)+(score*.05);
	}

}
