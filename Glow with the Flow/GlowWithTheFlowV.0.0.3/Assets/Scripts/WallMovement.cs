using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{

	bool movingUp;
	public Transform upperPoint;
	public Transform lowerPoint;

	public float speed;

	void Update ()
	{
		if (!movingUp) {
			transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime);
			if (transform.localPosition.y <= lowerPoint.transform.localPosition.y) {
				movingUp = true;
			}
		} else {
			transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime);
			if (transform.localPosition.y >= upperPoint.transform.localPosition.y) {
				movingUp = false;
			}
		}
	}
}
