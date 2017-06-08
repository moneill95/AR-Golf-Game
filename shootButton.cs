using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shootButton : MonoBehaviour {

	public Slider ballPower;
	public float xForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void shootBall()
	{
		xForce = ballPower.value;
		GetComponent<Rigidbody> ().AddRelativeForce (xForce, 0, 0);
		Debug.Log(ballPower.value);
	}
}
