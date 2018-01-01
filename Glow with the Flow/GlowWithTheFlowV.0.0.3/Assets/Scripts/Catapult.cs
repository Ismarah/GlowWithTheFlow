using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{

	Transform player;
	Vector2 mouseDown;
	Vector2 mouseUp;
	public bool playerInside;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;	
	}

	void Update ()
	{
		if (!playerInside)
			return;

		if (Input.GetMouseButtonDown (0)) {
			mouseDown = Input.mousePosition;
			StartCoroutine ("PointInDirection");
		}

		if (Input.GetMouseButtonUp (0)) {
			if (mouseDown != Vector2.zero) {
				mouseUp = Input.mousePosition;
				if (new Vector2 (mouseUp.x - mouseDown.x, mouseUp.y - mouseDown.y).magnitude < 1) {
					mouseUp = Vector2.zero;
					mouseDown = Vector2.zero;
				} else {
					ShootPlayer ();
				}
			}
		}
	}

	void ShootPlayer ()
	{
		if (mouseUp != mouseDown) {
			this.GetComponent<Rotate> ().StartCoroutine ("RotateMe");
			player.GetComponent<Rigidbody2D> ().simulated = true;
			player.GetComponent<Rigidbody2D> ().gravityScale = 0;
			Vector2 force = new Vector2 (mouseDown.x - mouseUp.x, mouseDown.y - mouseUp.y);
			player.GetComponent<Rigidbody2D> ().AddForce (force * player.GetComponent<PlayerScript> ().shootSpeed);
			player.GetChild (0).GetComponent<Shrink> ().ShrinkMe ();
			Invoke ("SetPlayerInside", 1);
			mouseUp = Vector2.zero;
			mouseDown = Vector2.zero;
		}
	}

	void SetPlayerInside ()
	{
		playerInside = false;
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

	IEnumerator PointInDirection ()
	{
		while (!Input.GetMouseButtonUp (0)) {
			if (new Vector2 (Input.mousePosition.x - mouseDown.x, Input.mousePosition.y - mouseDown.y).magnitude > 1) {
				GetComponent<Rotate> ().StopCoroutine ("RotateMe");

				float angle = AngleBetweenVector2 (new Vector2 (Input.mousePosition.x - mouseDown.x, Input.mousePosition.y - mouseDown.y), Vector2.right);
				transform.localEulerAngles = new Vector3 (0, 0, angle);

			}
			yield return null;
		}
	}

	float AngleBetweenVector2 (Vector2 vec1, Vector2 vec2)
	{
		Vector2 difference = vec2 - vec1;
		float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
		return Vector2.Angle (Vector2.right, difference) * sign;
	}

}
