using UnityEngine;
using System.Collections;

public class WaypointScript : MonoBehaviour {

	public Material green;
	public Material deffault;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "playerView") {
			GetComponent<MeshRenderer>().material = green;
			foreach (Transform child in transform)
			{
				//Debug.Log (child.transform.name);
				child.GetComponent<ParticleSystem>().enableEmission = true;
			}
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "playerView") {

			GetComponent<MeshRenderer>().material = deffault;
			foreach (Transform child in transform)
			{
				//Debug.Log (child.transform.name);
				child.GetComponent<ParticleSystem>().enableEmission = false;
			}
		}
	}
}
