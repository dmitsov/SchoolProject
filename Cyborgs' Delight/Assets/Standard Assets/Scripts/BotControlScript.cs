using UnityEngine;
using System.Collections;


[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class BotControlScript : MonoBehaviour
{	
	public float animSpeed = 1.5f;				
	public float lookSmoother = 3f;				
	public bool useCurves;						

	
	private Animator anim;						
	private AnimatorStateInfo currentBaseState;	
	private AnimatorStateInfo layer2CurrentState;
	private CapsuleCollider col;
	

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");	
	static int jumpState = Animator.StringToHash("Base Layer.Jump");		
	static int jumpDownState = Animator.StringToHash("Base Layer.JumpDown");
	static int fallState = Animator.StringToHash("Base Layer.Fall");
	static int rollState = Animator.StringToHash("Base Layer.Roll");
	
	

	void Start ()
	{
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
	}
	
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");				
		anim.SetFloat("Speed", v);											
		anim.SetFloat("Direction", h); 						
		anim.speed = animSpeed;			
		
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);
		
	
		if (currentBaseState.nameHash == locoState){
			if(Input.GetButtonDown("Jump")){
				anim.SetBool("Jump", true);
			}
		}
		
		
		else if(currentBaseState.nameHash == jumpState){
			if(!anim.IsInTransition(0)){
				if(useCurves)
					col.height = anim.GetFloat("ColliderHeight");
				anim.SetBool("Jump", false);
			}
		}
		
		else if (currentBaseState.nameHash == jumpDownState){
			col.center = new Vector3(0, anim.GetFloat("ColliderY"), 0);
		}
		
		else if (currentBaseState.nameHash == fallState){
			col.height = anim.GetFloat("ColliderHeight");
		}
		
		else if (currentBaseState.nameHash == rollState){
			if(!anim.IsInTransition(0))
			{
				if(useCurves)
					col.height = anim.GetFloat("ColliderHeight");
				col.center = new Vector3(0, anim.GetFloat("ColliderY"), 0);
			}
		}
	}
}
