using UnityEngine;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Reflection;
using UnityEngine.SceneManagement;


[Serializable ()]
public class SaveData : ISerializable
{
	public string currentLevel;

	public SaveData ()
	{
	}

	public SaveData (SerializationInfo info, StreamingContext ctxt)
	{
		currentLevel = (string)info.GetValue ("currentLevel", typeof(string));
	}

	public void GetObjectData (SerializationInfo info, StreamingContext ctxt)
	{
		info.AddValue ("currentLevel", (currentLevel));
	}
}