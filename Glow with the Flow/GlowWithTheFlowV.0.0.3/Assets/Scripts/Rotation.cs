using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

	Transform player;
	public bool playerInside;
	public bool playerClose;
	public float acceleration;
	public float shootSpeed;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;	
	}

	//	void OnTriggerEnter2D ()
	//	{
	//		playerClose = true;
	//	}
	//
	//	void OnTriggerExit ()
	//	{
	//		playerClose = false;
	//	}

	void Update ()
	{
//		if (!playerInside)
//			return;

		if (new Vector2 (this.transform.position.x - player.transform.position.x, this.transform.position.y - player.transform.position.y).magnitude >= 3) {
			playerClose = false;
		} else {
			playerClose = true;
		}

		//mouse held down
		if (Input.GetMouseButton (0) && playerClose) {
			AttachPlayer ();
		}
		//mouse release
		if (Input.GetMouseButtonUp (0) && playerInside) {
			DetachPlayer ();
		}
	}

	void AttachPlayer ()
	{
		player.GetComponent<Rigidbody2D> ().AddForce (player.GetComponent<Rigidbody2D> ().velocity * acceleration);
		player.GetComponent<DistanceJoint2D> ().enabled = true;
		player.GetComponent<DistanceJoint2D> ().connectedAnchor = transform.position;
		player.GetChild (0).GetComponent<Shrink> ().StopShrinking ();
		playerInside = true;


	}

	void DetachPlayer ()
	{
		player.GetComponent<DistanceJoint2D> ().enabled = false;
		player.GetComponent<Rigidbody2D> ().AddForce (player.GetComponent<Rigidbody2D> ().velocity * shootSpeed);
		player.GetChild (0).GetComponent<Shrink> ().ShrinkMe ();
		playerInside = false;
	}


}
