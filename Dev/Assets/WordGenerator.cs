using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator:MonoBehaviour  {
	public static string[] wordList=GameControl.unlockedWordList;
	public  List<wordCount> wordC;

	public List<wordCount> wordCList()
	{
		foreach (string word in wordList) {
			wordCount tempWord = new wordCount (0,word);
			wordC.Add (tempWord);
		}
		return wordC;
	}


	public string GetRandomWord ()
	{
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}


}
