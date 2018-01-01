using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{

	Rigidbody2D rb;
	Vector2 mouseDown;
	Vector2 mouseUp;
	public float shootSpeed;
	DistanceJoint2D distanceJoint;
	public int collectiblesFound;
	public float maxSpeed;
	int pickUpAmount;
	public GameObject success;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		distanceJoint = GetComponent<DistanceJoint2D> ();
		CountPickUps ();
	}

	void FixedUpdate ()
	{
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
	}

	public void CollectibleFound ()
	{
		StopCoroutine ("StopMoving");
		collectiblesFound += 1;
		if (collectiblesFound == pickUpAmount) {
			//gewonnen!!
			var succ = (GameObject)Instantiate (success, success.transform.position, Quaternion.identity);
			succ.transform.parent = GameObject.FindGameObjectWithTag ("Canvas").transform;
			Invoke ("LoadNextScene", 1);
		}
	}

	void LoadNextScene ()
	{
		if (SceneManager.GetActiveScene ().name == "Level11") {
			SceneManager.LoadScene ("Title");			
		} else {
			SceneManager.LoadScene (GameObject.FindGameObjectWithTag ("Info").GetComponent<LevelData> ().NextLevel ());			
		}

	}

	public void NoFuel ()
	{
		StartCoroutine ("StopMoving");	
	}

	IEnumerator StopMoving ()
	{
		while (rb.velocity.magnitude > 0) {
			rb.drag += 1;

			yield return null;
		}

		if (rb.velocity.magnitude <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	void CountPickUps ()
	{
		pickUpAmount = GameObject.FindGameObjectWithTag ("Info").GetComponent<LevelData> ().pickUpCount;
	}

}
