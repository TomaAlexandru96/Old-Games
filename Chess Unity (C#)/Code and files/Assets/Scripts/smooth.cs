using UnityEngine;
using System.Collections;

public class smooth : Photon.MonoBehaviour {
	private float time;
	private Vector3 newPos;
	private Quaternion newRot;
	/*Vector3 newPos = Vector3.zero;
	Quaternion newRot = Quaternion.identity;*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*bool playerViewwww;
		playerViewwww = GameObject.Find ("Sc").GetComponent<PhotonView> ().isMine;
		
		if (!playerViewwww) {
			transform.position = Vector3.Lerp (transform.position,newPos,0.15f);
			transform.rotation = Quaternion.Lerp (transform.rotation,newRot,0.15f);
		}*/
	}
	
	/*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);

		}
		else {
			newPos = (Vector3)stream.ReceiveNext ();
			newRot = (Quaternion)stream.ReceiveNext ();
		}
	}*/
}
