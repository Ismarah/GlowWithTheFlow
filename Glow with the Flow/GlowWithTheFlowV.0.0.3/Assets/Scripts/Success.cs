using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{


	void Update ()
	{
		this.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
	}
}
