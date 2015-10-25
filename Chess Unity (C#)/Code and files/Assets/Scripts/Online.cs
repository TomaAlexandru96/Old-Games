using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Online : MonoBehaviour {
	public static int playerToSet;
	private GameObject onlinePanel;
	private GameObject[] buttons;
	private GameObject joinPanel;
	private GameObject createPanel;
	private GameObject loadingScreen;
	public GameObject room;


	private int okNumeIdentic = 0;

	public float speed;

	void Awake(){

		GameObject[] array = GameObject.FindGameObjectsWithTag ("_Scripts");
		if (Application.loadedLevelName == "StartMenu") {
			DontDestroyOnLoad (this);
		}

		for (int i=0;i<array.Length;i++){
			if (array.Length > 1){
				if (i==0){
					Destroy (array[i]);
				}
			}
		}
		okNumeIdentic = 0;
	}
	// Use this for initialization
	void Start () {
		loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen");
		loadingScreen.SetActive (false);

		joinPanel = GameObject.FindGameObjectWithTag("joinRoomPanel");
		joinPanel.SetActive (false);

		createPanel = GameObject.FindGameObjectWithTag("createRoomPanel");
		createPanel.SetActive (false);

		onlinePanel = GameObject.FindGameObjectWithTag("PanelOnline");
		onlinePanel.SetActive (false);
		buttons = GameObject.FindGameObjectsWithTag("menuButton");


	}
	
	// Update is called once per frame
	void Update () {

	}


	public void playOnline(){
		//Application.LoadLevel("Online");
		//GameObject[] onlinePanel = GameObject.FindGameObjectsWithTag ('PanelOnline');

		//Debug.Log ("playOnline");
		onlinePanel.SetActive (true);
		foreach (GameObject button in buttons) {
			
			button.SetActive(false);
		}
		okNumeIdentic = 0;
	}

	public void exitPlayOnline(){
		//Application.LoadLevel("Online");
		//GameObject[] onlinePanel = GameObject.FindGameObjectsWithTag ('PanelOnline');
		
		//Debug.Log ("playOnline");
		joinPanel.SetActive (false);
		createPanel.SetActive (false);
		onlinePanel.SetActive (false);
		foreach (GameObject button in buttons) {
			
			button.SetActive(true);
		}
		okNumeIdentic = 0;
	}

	public void joinTheRoom(){
		joinPanel.SetActive (true);
		createPanel.SetActive (false);
		okNumeIdentic = 0;
      }
	void OnGUI(){
		GUIStyle labelStyle = new GUIStyle();


		labelStyle.fontSize = 28;
		labelStyle.normal.textColor  = Color.white;

		if (joinPanel != null) {
			if (joinPanel.activeSelf == true) {
				RoomInfo[] games = PhotonNetwork.GetRoomList ();
			
				for (int i=0; i<games.Length; i++) {
					//Debug.Log (games[i].name);
				
					//Display the lobby connection list and room creation.
					if (games[i].playerCount < 2){
					float height = joinPanel.GetComponent<RectTransform> ().rect.height;
					float width = joinPanel.GetComponent<RectTransform> ().rect.width;




					GUI.Box (new Rect (230, 90 + 110 * i, width - 50, 100), "");
					GUI.Label (new Rect (240, 122 + 110 * i, width - 50, 100), "Room Name:", labelStyle);
					GUI.Label (new Rect (420, 122 + 110 * i, width - 50, 100), games [i].name, labelStyle);

						if (GUI.Button (new Rect (width - 50, 115 + 110 * i, 200, 50), "Join This Room")) {
							loadingScreen.SetActive(true);
							PhotonNetwork.JoinRoom (games [i].name);

							//PhotonNetwork.isMessageQueueRunning = false;
							//StartCoroutine (loadOnlineGame ());
						}
					}
					/*
                 GUI.Box(new Rect(Screen.width/2.5f, Screen.height/3, 400, 550),"");
	        	 GUILayout.BeginArea(new Rect(300,300, 400, 500));
          		 GUI.color = Color.red;		
         		 GUILayout.Box("Lobby");
          	     GUI.color = Color.white;
                 GUILayout.Label("Room Name:");
        		 /*roomName = GUILayout.TextField("Room Name"); //For network room name ask and recieve
                 GUILayout.Label("Max Amount of player 1-20:"); 
				 maxPlayerString = GUILayout.TextField(maxPlayerString,2); //How man players with a max character set of 2 allowing no more then 2 digit player size.*/
				}
				if (games.Length == 0){
					float width = joinPanel.GetComponent<RectTransform> ().rect.width;
					GUI.Label (new Rect (240, 122, width - 50, 100), "No rooms have been found", labelStyle);
				}
				else{
					int okGames = 0;
					foreach (RoomInfo element in games){
						if (element.playerCount == 1){
							okGames = 1;
						}
					}
					if (okGames == 0){
						float width = joinPanel.GetComponent<RectTransform> ().rect.width;
						GUI.Label (new Rect (240, 122, width - 50, 100), "No rooms have been found", labelStyle);
					}
				}
			}	
		}

		if (okNumeIdentic == 1) {
			GUIStyle err = new GUIStyle();
			
			float widthOk = joinPanel.GetComponent<RectTransform> ().rect.width;

			err.fontSize = 28;
			err.normal.textColor  = Color.red;
			GUI.Label (new Rect (240, 322, 600, 100), "Name already exist!!! Choose different name.", err);
		}
	}

	public void createRoom(){

		createPanel.SetActive (true);
		joinPanel.SetActive (false);
	}

	public void createButtonPressed(){



		string numeRoom;
		int okkkk = 1;


		RoomOptions roomOpt;
		roomOpt = new RoomOptions (){maxPlayers = 2};
		GameObject inputName = GameObject.FindGameObjectWithTag ("inputName");
		GameObject inputColor = GameObject.FindGameObjectWithTag ("inputColor");
		string text = inputName.GetComponent<InputField> ().text;
		bool colorSelected;



		colorSelected = inputColor.GetComponent<Toggle> ().isOn;
		roomOpt.customRoomProperties = new ExitGames.Client.Photon.Hashtable();

		if (colorSelected) {

			roomOpt.customRoomProperties.Add("PLAYERNR",2);
		} 
		else {

			roomOpt.customRoomProperties.Add("PLAYERNR",1);
		}


		numeRoom = text;
		RoomInfo[] games = PhotonNetwork.GetRoomList ();
		
		for (int i=0; i < games.Length; i++) {
			if (games[i].name == numeRoom){
				okkkk = 0;
			}
		}
			
			
		if (okkkk == 1) {
			okNumeIdentic = 0;
			loadingScreen.SetActive(true);
			PhotonNetwork.CreateRoom (text, roomOpt, TypedLobby.Default);

			//PhotonNetwork.isMessageQueueRunning = false;
			StartCoroutine (loadOnlineGame ());
		}
		else {


			okNumeIdentic = 1;
		}
	}



	public IEnumerator loadOnlineGame(){
		if (PhotonNetwork.connectionStateDetailed.ToString () == "Joined") {
			//PhotonNetwork.isMessageQueueRunning = true;
			PhotonNetwork.LoadLevel ("Online");
		} else {
			yield return new WaitForSeconds(1);
			StartCoroutine (loadOnlineGame ());
		}
	}
	void OnJoinedRoom(){
		if(!PhotonNetwork.isMasterClient){
			PhotonNetwork.LoadLevel ("Online");
		}
	}
}
