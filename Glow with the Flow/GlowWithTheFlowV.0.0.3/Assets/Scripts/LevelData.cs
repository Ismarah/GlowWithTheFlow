using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

	public int levelNumber;
	public int pickUpCount;

	public string NextLevel ()
	{
		string s = string.Concat ("Level", levelNumber + 1);
		return s;
	}
}
