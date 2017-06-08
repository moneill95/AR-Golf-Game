using UnityEngine;
using System.Collections;

public class moveArrow : MonoBehaviour {

	void OnMouseDrag()
	{
		transform.Rotate (0, 0, -1);
		
	}
}
