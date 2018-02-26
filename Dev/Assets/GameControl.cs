using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class GameControl : MonoBehaviour {
	//General
	public bool doesCurrentGameExist;
	//shop
	public bool isShopItselfOpen;

	public bool isShopOpen;
	public List<string> gameShopItems;
	public List<float> shopItemsCosts;
	public GameObject selectedItem;
	public int itemCount = 0;
	public int selectedItemIndex;
	//compete
	public double rating;
	public double[] competeingRatings=new double[3];
	public DateTime competeAgainDate;
	public bool isCompeting;
	public bool canCompete = true;
	public GameObject results;
	//fundraiser
	public float totalMoney;
	public int moneyClickMultiplier = 0;

	public List<ShopItem> shopItems;
	public int[] shopCounts={0,0,0,0};
	public float[] shopItemValue={.1f,1,10,50};
	public float[] shopPrices={10,100,1000,10000};
	public float donutsPerSecond;
	public  DateTime latestTime;
	//donut shop
	public bool isDonutShopOpen;
	public GameObject selectedDonutShopButton=null;
	public int currentDonutShopSelection = 0;
	public Rect screenRect;
	//Dialog Box;
	public bool isDialogOpen;
	public int currentDialogButtonSelectionIndex = 0;
	public GameObject selectedDialogButton;
	//computer
	public int gameCount=0;
		//computer navigation
	public int currentGameSelectionIndex=0;
	public bool isClearBugsClicked;
	public int currentGameButtonSelectionIndex = 0;
	public bool isPCOpen;

	public GameObject selectedGame=null;
	public GameObject selectedButton;
	//Level system
	public int programmingLevel=1;
	public int bugCheckLevel=1;
	//Scene Management
	public string currentScene;
	public string latestScene;
	public Vector3 latestCharPositionIndoors;
	public Vector3 latestCharPositionOutdoors;

	//vars specific to TYPING GAME
	public bool wordStarted;
	public bool isGameOver=false;
	//vars shared across game scenes
	public bool hasMainHelpMenuBeenSeen;
	public List<string> unlockedWordList;
	public List<string> allGamesNames;
	public List<CreatedGame> allGames;
	public static  GameControl control;
	public int upperarm=0;
	public bool isCharFlipCorrect=true;
	public int lowerarm= 0;
	public int lowerleg= 0;
	public int upperleg= 0;
	public int body= 0;
	public Color skintone;
	public Color hairColor;
	public int shoes= 0;
	public int hair= 0;
	//sprite lists
	public Sprite[] hairSpriteList;
	public Sprite[] bodySpriteList;
	public Sprite[] upperSpriteList;
	public Sprite[] faceSpriteList;
	public int selectedBody;
	public int selectedFace;
	public int selectedHair;
	public AudioClip[] music;
	public AudioSource mainAudio;
	//current scene
	public string sceneName;
	// Use this for initialization
	void OnApplicationQuit()
	{
		if (SceneManager.GetActiveScene ().name == "fundraise") {
			latestTime = DateTime.Now;
		}
		if(SceneManager.GetActiveScene().name!="customize"&& SceneManager.GetActiveScene().name!="startreal") 
		Save ();
		Debug.Log ("finita");
	}
	void Awake () {
//File.Delete (Application.persistentDataPath + "/saveinfo.dat");
		screenRect = new Rect (0,0, Screen.width, Screen.height-80);

		sceneName = SceneManager.GetActiveScene ().name;
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}
		if (!File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
			doesCurrentGameExist = false;
		} else if (File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
			doesCurrentGameExist = true;
		}
	}
	public void sceneChanged()
	{
		
	}public  float DonutsPerClick()
	{
		float value = 0;
		for (int x = 0; x <4; x++)
			value += GameControl.control.shopCounts [x] * GameControl.control.shopItemValue[x];
		return value;
	}
	public void addDonut(){
		GameControl.control.totalMoney += DonutsPerClick () / 10;
	}
	public void catchUp(){
		float timeElapse = (float) DateTime.Now.Subtract (GameControl.control.latestTime).TotalSeconds;
		GameControl.control.totalMoney += DonutsPerClick () * timeElapse;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (sceneName != SceneManager.GetActiveScene ().name) {
			if (SceneManager.GetActiveScene ().name == "startreal") {
				mainAudio.clip = music [0];
				mainAudio.Play ();
			}
			if (SceneManager.GetActiveScene ().name == "bugcheck" || SceneManager.GetActiveScene ().name == "programming") {
				mainAudio.clip = music [2];
			} else {
				mainAudio.clip = music [1];
				mainAudio.Play ();
			}
			if (SceneManager.GetActiveScene ().name == "playerhome"&& isCompeting) {
				StartCoroutine (compete());
			}
			isPCOpen = false;
			isClearBugsClicked = false;
			gameCount = 0;
			//selectedDialogButtonIndex = 0;
			//selectedButton = 0;
			currentDialogButtonSelectionIndex = 0;
			currentGameButtonSelectionIndex = 1;
			isDialogOpen = false;
			itemCount = 0;
			isDonutShopOpen = false;
			sceneName = SceneManager.GetActiveScene ().name;
		}
	if (!isCompeting && !canCompete &&DateTime.Now>=competeAgainDate) {
			canCompete = true;
		}
	
	}
	IEnumerator compete()
	{
		yield return new WaitForSeconds (1);
		int rank = 4;
		for (int x=0; x<3;x++){
			competeingRatings[x] = (Double)Random.Range (5.0f, 8.0f);
			if (competeingRatings[x]<= rating) {
				rank--;
			}
		}

		GameObject obj=Instantiate (results);
		obj.GetComponent<results> ().rank = rank;
		isCompeting = false;
		competeAgainDate = DateTime.Now.AddMinutes (15);
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
			hairc = new Color (0.3F, 0F, .78F, 1.0F);
		} else if (haircolorvalue == 7) {
			hairc = new Color (0F, .78F, 0F, 1.0F);
		} else if (haircolorvalue == 8) {
			hairc = new Color (.78F, 0F, 0F, 1.0F);
		} else if (haircolorvalue == 9) {
			hairc = new Color (1F, 1F, 1F, 1.0F);
		} else if (haircolorvalue == 10) {
			hairc = new Color (1F, .3F, .5F, 1.0F);

		} else if(haircolorvalue==11){
			hairc = new Color (.1F, .6F, .7F, 1.0F);
		}
		else{
			hairc = new Color (0f, 0f, .78F, 1.0F);

		}
			
		GameObject.Find ("hair").GetComponent<SpriteRenderer> ().color = hairc;
		hairColor = hairc;
	}
	public void Save()
	{
		Debug.Log ("saving");

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveinfo.dat");
		saveData data = new saveData ();
		data.allGames = allGames;
		data.upperarm = upperarm;
		data.lowerarm = lowerarm;
		data.lowerleg = lowerleg;
		data.upperleg = upperleg;
		data.body = body;
		data.skintoneR = skintone.r;
		data.skintoneG= skintone.g;
		data.skintoneB = skintone.b;


		data.shoes = this.shoes;
		data.hair = hair;
		data.hairR =hairColor.r;			
		data.hairG =hairColor.g;
		data.hairB =hairColor.b;



		data.selectedBody=selectedBody;
		data.selectedFace=selectedFace;
		data.selectedHair=selectedHair;
		data.unlockedWordList=unlockedWordList;
		data.allGamesNames=allGamesNames;
		data.rating=rating;
		data.competeingRatings=competeingRatings;
		data.competeAgainDate=competeAgainDate;
		data.isCompeting=isCompeting;
		data.canCompete = canCompete;
		data.totalMoney=totalMoney;
		data.moneyClickMultiplier =moneyClickMultiplier;

		data.shopCounts=shopCounts;
		data.shopItemValue = shopItemValue;
		data.shopPrices=shopPrices;
		data.donutsPerSecond=donutsPerSecond;
		data.latestTime=latestTime;


		bf.Serialize (file, data);
		file.Close ();
	}
	public  void SaveLoad()
	{
		if (File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
			Debug.Log ("loading");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file=File.Open(Application.persistentDataPath+"/saveinfo.dat",FileMode.Open);
			saveData data = (saveData)bf.Deserialize (file);
			file.Close ();
			allGames = data.allGames;
			upperarm = data.upperarm;
			lowerarm = data.lowerarm;
			lowerleg = data.lowerleg;
			upperleg = data.upperleg;
			body = data.body;
			skintone = new Color(data.skintoneR,data.skintoneG,data.skintoneB,1f);
			shoes = data.shoes;
			hair = data.hair;
			hairColor = new Color(data.hairR,data.hairG,data.hairB,1f);

			selectedBody=data.selectedBody;
			selectedFace=data.selectedFace;
			selectedHair=data.selectedHair;
			unlockedWordList=data.unlockedWordList;
			allGamesNames=data.allGamesNames;
			rating=data.rating;
			competeingRatings=data.competeingRatings;
			competeAgainDate=data.competeAgainDate;
			isCompeting=data.isCompeting;
			canCompete = data.canCompete;
			totalMoney=data.totalMoney;
			moneyClickMultiplier =data.moneyClickMultiplier;

			shopCounts=data.shopCounts;
			shopItemValue = data.shopItemValue;
			shopPrices=data.shopPrices;
			donutsPerSecond=data.donutsPerSecond;
			latestTime=data.latestTime;



		} else {
			Debug.Log ("saving");

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/saveinfo.dat");
			saveData data = new saveData ();
			data.allGames = allGames;
			data.upperarm = upperarm;
			data.lowerarm = lowerarm;
			data.lowerleg = lowerleg;
			data.upperleg = upperleg;
			data.body = body;
			data.skintoneR = skintone.r;
			data.skintoneG= skintone.g;
			data.skintoneB = skintone.b;


			data.shoes = this.shoes;
			data.hair = hair;
			data.hairR =hairColor.r;			
			data.hairG =hairColor.g;
			data.hairB =hairColor.b;



			data.selectedBody=selectedBody;
			data.selectedFace=selectedFace;
			data.selectedHair=selectedHair;
			data.unlockedWordList=unlockedWordList;
			data.allGamesNames=allGamesNames;
			data.rating=rating;
			data.competeingRatings=competeingRatings;
			data.competeAgainDate=competeAgainDate;
			data.isCompeting=isCompeting;
			data.canCompete = canCompete;
			data.totalMoney=totalMoney;
			data.moneyClickMultiplier =moneyClickMultiplier;

			data.shopCounts=shopCounts;
			data.shopItemValue = shopItemValue;
			data.shopPrices=shopPrices;
			data.donutsPerSecond=donutsPerSecond;
			data.latestTime=latestTime;

			 
			bf.Serialize (file, data);
			file.Close ();
		}
	}
	public  void StartButton(){
		if (File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file=File.Open(Application.persistentDataPath+"/saveinfo.dat",FileMode.Open);
			saveData data = (saveData)bf.Deserialize (file);
			file.Close ();
			allGames = data.allGames;
			upperarm = data.upperarm;
			lowerarm = data.lowerarm;
			lowerleg = data.lowerleg;
			upperleg = data.upperleg;
			body = data.body;
			skintone = new Color(data.skintoneR,data.skintoneB,data.skintoneG);
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
	public void Load()
	{
		Debug.Log ("loading");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file=File.Open(Application.persistentDataPath+"/saveinfo.dat",FileMode.Open);
		saveData data = (saveData)bf.Deserialize (file);
		file.Close ();
		allGames = data.allGames;
		upperarm = data.upperarm;
		lowerarm = data.lowerarm;
		lowerleg = data.lowerleg;
		upperleg = data.upperleg;
		body = data.body;
		skintone = new Color(data.skintoneR,data.skintoneG,data.skintoneB,1f);
		shoes = data.shoes;
		hair = data.hair;
		hairColor = new Color(data.hairR,data.hairG,data.hairB,1f);

		selectedBody=data.selectedBody;
		selectedFace=data.selectedFace;
		selectedHair=data.selectedHair;
		unlockedWordList=data.unlockedWordList;
		allGamesNames=data.allGamesNames;
		rating=data.rating;
		competeingRatings=data.competeingRatings;
		competeAgainDate=data.competeAgainDate;
		isCompeting=data.isCompeting;
		canCompete = data.canCompete;
		totalMoney=data.totalMoney;
		moneyClickMultiplier =data.moneyClickMultiplier;

		shopCounts=data.shopCounts;
		shopItemValue = data.shopItemValue;
		shopPrices=data.shopPrices;
		donutsPerSecond=data.donutsPerSecond;
		latestTime=data.latestTime;


	}
	void OnGUI()
	{
	}
}
[System.Serializable]
class saveData:System.Object
{
	public List<CreatedGame> allGames;
	public int upperarm;
	public int lowerarm;
	public int lowerleg;
	public int upperleg;
	public int body;
	public float skintoneR;
	public float skintoneG;
	public float skintoneB;
	public float hairR;
	public float hairG;
	public float hairB;
	public int shoes;
	public int hair;
	public int selectedBody;
	public int selectedFace;
	public int selectedHair;
	public List<string> unlockedWordList;
	public List<string> allGamesNames;
	public double rating;
	public double[] competeingRatings=new double[3];
	public DateTime competeAgainDate;
	public bool isCompeting;
	public bool canCompete = true;
	public float totalMoney;
	public int moneyClickMultiplier = 0;

	public int[] shopCounts={0,0,0,0};
	public float[] shopItemValue={.1f,1,10,50};
	public float[] shopPrices={10,100,1000,10000};
	public float donutsPerSecond;
	public  DateTime latestTime;

}