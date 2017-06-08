using UnityEngine;
using System.Collections;

public class camControl : MonoBehaviour {

	public Transform golfBall;

	//public GameObject golfBallTarget;
	//private float speedmod =10.0f;
	//private Vector3 point;

	// Use this for initialization
	void Start () {

		//point = golfBallTarget.transform.position;
		//transform.LookAt (point);
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody>().velocity = new Vector3 (golfBall.GetComponent<Rigidbody>().velocity.x,golfBall.GetComponent<Rigidbody>().velocity.y, golfBall.GetComponent<Rigidbody>().velocity.z); //follow golfball
		//GetComponent<Transform>().position = new Vector3 (golfBall.GetComponent<Rigidbody>().velocity.x,golfBall.GetComponent<Rigidbody>().velocity.y, golfBall.GetComponent<Rigidbody>().velocity.z); //follow golfball
		/*if (Input.GetAxis("Mouse ScrollWheel") > 0) //Camera zoom 
			{
				//GetComponent<Camera>().fieldOfView = 1;
				GetComponent<Camera>().transform.Rotate (1, 0, 0);
			}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{
				//GetComponent<Camera>().fieldOfView += 1;
				GetComponent<Camera>().transform.Rotate (-1, 0, 0);
			}

*/
		//transform.RotateAround (point, new Vector3 (0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedmod);
	
	}
}
