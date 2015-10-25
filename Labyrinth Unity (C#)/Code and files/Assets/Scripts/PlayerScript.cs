using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject hitLight = GameObject.FindGameObjectWithTag ("playerView");
	}
	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Matrix"){
			string str;
			int x, y;
			str = other.transform.name;
			string[] coo = str.Split(' ');
			x = Int32.Parse(coo[0]);
			y = Int32.Parse(coo[1]);

			if (mainScriptOfGame.fogMap[x,y] == -2){
				mainScriptOfGame.fogMap[x,y] = 0;
			}
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Matrix") {
			//Debug.Log (other.transform.name);
			string str;
			int x, y;
			str = other.transform.name;
			string[] coo = str.Split (' ');
			x = Int32.Parse (coo [0]);
			y = Int32.Parse (coo [1]);
			
			if (mainScriptOfGame.fogMap [x, y] == 0) {
				mainScriptOfGame.fogMap [x, y] = -2;
			}
		}
	}
}
