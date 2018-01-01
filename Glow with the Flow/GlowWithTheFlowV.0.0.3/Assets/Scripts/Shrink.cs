using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{

	public float shrinkSpeed;
	Vector2 size;

	void Start ()
	{
		size = new Vector2 ();
	}

	public void ShrinkMe ()
	{
		size = transform.localScale;
		StartCoroutine ("Shrinking");
	}

	IEnumerator Shrinking ()
	{
		while (this.transform.localScale.x > 0) {
			size.x -= shrinkSpeed * Time.deltaTime;
			size.y -= shrinkSpeed * Time.deltaTime;
			transform.localScale = new Vector2 (size.x, size.y); 
			yield return null;
		}
		if (transform.localScale.x <= 0) {
			transform.parent.GetComponent<PlayerScript> ().NoFuel ();
		}
	}

	public void StopShrinking ()
	{
		StopCoroutine ("Shrinking");
	}

	public void GrowMe (float amount)
	{
		StopCoroutine ("Shrinking");
		float x = transform.localScale.x + amount;
		float y = transform.localScale.y + amount;
		if (x > 1)
			x = 1;
		if (y > 1)
			y = 1;
		transform.localScale = new Vector2 (x, y);
		ShrinkMe ();
	}
		
}
