using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

	public List<Word> words;
	public WordSpawner wordSpawner;
	public WordGenerator wordGenerator;
	public List<wordCount> wordCounters;
	private bool hasActiveWord;
	private Word activeWord;
	private int space = 0;
	public void Awake()
	{
		wordCounters=wordGenerator.wordCList();
	}
	public void AddWord ()
	{
		Word word = new Word(wordGenerator.GetRandomWord(), wordSpawner.SpawnWord(space), this);
		space += Screen.width / 2;

		words.Add(word);
	}

	public void TypeLetter (char letter)
	{ 
		if (hasActiveWord && !activeWord.DoesWordExist ()) {
			words.Remove(activeWord);

			hasActiveWord = false;
		}
		if (hasActiveWord)
		{
			
			if (activeWord.GetNextLetter () == letter) {
				activeWord.TypeLetter ();
			} else if (activeWord.GetNextLetter () != letter) {
				hasActiveWord = false;
				lifeManager.control.removeLife ();

				activeWord.display.fade();
				words.Remove (activeWord);
			}
		} else
		{
			foreach(Word word in words)
			{
				if (word.DoesWordExist() && word.display.wordInView && word.GetNextLetter() == letter)
				{
					
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			foreach (wordCount count in wordCounters) {
				if (count.name.Equals(activeWord.word)) {
					count.addCount();
				}
			}
			gameStats.gameScore+=(10*activeWord.word.Length);

			words.Remove(activeWord);
		}
	}

}
