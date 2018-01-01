using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePickup : MonoBehaviour
{
	public Transform player;
	public Transform growableWall;

	public GameObject[] animatorController;

	public GameObject animatorController1;
	public GameObject animatorController2;
	public GameObject animatorController3;
	public GameObject animatorController4;

	public float maxSize = 0.6f;
	public float minSize = 0.4f;

	public float speed;
	public float fuelAmount;

	float size;
	direction myDirection;

	enum direction
	{
		Up,
		Down
	}

	void Start ()
	{
		animatorController = new GameObject[4];
		size = transform.lossyScale.x;
		myDirection = direction.Up;
		animatorController [0] = animatorController1;
		animatorController [1] = animatorController2;
		animatorController [2] = animatorController3;
		animatorController [3] = animatorController4;
	}

	void Update ()
	{
		if (myDirection == direction.Up) {
			if (size < maxSize) {
				size = size + 0.001f * speed * Time.deltaTime; 
			
			} else if (size > maxSize) {
				myDirection = direction.Down;
			}
		} else if (myDirection == direction.Down) {
			if (size > minSize) {
				size = size - 0.001f * speed * Time.deltaTime; 

			} else if (size < minSize) {
				myDirection = direction.Up;
			}
		}

		transform.localScale = new Vector2 (size, size);


	}

	void OnTriggerEnter2D ()
	{
		if (this.tag != "Special") {
			player.GetComponent<PlayerScript> ().CollectibleFound ();
			player.GetChild (0).GetComponent<Shrink> ().GrowMe (fuelAmount);
			var animations = Instantiate (animatorController [Random.Range (0, 3)], this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		} else {
			var animations = Instantiate (animatorController [Random.Range (0, 3)], this.transform.position, Quaternion.identity);
			Instantiate (growableWall, new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0), Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
