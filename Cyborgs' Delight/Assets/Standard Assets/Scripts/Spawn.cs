using UnityEngine;
using System.Collections;



public class SpawnScript : MonoBehaviour {
	
	private bool justConnectedToServer = false;

	public bool amIPlayer1 = false;
	public bool amIPlayer2 = false;



    private Rect chosePlayer;
    private string chosePlayerWindowTitle = "Player Selection";
	private int chosePlayerWindowWidth = 330;
	private int chosePlayerWindowHeight = 100;
    private int chosePlayerLeftIndent;
    private int chosePlayerTopIndent;
	private int buttonHeight = 40;
	
	public Transform Player1;	
	public Transform Player2;

	private GameObject Player1Point;
	private GameObject Player2Point;
	
	void OnConnectedToServer ()
	{
		justConnectedToServer = true;	
	}
	
	
	
	void chosePlayerWindow (int windowID)
	{
		
		if(GUILayout.Button("Player1", GUILayout.Height(buttonHeight)))
		{
			amIPlayer1 = true;
			
			justConnectedToServer = false;
			
			SpawnPlayer1();
		}
		
		
		if(GUILayout.Button("Join Blue Team", GUILayout.Height(buttonHeight)))
		{
			amIPlayer2 = true;
			
			justConnectedToServer = false;
			
			SpawnPlayer2();
		}
	}
	
	
	void OnGUI()
	{
		//If the player has just connected to the server then draw the 
		//Join Team window.
		
		if(justConnectedToServer == true)
		{
            chosePlayerLeftIndent = Screen.width / 2 - chosePlayerWindowWidth / 2;

            chosePlayerTopIndent = Screen.height / 2 - chosePlayerWindowHeight / 2;

            chosePlayer = new Rect(chosePlayerLeftIndent, chosePlayerTopIndent,
                                    chosePlayerWindowWidth, chosePlayerWindowHeight);

            chosePlayer = GUILayout.Window(0, chosePlayer, chosePlayerWindow,
                                            chosePlayerWindowTitle);
		}
	}
	
	
	void SpawnPlayer1 ()
	{
	
		
		 Player1Point = GameObject.Find("SpawnPlayer1");
		
		Network.Instantiate(Player1Point, Player1Point.transform.position,
		                    Player1Point.transform.rotation, 0);
	}
	
	
	
	void SpawnPlayer2 ()
	{
		
		Player2Point = GameObject.Find("SpawnPlaye2");	
		
		Network.Instantiate(Player2Point, Player2Point.transform.position,
		                   Player2Point.transform.rotation, 1);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
