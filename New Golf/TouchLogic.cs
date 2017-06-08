using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLogic : MonoBehaviour {

	public static int currTouch = 0;
	private Ray ray;
	private RaycastHit rayHitInfo = new RaycastHit ();

	
	// Update is called once per frame
	void Update () {

		if (Input.touches.Length <= 0) {
			// no touches
		} else {
			for (int i = 0; i <Input.touchCount; i++)
			{
				currTouch = i;

				if(this.GetComponent<GUITexture>() != null && (this.GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position)))
				{
					if (Input.GetTouch (i).phase == TouchPhase.Began) {

						this.SendMessage ("OnTouchBegan");
					}

					if (Input.GetTouch (i).phase == TouchPhase.Ended) {

						this.SendMessage ("OnTouchEnded");
					}

					if (Input.GetTouch (i).phase == TouchPhase.Moved) {

						this.SendMessage ("OnTouchedMove");
					}

				}

				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					this.SendMessage ("OnTouchBeganAnywhere");
				}
				if(Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					this.SendMessage ("OnTouchEndedAnywhere");
				}
				if(Input.GetTouch(i).phase == TouchPhase.Moved)
				{
					this.SendMessage ("OnTouchMovedAnywhere");
				}
				if(Input.GetTouch(i).phase == TouchPhase.Stationary)
				{
					this.SendMessage ("OnTouchStayedAnywhere");
				}

				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
					if(Physics.Raycast(ray, out rayHitInfo))
					{
						rayHitInfo.transform.gameObject.SendMessage ("OnTouchedBegan3D");
					}
				}
			}
		}
	}
}

		
