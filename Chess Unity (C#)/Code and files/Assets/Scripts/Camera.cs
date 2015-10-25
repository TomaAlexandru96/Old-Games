using UnityEngine;
using System.Collections;

public class Cameraa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scroll = new Vector3 (0, Input.GetAxis("Mouse ScrollWheel"), 0);
		transform.Translate (scroll);
	}
}
