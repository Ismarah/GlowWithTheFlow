using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{

	void Start ()
	{
		Invoke ("Destroy", 1);
	}

	void Destroy ()
	{
		Destroy (this.gameObject);
	}
}
