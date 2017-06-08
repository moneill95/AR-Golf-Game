using UnityEngine;
using System.Collections;

public class camControl1 : MonoBehaviour {

	//public Transform golfBall;
	public Transform target;
	private Vector3 offset;

	//public GameObject golfBallTarget;
	//private float speedmod =10.0f;
	//private Vector3 point;

	// Use this for initialization
	void Start () {

		//point = golfBallTarget.transform.position;
		//transform.LookAt (point);

		offset = new Vector3(-10.0f, 10.0f, 0.1f);
	}

	// Update is called once per frame
	void Update () {

		//GetComponent<Rigidbody>().velocity = new Vector3 (golfBall.GetComponent<Rigidbody>().velocity.x,golfBall.GetComponent<Rigidbody>().velocity.y, golfBall.GetComponent<Rigidbody>().velocity.z); //follow golfball

//		Transform.LookAt(0,0,golfBall.transform.position.z);

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


		transform.LookAt (target.transform.position);

	}

	void LateUpdate(){

		transform.position = target.transform.position + offset;

	}

}
