using UnityEngine;
using System.Collections;

public class CameraMoveTo : MonoBehaviour {
	private int GlobalPlayer;
	public float scrollSpeed;
	public float xResMax;
	public float xResMin;
	public float yResMax;
	public float yResMin;
	public float zResMax;
	public float zResMin;
	private int resetCamera = 0;
	private float angle;
	public float amount;
	public float moveCameraSpeed;
	// Use this for initialization
	void Start () {
		int nrFromCustom;
		nrFromCustom = (int)PhotonNetwork.room.customProperties["PLAYERNR"];
		if (PhotonNetwork.isMasterClient) {
			if (nrFromCustom == 1){
				GlobalPlayer = 1;
			}
			else{
				GlobalPlayer = 2;
			}
		}
		else{
			if (nrFromCustom == 1){
				GlobalPlayer = 2;
			}
			else{
				GlobalPlayer = 1;
			}
		}



		if (GlobalPlayer == 2) {
			GameObject obiect;
			obiect = GameObject.Find ("Background");
			obiect.gameObject.transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, 180);


			obiect = GameObject.Find ("BackForLabel");
			obiect.gameObject.transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, 180);

			GameObject[] lights = GameObject.FindGameObjectsWithTag("Lights");
			foreach (GameObject element in lights){
				element.gameObject.transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, 180);
			}

			transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, 180);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		float mouseX = Input.GetAxis ("Mouse X");

	//	Debug.Log (scroll);


		GameObject label;


		if (resetCamera == 1) {
				rotateCamera();
			}

		 else {
			if (transform.eulerAngles.y > 180)
				angle = 360 - transform.eulerAngles.y;
			else {
				angle = transform.eulerAngles.y;
			}
			if (Input.GetAxis ("Fire3") > 0) {
				transform.LookAt(new Vector3 (0,0,0));
				transform.RotateAround(new Vector3(0,0,0),Vector3.up * mouseX,Time.deltaTime*moveCameraSpeed);

			}
		}
	}
	public void rotateCamera(){
		float i;
		if (angle > 0) {
			if (angle - amount < 0){
				for (i = angle;i >= 0;i = i-angle/amount){
					if (transform.eulerAngles.y < 180)
						transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, i);
					else
						transform.RotateAround (new Vector3 (0, 0, 0), Vector3.up, i);
				}
				angle = 0;
			}
			else
			{
				if (transform.eulerAngles.y < 180)
					transform.RotateAround (new Vector3 (0, 0, 0), Vector3.down, amount);
				else
					transform.RotateAround (new Vector3 (0, 0, 0), Vector3.up, amount);
			}
			angle = angle - amount;
			resetCamera = 1;
		} else {
			resetCamera = 0;
		}
	}

}
