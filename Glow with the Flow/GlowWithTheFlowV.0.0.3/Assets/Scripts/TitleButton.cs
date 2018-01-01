using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{

	public void NewGame ()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void Load ()
	{
		LevelManager.manager.Load ();
		SceneManager.LoadScene (LevelManager.manager.currentLevel);

	}

	public void SelectLevel ()
	{
		SceneManager.LoadScene ("LevelSelection");
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}
