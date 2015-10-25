using UnityEngine;
using System.Collections;

public class Netowrks : MonoBehaviour {
	private RoomOptions roomOpt;
	// Use this for initialization
	void Start () {
		Connect ();
		roomOpt = new RoomOptions (){maxPlayers = 2};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Connect(){
		PhotonNetwork.ConnectUsingSettings ("v 1.0");
		
	}
	
	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}
	/*
	void OnJoinedLobby() {
		
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinOrCreateRoom ("Test",roomOpt,TypedLobby.Default);
	}*/
	/*
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		
	}*/
	/*
	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		
	}*/
}
