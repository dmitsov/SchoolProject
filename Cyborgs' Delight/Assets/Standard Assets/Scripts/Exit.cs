using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	public enum LevelExit{
		MAZELEVEL, MAINMENU
	}
	
	
	public LevelExit exitOpt = LevelExit.MAINMENU | LevelExit.MAZELEVEL;
	GameObject dude;

	
	void Start () {
		dude = GameObject.Find("Dude");
	}
	

	void Update () {
		float x1 = transform.position.x + transform.localScale.x * 0.5f;
		float y1 = transform.position.y + transform.localScale.y * 0.5f;
		float z1 = transform.position.z + transform.localScale.z * 0.5f;
		
		float x2 = transform.position.x - transform.localScale.x * 0.5f;
		float y2 = transform.position.y - transform.localScale.y * 0.5f;
		float z2 = transform.position.z - transform.localScale.z * 0.5f;
		
		float dx = dude.transform.position.x;
		float dy = dude.transform.position.y;
		float dz = dude.transform.position.z;
		
		
		if(IsBetween(x1,x2,dx) && IsBetween(y1,y2,dy) && IsBetween(z1,z2,dz)){
			
			 	if(exitOpt == LevelExit.MAINMENU) Application.LoadLevel("Main Menu");
				if(exitOpt == LevelExit.MAZELEVEL) Application.LoadLevel("MazeLevel");				 
				
			
		}
	}
	
	private bool IsBetween(float x1, float x2, float pos){
		return (x1 > pos) && (x2 < pos);
	}
}
