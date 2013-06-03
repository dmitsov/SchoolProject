using UnityEngine;
using System.Collections;

public class MouseMove: MonoBehaviour {
	
	public enum RotateAxis{MouseX = 1, MouseY = 2}
	public RotateAxis RotXY = RotateAxis.MouseX | RotateAxis.MouseY;
	
	public float SensitivityX = 400f;
	public float MinimumX = -360f;
	public float MaximumX = 360f;
	private float RotationX = 0f;
	
	public float SensitivityY = 400f;
	public float MinimumY = -50f;
	public float MaximumY = 50f;
	private float RotationY = 0f;
	
	public Quaternion OriginalRotation;
		
	void Start () {
		OriginalRotation = transform.localRotation;
	}

	void Update () {
		
		if(RotXY == RotateAxis.MouseX){
			RotationX += Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime;
			RotationX = ClampAngle (RotationX, MinimumX, MaximumX);
			Quaternion XQuaternion = Quaternion.AngleAxis(RotationX, Vector3.up);	
			transform.localRotation = OriginalRotation * XQuaternion;
			
		}
		
		if(RotXY == RotateAxis.MouseY){
			RotationY -= Input.GetAxis("Mouse Y") * SensitivityY * Time.deltaTime;
			RotationY = ClampAngle (RotationY,MinimumY,MaximumY);
			Quaternion YQuaternion = Quaternion.AngleAxis(RotationY, Vector3.right);
			
			transform.localRotation = OriginalRotation * YQuaternion;
		}

	}
	
	
	
	public static float ClampAngle(float Angle, float Min, float Max){
		if(Angle < -360){
			Angle += 360;
		}	
		
		if(Angle > 360){
			Angle -= 360;
		}
		
		return Mathf.Clamp(Angle,Min,Max);
		
	}
}
