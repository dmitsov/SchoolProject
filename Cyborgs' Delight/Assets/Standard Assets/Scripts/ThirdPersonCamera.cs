using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float smooth = 3f;		// a public variable to adjust smoothing of camera motion
	Transform standardPos;			// the usual position for the camera, specified by a transform in the game 
	
	void Start()
	{
		// initialising references
		standardPos = GameObject.Find ("Dude").transform;
		
	}
	
	void FixedUpdate ()
	{
		Vector3 pos = standardPos.position - standardPos.forward*2.5f;
		
		pos.y += standardPos.localScale.y;
		transform.position = pos;		
		transform.rotation = standardPos.rotation;
		
	}
}
