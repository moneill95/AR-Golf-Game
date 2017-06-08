using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballControl1 : MonoBehaviour {

	//public Transform putterObject;
	public float xForce;
	public Transform Arrowpos;
	public int StrokeNo;
	public GameObject Arrow;
	private int hit;
	public GameObject shotButton;
	//public GameObject mainCamera;
	//public GameObject aimCamera;
	//public GameObject cameraBehindHole;
	//public GameObject wallinFrontofCamera;
	public string nextHole;
	public Slider ballPower;
	public GameObject Checkpoint;
	public AudioClip Hit;
	private AudioSource source;

	//public GameObject ARMainCamera;
	//public GameObject ARCameraBehindHole;

	void Awake(){
		source = GetComponent<AudioSource> ();

	}

	// Use this for initialization
	void Start () {

		//cameraBehindHole.SetActive (false);
		//ARCameraBehindHole.SetActive (false);
		//mainCamera.SetActive(true);
		//aimCamera.SetActive (false);




	}

	// Update is called once per frame


	void Update () {




		xForce = ballPower.value; // value for ball power used in ShotBall()

		if (Input.GetKeyDown ("space")) { //controls for testing on PC
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


		if (GetComponent<Rigidbody> ().velocity.magnitude > 0.2) { // if balls magnitude was greater than 0.2 player couldnt hit ball
			hit = 1;
			print("hit True");
			Arrow.SetActive (false);
			//aimCamera.SetActive (false);
			//mainCamera.SetActive (true);
			shotButton.SetActive (false);

		}

		if (GetComponent<Rigidbody> ().velocity.magnitude == 0  && hit == 1 ) { // once ball has stopped balls rotation is reset to zero on all axis and player is allowed to hit the ball again
			{
				print ("slow ball");
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

				//if (GetComponent<Rigidbody> ().velocity.magnitude == 0) {
				GetComponent<Transform>().eulerAngles  = new Vector3 (0,0,0);
				print ("hit = 0");
				hit = 0;
				Arrow.SetActive (true);
				shotButton.SetActive (true);
				//aimCamera.SetActive (true);
				//mainCamera.SetActive (false);


			}
		}





		if (Input.GetKey ("a")) {// pc controls for testing
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

		if (xForce < 20) { // if ball power was less than 20 ball power was set to 20
			xForce = 20;
		}

		if (xForce > 700) {  //if ball power was greater than 700 ball power was set to 700
			xForce = 700;
		}

	}


	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Outside") { // if ball fell off map was reset to starting position of the hole
			Debug.Log ("Off Map");
			transform.position = Checkpoint.transform.position;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			GetComponent<Rigidbody> ().AddRelativeForce (0, 0, 0);
			GetComponent<Transform>().eulerAngles  = new Vector3 (0,0,0);

		}



//	}


//	void OnTriggerStay(Collider other)
//	{
		if (other.tag == "Hole") { // ball enters hole collider,loads next hole by starting coroutine delayLoad() shown below and adds no of strokes to final stroke count
			Debug.Log ("In the hooooooole");
			Debug.Log (ScoreManager.Stroke);
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			shotButton.SetActive (false);
			Arrow.SetActive (false);
			StartCoroutine (delayLoad ());
			FinalScore.StrokeCount += ScoreManager.Stroke;
			Debug.Log ("FinalStroke" + FinalScore.StrokeCount);
			//aimCamera.SetActive (false);
			//mainCamera.SetActive (true);
		}
	//	if (other.name == "HoleStartingPosition (1)") {
			Debug.Log ("Change Camera Position");
			//mainCamera.transform.Rotate (0, 180, 0);
			//mainCamera.SetActive (false);
			//cameraBehindHole.SetActive (true);
			//wallinFrontofCamera.GetComponent<Renderer>().enabled = false;
			//if (turnARmodeOn.isARon == 1) {
				//ARCameraBehindHole.SetActive (true);
				//ARMainCamera.SetActive (false);
			//}
	//	}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "HoleStartingPosition (1)") {
			Debug.Log ("Change Camera Back");
			//mainCamera.SetActive (true);
			//cameraBehindHole.SetActive (false);
			//wallinFrontofCamera.GetComponent<Renderer>().enabled = true;


			//if (turnARmodeOn.isARon == 1) {
				//	ARCameraBehindHole.SetActive (false);
			//	ARMainCamera.SetActive (true);
			//}


		}
	}

	public void shotBall(){  // used for the shoot button, when pressed moves ball
		GetComponent<Rigidbody> ().AddRelativeForce (xForce, 0, 0);
		Debug.Log(ballPower.value);
		ScoreManager.AddStroke(StrokeNo);
		source.PlayOneShot (Hit);

	}




	void ReshootBall() // when balls magnitude is less than 0.1 it slows velocity to 0
	{
		if (GetComponent<Rigidbody> ().velocity.magnitude < 0.1) {
			print("Slow Speed");
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

		}


	}


	IEnumerator delayLoad() // loads next hole
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (nextHole);
	}

}