using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public static LevelManager manager;
	public string currentLevel;

	void Awake ()
	{
		if (manager == null) {
			manager = this;
			DontDestroyOnLoad (gameObject);
		} else if (manager == this) {
			Destroy (gameObject);
		}
	}


	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (SceneManager.GetActiveScene ().name != "LevelSelection") {
				currentLevel = SceneManager.GetActiveScene ().name;
				Save ();
			}
			SceneManager.LoadScene ("Title");
		}
	}


	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Save.dat");

		SaveData data = new SaveData ();
		data.currentLevel = currentLevel;
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/Save.dat", FileMode.Open);

		SaveData data = (SaveData)bf.Deserialize (file);
		file.Close ();

		currentLevel = data.currentLevel;
	}



}
