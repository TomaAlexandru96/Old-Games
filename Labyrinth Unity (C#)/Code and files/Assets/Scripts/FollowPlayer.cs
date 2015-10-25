using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private int Xplayer;
	private int Yplayer;
	private int ok = 1;
	private GameObject playerTile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*GameObject player = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3 (player.transform.position.x,15,player.transform.position.z);*/


		if (mainScriptOfGame.leeOn == 1) {
			for (int i=1; i <= mainScriptOfGame.sizeToSendX; i++) {
				for (int j=1; j <= mainScriptOfGame.sizeToSendY;j++){
					/*if (mainScriptOfGame.matrix[i,j] == 2){
						playerTile = GameObject.Find(i+" "+j);
					}*/
					if (mainScriptOfGame.globalPlayerPosXToSend == i && mainScriptOfGame.globalPlayerPosYToSend == j){
						playerTile = GameObject.Find(i+" "+j);
					}
				}
			}
			mainScriptOfGame.leeOn = 0;
		}

		if (ok == 1) {
			for (int i=1; i <= mainScriptOfGame.sizeToSendX; i++) {
				for (int j=1; j <= mainScriptOfGame.sizeToSendY;j++){
					/*if (mainScriptOfGame.matrix[i,j] == 2){
						playerTile = GameObject.Find(i+" "+j);
					}*/
					if (mainScriptOfGame.globalPlayerPosXToSend == i && mainScriptOfGame.globalPlayerPosYToSend == j){
						playerTile = GameObject.Find(i+" "+j);
					}
				}
			}
			transform.position = new Vector3 (playerTile.transform.position.x, 10f, playerTile.transform.position.z);
			ok = 0;
		}
		if (Vector3.Distance (transform.position, playerTile.transform.position) > 0.1f) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (playerTile.transform.position.x, 10f, playerTile.transform.position.z), 2f * Time.deltaTime);
		} else {
			transform.position = playerTile.transform.position;
		}


	}
}
