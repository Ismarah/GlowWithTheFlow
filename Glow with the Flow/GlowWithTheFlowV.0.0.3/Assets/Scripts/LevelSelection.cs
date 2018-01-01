using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

	public void Level1 ()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void Level2 ()
	{
		SceneManager.LoadScene ("Level2");
	}

	public void Level3 ()
	{
		SceneManager.LoadScene ("Level3");
	}

	public void Level4 ()
	{
		SceneManager.LoadScene ("Level4");
	}

	public void Level5 ()
	{
		SceneManager.LoadScene ("Level5");
	}

	public void Level6 ()
	{
		SceneManager.LoadScene ("Level6");
	}

	public void Level7 ()
	{
		SceneManager.LoadScene ("Level7");
	}

	public void Level8 ()
	{
		SceneManager.LoadScene ("Level8");
	}

	public void Level9 ()
	{
		SceneManager.LoadScene ("Level9");
	}

	public void Level10 ()
	{
		SceneManager.LoadScene ("Level10");
	}

	public void Level11 ()
	{
		SceneManager.LoadScene ("Level11");
	}

	public void NextPage ()
	{
		GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
		canvas.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-1320, 0);
		canvas.transform.GetChild (1).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-1342, 0);
	}

	public void PreviousPage ()
	{
		GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
		canvas.transform.GetChild (0).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		canvas.transform.GetChild (1).GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}
}
