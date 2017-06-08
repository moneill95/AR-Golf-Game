using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballControl : MonoBehaviour {

	public Transform putterObject;
	public float xForce;
	public Transform Arrowpos;
	public int StrokeNo;
	public GameObject Arrow;
	private int hit;
	public GameObject shotButton;
	public GameObject mainCamera;
	//public GameObject cameraBehindHole;
	public GameObject wallinFrontofCamera;
	public string nextHole;
	public Slider ballPower;

	public GameObject ARMainCamera;
	//public GameObject ARCameraBehindHole;



	// Use this for initialization
	void Start () {

		//cameraBehindHole.SetActive (false);
		//ARCameraBehindHole.SetActive (false);

	


	}
	
	// Update is called once per frame


	void Update () {




		xForce = ballPower.value;

		if (Input.GetKeyDown ("space")) {
			GetComponent<Rigidbody> ().AddRelativeForce (xForce, 0, 0);
			Debug.Log(ballPower.value);
		}

		if (Input.GetKeyDown ("r")) {
			Debug.Log ("Respawn Putter");
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			//Instantiate (putterObject, transform.position, putterObject.rotation);

			GetComponent<Transform>().eulerAngles  = new Vector3 (0,0,0);
			Arrow.GetComponent<Transform> ().position = transform.position;
			//mainCamera.GetComponent<Transform> ().position = transform.position;
			Debug.Log("z value = " + GetComponent<Transform>().transform.rotation.z);

		}
			

		if (GetComponent<Rigidbody> ().velocity.magnitude > 0.2) {
			hit = 1;
			print("hit True");
			Arrow.SetActive (false);
			shotButton.SetActive (false);

		}

		if (GetComponent<Rigidbody> ().velocity.magnitude == 0  && hit == 1 ) {
			{
				print ("slow ball");
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

				//if (GetComponent<Rigidbody> ().velocity.magnitude == 0) {
					GetComponent<Transform>().eulerAngles  = new Vector3 (0,0,0);
					print ("hit = 0");
					hit = 0;
					Arrow.SetActive (true);
				shotButton.SetActive (true);

				}
			}



		

		if (Input.GetKey ("a")) {
			transform.Rotate (0, 1, 0);
		}

		if (Input.GetKey ("d")) {
			transform.Rotate (0, -1, 0);
		}

		if (Input.GetKey ("w")) {
			xForce += 5;
		}

		if (Input.GetKey ("s")) {
			xForce -= 5;
		}

		if (xForce < 20) {
			xForce = 20;
		}

		if (xForce > 700) {
			xForce = 700;
		}
	
	}



	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Hole") {
			Debug.Log ("In the hooooooole");
			Debug.Log (ScoreManager.Stroke);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			shotButton.SetActive (false);
			Arrow.SetActive (false);
			StartCoroutine (delayLoad ());
		}
			if (other.name == "HoleStartingPosition (1)") {
				Debug.Log ("Change Camera Position");
				//mainCamera.transform.Rotate (0, 180, 0);
				mainCamera.SetActive (false);
				//cameraBehindHole.SetActive (true);
				wallinFrontofCamera.GetComponent<Renderer>().enabled = false;
			if (turnARmodeOn.isARon == 1) {
				//ARCameraBehindHole.SetActive (true);
				ARMainCamera.SetActive (false);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "HoleStartingPosition (1)") {
			Debug.Log ("Change Camera Back");
			mainCamera.SetActive (true);
			//cameraBehindHole.SetActive (false);
			wallinFrontofCamera.GetComponent<Renderer>().enabled = true;


			if (turnARmodeOn.isARon == 1) {
			//	ARCameraBehindHole.SetActive (false);
				ARMainCamera.SetActive (true);
			}

		
		}
	}

	public void shotBall(){
		GetComponent<Rigidbody> ().AddRelativeForce (xForce, 0, 0);
		Debug.Log(ballPower.value);
		ScoreManager.AddStroke(StrokeNo);

	}

	public void moveLeft()
	{
		transform.Rotate (0, -1 ,0);
		//mainCamera.transform.Rotate (0, -1 ,0);

	}

	public void moveRight()
	{
		transform.Rotate (0, 1, 0);

	}

	/*public void moveArrowLeft()
	{
		Arrowpos.GetComponent<Transform> ().transform.Rotate (0, -1, 0);

	}

	public void moveArrowRight()
	{
		Arrowpos.GetComponent<Transform> ().transform.Rotate (0, 1, 0);

	}*/

	void ReshootBall()
	{
		if (GetComponent<Rigidbody> ().velocity.magnitude < 0.1) {
			print("Slow Speed");
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

		}


	}


	IEnumerator delayLoad()
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (nextHole);
	}

}