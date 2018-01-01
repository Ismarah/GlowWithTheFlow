using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

	public GameObject particle1;
	public GameObject particle2;
	public GameObject particle3;
	public GameObject particle4;

	GameObject[] particles;

	void Start ()
	{
		particles = new GameObject[4];
		particles [0] = particle1;
		particles [1] = particle2;
		particles [2] = particle3;
		particles [3] = particle4;
	}

	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Instantiate (particles [Random.Range (0, 3)], collision.transform.position, Quaternion.identity);
	}

}
