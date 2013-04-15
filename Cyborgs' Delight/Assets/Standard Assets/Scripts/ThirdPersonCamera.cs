using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float smooth = 3f;		// a public variable to adjust smoothing of camera motion
	Transform standardPos;			// the usual position for the camera, specified by a transform in the game 
	
	void Start()
	{
		// initialising references
		standardPos = GameObject.Find ("CamPos").transform;
		
	}
	
	void FixedUpdate ()
	{
		
		// return the camera to standard position and direction
		standardPos = GameObject.Find("CamPos").transform;
		transform.position = standardPos.position;	
		transform.forward = standardPos.forward;
		
	}
}
