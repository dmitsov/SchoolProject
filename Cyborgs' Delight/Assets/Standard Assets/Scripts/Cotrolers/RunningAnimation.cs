using UnityEngine;
using System.Collections;

public class RunningAnimation : MonoBehaviour {

	void StartRunnig(){
		FirstPersonMoveAround.startRunning += startRunning;
	}
	
	void StopRunning(){
		FirstPersonMoveAround.stopRunning += stopRunning;
	}
	

}

