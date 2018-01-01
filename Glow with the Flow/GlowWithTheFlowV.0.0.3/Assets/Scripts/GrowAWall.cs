using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAWall : MonoBehaviour
{
	public Vector2 mouseDown;
	public bool readyToDestroy;

	void Start ()
	{
		GameObject[] catapult = GameObject.FindGameObjectsWithTag ("Catapult");
		for (int i = 0; i < catapult.Length; i++) {
			catapult [i].GetComponent<Catapult> ().enabled = false;
		}
		GameObject[] barrel = GameObject.FindGameObjectsWithTag ("Barrel");
		for (int i = 0; i < barrel.Length; i++) {
			barrel [i].GetComponent<Barrel> ().enabled = false;
		}
		GameObject[] rotate = GameObject.FindGameObjectsWithTag ("Rotate");
		for (int i = 0; i < rotate.Length; i++) {
			rotate [i].GetComponent<Rotate> ().enabled = false;
		}
	}

	void Update ()
	{
		if (readyToDestroy)
			return;

		if (Input.GetMouseButtonDown (0)) {
			if (mouseDown == new Vector2 (0, 0)) {
			
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

				if (hit.collider == null) {
					mouseDown = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					transform.position = mouseDown;
				} else {
					return;
				}

			}
		}
		if (mouseDown != new Vector2 (0, 0)) {
			Vector3 mp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (mp.x > mouseDown.x) {
				this.transform.localScale = new Vector3 (new Vector2 (mp.x - mouseDown.x, mp.y - mouseDown.y).magnitude / 6.6f, 1, 1);
				RotateWallRight ();
			} else {
				this.transform.localScale = new Vector3 (-new Vector2 (mp.x - mouseDown.x, mp.y - mouseDown.y).magnitude / 6.6f, 1, 1);
				RotateWallLeft ();
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			if (mouseDown != new Vector2 (0, 0)) {

				GameObject[] catapult = GameObject.FindGameObjectsWithTag ("Catapult");
				for (int i = 0; i < catapult.Length; i++) {
					catapult [i].GetComponent<Catapult> ().enabled = true;
				}
				GameObject[] barrel = GameObject.FindGameObjectsWithTag ("Barrel");
				for (int i = 0; i < barrel.Length; i++) {
					barrel [i].GetComponent<Barrel> ().enabled = true;
				}
				GameObject[] rotate = GameObject.FindGameObjectsWithTag ("Rotate");
				for (int i = 0; i < rotate.Length; i++) {
					rotate [i].GetComponent<Rotate> ().enabled = true;
				}

				GameObject text = GameObject.FindGameObjectWithTag ("Dissolve");
				text.GetComponent<Dissolve> ().StartFading ();

				readyToDestroy = true;
			}
		}
	}

	void RotateWallRight ()
	{
		if (new Vector2 (Input.mousePosition.x - mouseDown.x, Input.mousePosition.y - mouseDown.y).magnitude > 1) {
			float degrees = (Mathf.Rad2Deg * Mathf.Acos (Vector2.Dot (Vector2.right, new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y) - mouseDown) / new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x - mouseDown.x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y - mouseDown.y).magnitude));
			if (Camera.main.ScreenToWorldPoint (Input.mousePosition).y < transform.position.y) {
				transform.localEulerAngles = new Vector3 (0, 0, -degrees);
			} else {
				transform.localEulerAngles = new Vector3 (0, 0, degrees);
			}
		}
	}

	void RotateWallLeft ()
	{
		if (new Vector2 (Input.mousePosition.x - mouseDown.x, Input.mousePosition.y - mouseDown.y).magnitude > 2) {
			float degrees = (Mathf.Rad2Deg * Mathf.Acos (Vector2.Dot (Vector2.right, new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y) - mouseDown) / new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x - mouseDown.x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y - mouseDown.y).magnitude));
			if (!float.IsNaN (degrees)) {
				if (Camera.main.ScreenToWorldPoint (Input.mousePosition).y < transform.position.y) {
					transform.localEulerAngles = new Vector3 (0, 0, 180 - degrees);
				} else {
					transform.localEulerAngles = new Vector3 (0, 0, -180 + degrees);
				}
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		if (readyToDestroy) {
			Destroy (this.gameObject);
		}
	}
}
