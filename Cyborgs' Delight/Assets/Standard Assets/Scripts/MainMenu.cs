using UnityEngine;
using System.IO;
using System.Collections;
using Maps;


public class MainMenu : MonoBehaviour {
	

	private bool isLoadMenu = false;
	
	
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	private float buttonLeftIndent;
	
	void Start () {
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonWidth = screenWidth * 0.2f;
		buttonHeight = screenHeight * 0.3f;
		buttonLeftIndent = (screenWidth - buttonWidth) * 0.5f;
		
		
	}
	
	void OnGUI(){
		
		if(!isLoadMenu){
			if(GUI.Button(new Rect(buttonLeftIndent, screenHeight * 0.1f, 
								buttonWidth, buttonHeight),"Start Game")){
			
				Application.LoadLevel("Level2");
			}
		
			if(GUI.Button(new Rect(buttonLeftIndent, screenHeight * 0.45f, 
								buttonWidth, buttonHeight),"Load Level")){
			
				isLoadMenu = true;
			}
		
		
			if(GUI.Button(new Rect(buttonLeftIndent, screenHeight * 0.8f, 
								buttonWidth, buttonHeight),"Quit Game")){
			
				Application.Quit();
			}
		} else {
			float topIndent = 0.1f;
			string[] lines = File.ReadAllLines("./Assets/Standard Assets/MapList.txt");
			foreach(string line in lines){
				if(GUI.Button(new Rect(buttonLeftIndent, screenHeight * topIndent, 
								buttonWidth * 0.5f, buttonHeight * 0.5f),line)){
					
					Application.LoadLevel(line);
				}
				topIndent += 0.2f;
			}
			
			
		}
		
	}
}
