using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : TouchLogic {

	public float rotateSpeed = 10.0f;
	public int invertPitch = 1;

	private float pitch = 0.0f;
	float yaw = 0.0f;

	void OnTouchMovedAnywhere() // touch controls to aim ball
	{
		pitch -= Input.GetTouch (0).deltaPosition.y * rotateSpeed * invertPitch * Time.deltaTime;
		yaw -= Input.GetTouch (0).deltaPosition.x * rotateSpeed * invertPitch * Time.deltaTime;




		this.transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		pitch = Mathf.Clamp (pitch, -5f, 5f); // doesnt allow to move up or down on y axis after 5 units each way
}
}
