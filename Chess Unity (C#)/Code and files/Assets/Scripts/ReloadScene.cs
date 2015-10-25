using UnityEngine;
using System.Collections;

public class ReloadScene : MonoBehaviour {

	public void RELOAD(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void CHANGESCENTETOMAINMENU(){

		PhotonNetwork.Disconnect ();
		Application.LoadLevel ("StartMenu");
	}
}
