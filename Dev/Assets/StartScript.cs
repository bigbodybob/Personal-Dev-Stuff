using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (File.Exists (Application.persistentDataPath + "/saveinfo.dat")) {
				SceneManager.LoadScene ("main", LoadSceneMode.Single);
			} else {
				SceneManager.LoadScene ("customize", LoadSceneMode.Single);

			}
		}
	}
}
