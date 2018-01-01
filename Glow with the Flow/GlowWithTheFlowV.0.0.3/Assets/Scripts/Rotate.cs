using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	public float rotationSpeed;
	public float amount;
	public int direction;

	void Start ()
	{
		StartCoroutine ("RotateMe");
	}

	IEnumerator RotateMe ()
	{
		while (true) {
			transform.RotateAround (transform.position, Vector3.forward, rotationSpeed * Time.deltaTime * direction);
			yield return null;
		}
	}
}
