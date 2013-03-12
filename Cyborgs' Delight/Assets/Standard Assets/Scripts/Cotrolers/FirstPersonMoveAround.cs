using UnityEngine;
using System.Collections;

public class FirstPersonMoveAround : MonoBehaviour {
	
	public float MoveSpeed = 10f;
	
	private int runSend = 0;
	
	public delegate void StartRunningHandler(bool hasStartedWalking);
	public delegate void StopRunningHandler(bool hasStopedWalking);
	
	public static event StartRunningHandler startRunning;
	public static event StopRunningHandler stopRunning;
	
	// Use this for initialization
	void Start () {
	
	} 
	
	// Update is called once per frame
	void Update () {
		bool isRunning = false;
		
		if(Input.GetKey (KeyCode.W) == true || Input.GetKey (KeyCode.UpArrow) == true 
			|| Input.GetKey (KeyCode.S) == true || Input.GetKey (KeyCode.DownArrow) == true){
			
			float MoveForward = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
			transform.Translate(Vector3.forward * MoveForward);
			isRunning = true;
		
		}
		
		
		if(Input.GetKey (KeyCode.A) == true || Input.GetKey (KeyCode.LeftArrow) == true || 
			Input.GetKey (KeyCode.D) == true || Input.GetKey (KeyCode.RightArrow) == true){
			
			float MoveRight = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;
			transform.Translate (Vector3.right * MoveRight);
			
		}
		
		if(isRunning && runSend == 0){
			StartRunningHandler(true);
			runSend++;
		}
		
		if(!isRunning && runSend == 1){
			StopRunningHandler(true);
			runSend = 0;
		}
	}
}
