using UnityEngine;
using System.Collections;

public class CamPos : MonoBehaviour {
	private Transform posModel;
	
	void Start () {
		posModel = GameObject.Find ("Dude").transform;
	}

	void Update () {
		Vector3 camPos = posModel.position;
		float x = camPos.x;
		float y = camPos.y + 2.5f;
		float z = camPos.z + 4f;
		
		transform.position = new Vector3(x,y,z);
		
		
	}
}
