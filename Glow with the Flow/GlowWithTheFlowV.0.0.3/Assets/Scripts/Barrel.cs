using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
	Transform player;
	public bool playerInside;
	public float force;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update ()
	{
		if (!playerInside)
			return;
		
		if (Input.GetMouseButtonDown (0)) {
			player.GetComponent<Rigidbody2D> ().AddForce (this.transform.right * force);
			playerInside = false;
			player.GetChild (0).GetComponent<Shrink> ().ShrinkMe ();
		}
	}

	void OnTriggerEnter2D ()
	{
		if (!playerInside) {
			StartCoroutine (SuckInPlayer ());
			player.GetChild (0).GetComponent<Shrink> ().StopShrinking ();
		}
	}

	IEnumerator SuckInPlayer ()
	{
		while (transform.position != player.position) {
			player.position = Vector2.MoveTowards (player.position, transform.position, 5 * Time.deltaTime);
			player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			yield return null;
		}
		if (transform.position == player.position) {
			playerInside = true;
		}
	}
}
