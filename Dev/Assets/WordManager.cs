using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

	public List<Word> words;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;
	private int space = 0;
	public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord(space), this);
		space += Screen.width / 2;
		Debug.Log(word.word);

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
			
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
			}
		} else
		{
			foreach(Word word in words)
			{
				if (word.DoesWordExist() && word.GetNextLetter() == letter)
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
			words.Remove(activeWord);
		}
	}

}
