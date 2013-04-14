using UnityEngine;
using System.Collections;

// This is the games' Multiplayer. Work in progress.

public class Multiplayer : MonoBehaviour {
	private string conectToIP = "127.0.0.1";	
	private int conectionPort = 26500;
	private string ipAddress;
	private string port;
	private bool useNAT = false;
	public string playerName;
	public string serverName;
	public string serverNameForClient;
	private bool iWantToSetupAServer = false;
	private bool iWantToConnectToAServer = false;
	
	private Rect conectionWindow;
	private int conectionWindowWidth = 400;
	private int conectionWindowHeight = 200;
	private int buttonHeight = 60;
	private int leftIndent;
	private int topIndent;
	
	private bool showExitWindow = false;
	
	private Rect serverExitWindow;
	private int  serverExitWindowHeight = 150;
	private int  serverExitWindowWidth = 300;
	private int serverExitWindowLeftIndent = 10;
	private int serverExitWindowTopIndent = 10;

    private Rect clientExitWindow;
    private int clientExitWindowHeight = 150;
    private int clientExitWindowWidth = 300;
    private int clientExitWindowLeftIndent = 10;
    private int clientExitWindowTopIndent = 10;
	
	

	void Start () {
        serverName = PlayerPrefs.GetString("serverName");

        if (serverName == "")
        {
            serverName = "Server";
        }

        playerName = PlayerPrefs.GetString("playerName");

        if (playerName == "")
        {
            playerName = "Player";
        }
	}
	
	
	void Update () {
	
	}



    void ConnectWindow(int windowID)
    {

        GUILayout.Space(15);


    
        if (iWantToSetupAServer == false && iWantToConnectToAServer == false)
        {
            if (GUILayout.Button("Setup a server", GUILayout.Height(buttonHeight)))
            {
                iWantToSetupAServer = true;
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Connect to a server", GUILayout.Height(buttonHeight)))
            {
                iWantToConnectToAServer = true;
            }

            GUILayout.Space(10);

            if (Application.isWebPlayer == false && Application.isEditor == false)
            {
                if (GUILayout.Button("Exit Prototype", GUILayout.Height(buttonHeight)))
                {
                    Application.Quit();
                }
            }
        }


        if (iWantToSetupAServer == true)
        {
            GUILayout.Label("Enter a name for your server");
            serverName = GUILayout.TextField(serverName);

            GUILayout.Space(5);
         
            GUILayout.Label("Server Port");
            conectionPort = int.Parse(GUILayout.TextField(conectionPort.ToString()));
            GUILayout.Space(10);

            if (GUILayout.Button("Start my own server", GUILayout.Height(30)))
            {

                Network.InitializeServer(2, conectionPort, useNAT);
                PlayerPrefs.SetString("serverName", serverName);
                iWantToSetupAServer = false;
            }

            if (GUILayout.Button("Go Back", GUILayout.Height(30)))
            {
                iWantToSetupAServer = false;
            }
        }


        if (iWantToConnectToAServer == true)
        {
          
            GUILayout.Label("Enter your player name");

            playerName = GUILayout.TextField(playerName);


            GUILayout.Space(5);

            GUILayout.Label("Type in Server IP");

            conectToIP = GUILayout.TextField(conectToIP);

            GUILayout.Space(5);


            GUILayout.Label("Server Port");

            conectionPort = int.Parse(GUILayout.TextField(conectionPort.ToString()));

            GUILayout.Space(5);


            if (GUILayout.Button("Connect", GUILayout.Height(25)))
            {
                if (playerName == "")
                {
                    playerName = "Player";
                }

                if (playerName != "")
                {
                 
                    Network.Connect(conectToIP, conectionPort);

                    PlayerPrefs.SetString("playerName", playerName);
                }
            }

            GUILayout.Space(5);

            if (GUILayout.Button("Go Back", GUILayout.Height(25)))
            {
                iWantToConnectToAServer = false;
            }

        }

    }


    void ServerExitWindow(int windowID)
    {
        GUILayout.Label("Server name: " + serverName);



        GUILayout.Label("Numner of players connected: " + Network.connections.Length);



        if (Network.connections.Length >= 1)
        {
            GUILayout.Label("Ping: " + Network.GetAveragePing(Network.connections[0]));
        }


        if (GUILayout.Button("Shutdown server"))
        {
            Network.Disconnect();
        }
    }



    void ClientExitWindow(int windowID)
    {
      
        GUILayout.Label("Connected to server: " + serverName);
        GUILayout.Label("Ping; " + Network.GetAveragePing(Network.connections[0]));

        GUILayout.Space(7);

        if (GUILayout.Button("Disconnect", GUILayout.Height(25)))
        {
            Network.Disconnect();
        }

        GUILayout.Space(5);

        if (GUILayout.Button("Return To Game", GUILayout.Height(25)))
        {
            showExitWindow= false;
        }
    }


    void OnDisconnectedFromServer()
    {      
        Application.LoadLevel(Application.loadedLevel);
    }


    void OnPlayerDisconnected(NetworkPlayer networkPlayer)
    {
        Network.RemoveRPCs(networkPlayer);
        Network.DestroyPlayerObjects(networkPlayer);
    }


    void OnPlayerConnected(NetworkPlayer networkPlayer)
    {
        networkView.RPC("TellPlayerServerName", networkPlayer, serverName);
    }



    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            leftIndent = Screen.width / 2 - conectionWindowWidth / 2;
            topIndent = Screen.height / 2 - conectionWindowHeight / 2;
            conectionWindow = new Rect(leftIndent, topIndent, conectionWindowWidth,
                                            conectionWindowHeight);

            conectionWindow = GUILayout.Window(0, conectionWindow, ConnectWindow,
                                                   	"Cyborgs'delight");
        }


  

        if (Network.peerType == NetworkPeerType.Server)
        {
         

            serverExitWindow = new Rect(serverExitWindowLeftIndent, serverExitWindowTopIndent,
                                           serverExitWindowWidth, serverExitWindowHeight);

            serverExitWindow = GUILayout.Window(1, serverExitWindow, ServerExitWindow, "");
        }


        if (Network.peerType == NetworkPeerType.Client && showExitWindow == true)
        {
            clientExitWindow = new Rect(Screen.width / 2 - clientExitWindowWidth / 2,
                                           Screen.height / 2 - clientExitWindowHeight / 2,
                                           clientExitWindowWidth, clientExitWindowHeight);

            clientExitWindow = GUILayout.Window(1, clientExitWindow, ClientExitWindow, "");
        }

    }


    [RPC]
    void TellPlayerServerName(string servername)
    {
        serverName = servername;
    }

}
