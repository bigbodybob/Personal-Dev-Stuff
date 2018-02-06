using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour {
	//Level system
	public int programmingLevel=1;
	public int bugCheckLevel=1;
	//Scene Management
	public string currentScene;
	public string latestScene;
	public Vector3 latestCharPositionInScene;
	//vars specific to TYPING GAME
	public bool isGameOver=false;
	//vars shared across game scenes
	public Sprite[] upperarmlist;
	public Sprite[] hairlist;
	public string[] unlockedWordList = {   "castle" ,"minion"};
	public List<string> allGamesNames;
	public List<CreatedGame> allGames;
	public static  GameControl control;
	public int upperarm=0;
	public bool isCharFlipCorrect=true;
	public Vector3[] charPositions;
	public Vector3 currentCharPosition;
	public int lowerarm= 0;
	public int lowerleg= 0;
	public int upperleg= 0;
	public int body= 0;
	public Color skintone;
	public Color hairColor;
	public int shoes= 0;
	public int hair= 0;

	// Use this for initialization
	void Awake () {
		

		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public  void changeSkinTone(float newskintone, GameObject headS, GameObject lowerarmS, GameObject lowerarmleftS, GameObject neckS, GameObject handS, GameObject handleftS)
	{
		GameControl.control.skintone= new Color (0.5F*newskintone,0.3F*newskintone,0.2F*newskintone,1.0F);

		headS.GetComponent<SpriteRenderer> ().color = skintone;
		lowerarmS.GetComponent<SpriteRenderer> ().color = skintone;
		lowerarmleftS.GetComponent<SpriteRenderer> ().color = skintone;
		neckS.GetComponent<SpriteRenderer> ().color = skintone;
		handS.GetComponent<SpriteRenderer> ().color = skintone;
		handleftS.GetComponent<SpriteRenderer> ().color = skintone;

	}

	public void changeHairColor(float haircolorvalue)
	{
		Color hairc;
		//Color hairc= Color.HSVToRGB(haircolorvalue,1f,haircolorvalue);
		if (haircolorvalue == 0) {
			hairc = new Color (0F, 0F, 0F, 1.0F);

		} else if (haircolorvalue == 1) {
			hairc = new Color (.36F, .25F, .20F, 1.0F);

		} else if (haircolorvalue == 2) {
			hairc = new Color (0.6F, 0.37F, 0.26F, 1.0F);

		} else if (haircolorvalue == 3) {
			hairc = new Color (.66F, .66F, .66F, 1.0F);
		} else if (haircolorvalue == 4) {
			hairc = new Color (.50F, .45F, .24F, 1.0F);
			
		} else if (haircolorvalue == 5) {
			hairc = new Color (.98F, .94F, .74F, 1.0F);
		} else if (haircolorvalue == 6) {
			hairc = new Color (0F, 0F, .78F, 1.0F);
		} else if (haircolorvalue == 7) {
			hairc = new Color (0F, .78F, 0F, 1.0F);
		} else if (haircolorvalue == 8) {
			hairc = new Color (.78F, 0F, 0F, 1.0F);
		}
		else {
			hairc = new Color (1F, 1F, 1F, 1.0F);
		}
			
		GameObject.Find ("hair").GetComponent<SpriteRenderer> ().color = hairc;
		hairColor = hairc;
	}
	public void changeHair(float hairS)
	{
		hair = (int)hairS;
		GameObject.Find ("hair").GetComponent<SpriteRenderer> ().sprite = hairlist[hair];

	}
	public  void StartButton(){
		if (File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file=File.Open(Application.persistentDataPath+"/saveinfo.dat",FileMode.Open);
			saveData data = (saveData)bf.Deserialize (file);
			file.Close ();
			upperarm = data.upperarm;
			lowerarm = data.lowerarm;
			lowerleg = data.lowerleg;
			upperleg = data.upperleg;
			body = data.body;
			skintone = data.skintone;
			shoes = data.shoes;
			hair = data.hair;
		}
		SceneManager.LoadScene("customize",LoadSceneMode.Single);
	}
	public void changeScene(GameObject panel)
	{
		panel.GetComponent<FadeControl> ().levelChange (latestScene,panel);
	}

	public void StartGame()
	{
		
		SceneManager.LoadScene("main",LoadSceneMode.Single);
	}

	void OnGUI()
	{
	}
}
[System.Serializable]
class saveData: System.Object
{
	public int upperarm;
	public int lowerarm;
	public int lowerleg;
	public int upperleg;
	public int body;
	public Color skintone;
	public int shoes;
	public int hair;
}