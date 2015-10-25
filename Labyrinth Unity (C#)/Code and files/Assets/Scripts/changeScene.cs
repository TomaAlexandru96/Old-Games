using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeScene : MonoBehaviour {

	public static int difficulty = 1;


	private GameObject loadingScreen;
	private GameObject LoadingBarInside;

	private GameObject mainMenu;
	private GameObject levelMenuuu;
	// Use this for initialization
	void Start () {
		loadingScreen = GameObject.FindGameObjectWithTag ("LoadingScreen");
		loadingScreen.SetActive (false);
		LoadingBarInside = GameObject.FindGameObjectWithTag ("LoadingBarInside");
		 
		//LoadingBarInside.GetComponent<RectTransform>().sizeDelta = new Vector2( 20f, 30f);

		mainMenu = GameObject.FindGameObjectWithTag ("Menu");
		levelMenuuu = GameObject.FindGameObjectWithTag ("LevelSelect");
		levelMenuuu.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		/*int ok;
		ok = 1;

		GameObject[] toggles = GameObject.FindGameObjectsWithTag ("DifficultyToggle");

		foreach (GameObject obj in toggles) {
			if (obj.GetComponent<Toggle> ().isOn) {
				ok = 0;
			}
		}

		if (ok == 0) {
			
		}*/

	}
	public void changeFromMenuToGame(){
		DontDestroyOnLoad(this); 
		loadingScreen.SetActive (true);


		int k = 0;
		
		GameObject[] toggles = GameObject.FindGameObjectsWithTag ("DifficultyToggle");
		
		foreach (GameObject obj in toggles) {
			if (obj.GetComponent<Toggle> ().isOn) {
				k++;
			}
		}

		if (k == 1) {
			foreach (GameObject obj in toggles) {
				if (obj.GetComponent<Toggle> ().isOn) {
					//difficulty = obj.GetComponent<Toggle> ().isOn;
					if (obj.transform.name == "Easy"){
						difficulty = 1;
					}
					if (obj.transform.name == "Medium"){
						difficulty = 2;
					}
					if (obj.transform.name == "Hard"){
						difficulty = 3;
					}

				}
			}
			Debug.Log (difficulty);
		} 
		else 
		{
			Debug.LogError("Prea multe toggle!!!!!!!!!!!!(dificultate setata la Easy)");
		}


		Application.LoadLevel ("Game");
	}
	public void levelMenu(){
		mainMenu.SetActive (false);
		levelMenuuu.SetActive (true);
	}

	public void backToMenu(){

		levelMenuuu.SetActive (false);
		mainMenu.SetActive (true);
	}

	/*public void toggleEasy(bool state){
		int ok;
		ok = 1;
		GameObject[] toggles = GameObject.FindGameObjectsWithTag ("DifficultyToggle");



		foreach(GameObject obj in toggles){
			if (obj.transform.name != "Easy"){
				obj.GetComponent<Toggle>().isOn = false;
			}
		}

	}
	public void toggleMedium(bool state){
		int ok;
		ok = 1;
		GameObject[] toggles = GameObject.FindGameObjectsWithTag ("DifficultyToggle");


		foreach(GameObject obj in toggles){
			if (obj.transform.name != "Medium"){
				obj.GetComponent<Toggle>().isOn = false;
			}
		}
	}
	public void toggleHard(bool state){
		int ok;
		ok = 1;
		GameObject[] toggles = GameObject.FindGameObjectsWithTag ("DifficultyToggle");



		foreach(GameObject obj in toggles){
			if (obj.transform.name != "Hard"){
				obj.GetComponent<Toggle>().isOn = false;
			}
		}

	}*/
}
