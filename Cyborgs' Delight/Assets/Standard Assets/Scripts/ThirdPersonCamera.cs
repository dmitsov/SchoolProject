using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float smooth = 3f;		
	Transform standardPos;			
	
	void Start(){
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
