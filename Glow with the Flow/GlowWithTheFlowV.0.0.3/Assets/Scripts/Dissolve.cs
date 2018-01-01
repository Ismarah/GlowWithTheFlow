using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissolve : MonoBehaviour
{

	Transform player;
	public int startAmount;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;	
	}


	void Update ()
	{
		if (player.GetComponent<PlayerScript> ().collectiblesFound == startAmount) {
			StartCoroutine (FadeOut ());
		}
	}

	public IEnumerator FadeOut ()
	{
		float start = 1f;
		Text text = this.GetComponent<Text> ();
		text.color = new Color (text.color.r, text.color.g, text.color.b, 1);
		while (text.color.a > 0.0f) {
			text.color = new Color (text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / start));
			yield return null;
		}
	}

	public void StartFading ()
	{
		StartCoroutine (FadeOut ());
	}

}
