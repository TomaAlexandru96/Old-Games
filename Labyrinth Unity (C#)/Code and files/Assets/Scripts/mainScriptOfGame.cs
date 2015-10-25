//matrix: -2 fog, 0 clear, 1 wall, 2 player, 9 finnish 3 spikes
//b: -1 can't reach, 1 player, -9 waypoint

using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class mainScriptOfGame : MonoBehaviour {

	private GameObject loadingScreen;
	private GameObject LoadingBarInside;

	private GameObject winscreen; 
	private GameObject losingscreen; 
	public static float playerHealth = 100;
	private float oldHealth = 100;
	private GameObject HealthPercentage;
	public int difficulty = 1;

	private int spikeDamage;
	private int spikeDamageMin;
	private int spikeDamageMax;


	public GameObject matrixPrefab;
	public GameObject player;
	public GameObject wall;
	public GameObject finnish;
	public GameObject clearPath;
	public GameObject spike;

	public Material wayPointDef;
	public Material green;
	public Material blue;
	public Material def;
	public Material marked;
	public Material greenWall;
	public Material WallDef;
	public Material spikeDef;

	public static int[] cooX ;
	public static int[] cooY ;

	public static int leeOn = 0;


	private float t;
	private int matrixSizeX;
	private int matrixSizeY;
	public static int[,] matrix;
	public int[,] b;
	public int[,] markedMat;
	public static int[,] fogMap;
	public static int[,] playerPosition;

	private GameObject[,] matrixList;
	private GameObject[,] wallsList;
	private GameObject[,] waypointsList;
	private GameObject[,] clearPathList;
	private GameObject[,] spikesList;

	public static int sizeToSendX;
	public static int sizeToSendY;

	public int renderDistance = 5;
	public int rangeOfView;
	private int floorMask;
	private float camRayLength = 500f;


	public static int globalPlayerPosX;
	public static int globalPlayerPosY;
	public static int globalPlayerPosXToSend;
	public static int globalPlayerPosYToSend;

	public static int globalFinalWaypointPosX;
	public static int globalFinalWaypointPosY;

	private int spikeHit = 0;
	private int spikeHitX = 0;
	private int spikeHitY = 0;

	void instantiateMatrixLists()
	{
		spikesList = new GameObject[matrixSizeX+10,matrixSizeY+10];
		clearPathList = new GameObject[matrixSizeX+10,matrixSizeY+10];
		waypointsList = new GameObject[matrixSizeX+10,matrixSizeY+10];
		matrixList = new GameObject[matrixSizeX+10,matrixSizeY+10];
		wallsList = new GameObject[matrixSizeX+10,matrixSizeY+10];
		markedMat = new int[matrixSizeX+10,matrixSizeY+10];
		b = new int[matrixSizeX+10,matrixSizeY+10];
		fogMap = new int[matrixSizeX+10,matrixSizeY+10];
	}

	void readDamageFile(){
		string input = File.ReadAllText( @"Assets/damageInput.txt" );
		int i = 1, j = 1;
		foreach (var row in input.Split('\n'))
		{
			j=1;
			foreach (var col in row.Trim().Split(' '))
			{
				if (difficulty == i){
					if(j == 1){
						spikeDamageMin = int.Parse(col.Trim());
					}
					if(j == 2){
						spikeDamageMax = int.Parse(col.Trim());
					}
				}
				j++;
			}
			i++;
		}

	}


	void afisare(int[,] matrixToDebug){

		string afisare = "";
		int i,j;
		for (i=1; i <= matrixSizeX; i++) {
			for (j=1; j <= matrixSizeY;j++){
				afisare = afisare + matrixToDebug[i,j] + " ";
			}
			afisare = afisare + "\n";
		}
		File.WriteAllText (@"Assets/Scripts/Maps/out.txt",afisare);

	}
	
	
	void InitMatrix(){
		int kX = 0, kY = 0;


		float startX, finX, startY, finY;

		startX = -(matrixSizeX/2)+0.5f;
		startY = -(matrixSizeY/2)+0.5f;

		finX = matrixSizeX / 2-0.5f;
		finY = matrixSizeY / 2-0.5f;

		for (float i = startX; i <= finX; i++) {
			kX++;
			for (float j = startY; j <= finY; j++){
				kY++;


				
				GameObject clone1;
				clone1 = Instantiate (matrixPrefab,new Vector3 (i,-0.35f,j),Quaternion.identity) as GameObject;
				clone1.name = kX + " " + kY;
				clone1.transform.parent = GameObject.FindGameObjectWithTag("MatrixHolder").transform;
				matrixList[kX,kY] = clone1;
				if (matrix[kX,kY] == 1){
					

					GameObject clone;
					clone = Instantiate (wall,new Vector3(GameObject.Find (kX+" "+kY).transform.position.x,0.5f,GameObject.Find (kX+" "+kY).transform.position.z),Quaternion.identity) as GameObject;
					clone.transform.parent = GameObject.FindGameObjectWithTag("WallHolder").transform;
					clone.transform.name = "w "+kX+" "+kY;
					wallsList[kX,kY] = clone;
					if (kX >= globalPlayerPosX - renderDistance && kX <= globalPlayerPosX + renderDistance &&
					    kY >= globalPlayerPosY - renderDistance && kY <= globalPlayerPosY + renderDistance){
					}
					else{
						clone.SetActive(false);
					}
					
				}
				if (matrix[kX,kY] == 1 || matrix[kX,kY] == 0 || matrix[kX,kY] == 2 || matrix[kX,kY] == 9){
					
				
				GameObject clone2;
				clone2 = Instantiate (clearPath,new Vector3(GameObject.Find (kX+" "+kY).transform.position.x,-0.4f,GameObject.Find (kX+" "+kY).transform.position.z),Quaternion.identity) as GameObject;
				clone2.transform.parent = GameObject.FindGameObjectWithTag("ClearPathHolder").transform;
				clone2.transform.name = "path "+kX+" "+kY;
				clearPathList[kX,kY] = clone2;
				if (kX >= globalPlayerPosX - renderDistance && kX <= globalPlayerPosX + renderDistance &&
				    kY >= globalPlayerPosY - renderDistance && kY <= globalPlayerPosY + renderDistance){
				}
				else{
					clone2.SetActive(false);
				}
					
				}
				
				if (matrix[kX,kY] == 2){
					Instantiate(player,new Vector3(GameObject.Find (kX+" "+kY).transform.position.x,0.5f,GameObject.Find (kX+" "+kY).transform.position.z),Quaternion.identity);
					matrix[kX,kY] = 0;
				}
				
				if (matrix[kX,kY] == 9){
					GameObject clone;

					clone = Instantiate(finnish,new Vector3(GameObject.Find (kX+" "+kY).transform.position.x,0.5f,GameObject.Find (kX+" "+kY).transform.position.z),Quaternion.identity) as GameObject;
					clone.transform.parent = GameObject.FindGameObjectWithTag("WaypointHolder").transform;
					globalFinalWaypointPosX = kX;
					globalFinalWaypointPosY = kY;
					clone.transform.name = "waypoint "+kX+" "+kY;
					waypointsList[kX,kY] = clone;
					if (kX >= globalPlayerPosX - renderDistance && kX <= globalPlayerPosX + renderDistance &&
					    kY >= globalPlayerPosY - renderDistance && kY <= globalPlayerPosY + renderDistance){
					}
					else{
						clone.SetActive(false);
					}
				}

				if (matrix[kX,kY] == 3){
					GameObject clone;
					
					clone = Instantiate(spike,new Vector3(GameObject.Find (kX+" "+kY).transform.position.x,-0.4f,GameObject.Find (kX+" "+kY).transform.position.z),Quaternion.identity) as GameObject;
					globalFinalWaypointPosX = kX;
					globalFinalWaypointPosY = kY;
					clone.transform.name = "spike "+kX+" "+kY;
					clone.transform.parent = GameObject.FindGameObjectWithTag("SpikesHolder").transform;
					spikesList[kX,kY] = clone;
					if (kX >= globalPlayerPosX - renderDistance && kX <= globalPlayerPosX + renderDistance &&
					    kY >= globalPlayerPosY - renderDistance && kY <= globalPlayerPosY + renderDistance){
					}
					else{
						clone.SetActive(false);
					}
				}


				if (kX >= globalPlayerPosX - renderDistance && kX <= globalPlayerPosX + renderDistance &&
				    kY >= globalPlayerPosY - renderDistance && kY <= globalPlayerPosY + renderDistance){
				}
				else{
					clone1.SetActive(false);
				}
			}
			kY = 0;
		}


	}

	void InitMatrix2(){


		for (int i = globalPlayerPosX - renderDistance; i<= globalPlayerPosX + renderDistance; i++) {
			for (int j = globalPlayerPosY - renderDistance; j<= globalPlayerPosY + renderDistance; j++){
				if (i>=1 && i<=matrixSizeX && j>=1 && j<=matrixSizeY){
					if (GameObject.Find(i+" "+j) == null){
						matrixList[i,j].SetActive(true);
					}
					if (matrix[i,j] != 3){
						if (GameObject.Find("path "+i+" "+j) == null){
							//Debug.Log ("path "+i+" "+j);
							clearPathList[i,j].SetActive(true);
						}
					}
					if (matrix[i,j] == 1){
						if (GameObject.Find("w "+i+" "+j) == null){
							wallsList[i,j].SetActive(true);
						}
					}
					
					if (matrix[i,j] == 9){
						if (GameObject.Find("waypoint "+i+" "+j) == null){
							waypointsList[i,j].SetActive(true);
						}
					}
					if (matrix[i,j] == 3){
						if (GameObject.Find("spike "+i+" "+j) == null){
							spikesList[i,j].SetActive(true);
						}
					}
				}
			}
		}
	}

	void setActivefalse(){
		for (int i = 1; i <= matrixSizeX; i++) {
			for (int j = 1; j <= matrixSizeY; j++) {
				if (i >= globalPlayerPosX - renderDistance && i <= globalPlayerPosX + renderDistance &&
				    j >= globalPlayerPosY - renderDistance && j <= globalPlayerPosY + renderDistance){

				}
				else{
					if (matrixList[i,j] != null)
						matrixList[i,j].SetActive(false);
					if (wallsList[i,j] != null)
						wallsList[i,j].SetActive(false);
					if (waypointsList[i,j] != null)
						waypointsList[i,j].SetActive(false);

					if (clearPathList[i,j] != null)
						clearPathList[i,j].SetActive(false);

					if (spikesList[i,j] != null)
						spikesList[i,j].SetActive(false);
				}
			}
		}
	}
	
	void calculateMap (){
		string input = File.ReadAllText( @"Assets/map1.txt" );
		int i = 1, j = 1;
		foreach (var row in input.Split('\n'))
		{
			j = 1;
			foreach (var col in row.Trim().Split(' '))
			{
				j++;
			}
			i++;
		}

		matrixSizeX = i - 1;
		matrixSizeY = j - 1;
		matrix = new int[matrixSizeX+10,matrixSizeY+10];

		i = 1;
		j = 1;
		foreach (var row in input.Split('\n'))
		{
			j = 1;
			foreach (var col in row.Trim().Split(' '))
			{
				matrix[i, j] = int.Parse(col.Trim());
				
				if (matrix[i,j] == 2){
					globalPlayerPosX = i;
					globalPlayerPosY = j;
					globalPlayerPosXToSend = globalPlayerPosX;
					globalPlayerPosYToSend = globalPlayerPosY;
				}
				j++;
			}
			i++;
		}
	}

	int verify(int px,int py,int pmx,int pmy){
		if (fogMap[pmx,pmy] == -2){
			return 0;
		}
		if (pmx > 0 && pmx <= matrixSizeX && pmy > 0 && pmy <= matrixSizeY){

			if (b [pmx, pmy] == 0) {
				return 1;
			}

		}

		return 0;
	}

	void rec (int px,int py,int pmx,int pmy ,int k){
		int ok = 0;
		for (int i = 1; i <= matrixSizeX; i++) {
			for (int j = 1; j <= matrixSizeY;j++){
				if (b[i,j] == k){
					px = i;
					py = j;
					if (verify (px, py, px + 1, py) == 1) {
						b[px + 1,py] = k+1;
						ok = 1;
					
					}
					if (verify (px, py, px - 1, py) == 1) {
						b[px - 1,py] = k+1;
						ok = 1;

					}
					if (verify (px, py, px, py + 1) == 1) {
						b[px,py + 1] = k+1;
						ok = 1;

					}
					if (verify (px, py, px, py - 1) == 1) {
						b[px,py - 1] = k+1;
						ok = 1;
					
					}



					if (verify (px, py, px + 1, py + 1) == 1 && b[px+1,py] != -1 && b[px,py+1] != -1 ) {
						b[px + 1,py + 1] = k+1;
						ok = 1;
					
					}
					if (verify (px, py, px - 1, py + 1) == 1 && b[px-1,py] != -1 && b[px,py+1] != -1 ) {
						b[px - 1,py + 1] = k+1;
						ok = 1;
					
					}
					if (verify (px, py, px + 1, py - 1) == 1 && b[px+1,py] != -1 && b[px,py-1] != -1 ) {
						b[px + 1,py - 1] = k+1;
						ok = 1;
					
					}
					if (verify (px, py, px - 1, py - 1) == 1 && b[px-1,py] != -1 && b[px,py-1] != -1 ) {
						b[px - 1,py - 1] = k+1;
						ok = 1;

					}
				}
			}
		}
		if (b [pmx, pmy] == 0 && ok == 1) {
			rec (px,py,pmx,pmy,k+1);
		}
		else{
			if ((b [pmx, pmy] != 0) ){
				cooX = new int[k+100];
				cooY = new int[k+100];
				drum (pmx,pmy,k+1);
				cooX[k+1] = pmx;
				cooY[k+1] = pmy;




				//MovePlayer();
				setMarkedMat();

				/*globalPlayerPosX = pmx;
				globalPlayerPosY = pmy;*/
				globalPlayerPosXToSend = pmx;
				globalPlayerPosYToSend = pmy;

				/*
				if (globalPlayerPosX + rangeOfView >= globalPlayerPosX ||
				    globalPlayerPosX - rangeOfView <= 0 ||
				    globalPlayerPosY + rangeOfView >= globalPlayerPosY ||
				    globalPlayerPosY - rangeOfView <= 0) {


					InitMatrix2();
					GameObject[] obiecteCuTagMatrix = GameObject.FindGameObjectsWithTag("Matrix");
					if (obiecteCuTagMatrix.Length > 600){

						setActivefalse();
					}
				}*/

				//if (Math.Abs()){
					InitMatrix2();
					GameObject[] obiecteCuTagMatrix = GameObject.FindGameObjectsWithTag("Matrix");
					if (obiecteCuTagMatrix.Length > 600){
						
						setActivefalse();
					}
				//}



/*
				if (pmx + rangeOfView >= globalPlayerPosX ||
				    globalPlayerPosX - rangeOfView <= 0 ||
				    globalPlayerPosY + rangeOfView >= globalPlayerPosY ||
				    globalPlayerPosY - rangeOfView <= 0) {
					
					
					InitMatrix2();
					GameObject[] obiecteCuTagMatrix = GameObject.FindGameObjectsWithTag("Matrix");
					if (obiecteCuTagMatrix.Length > 600){
						
						setActivefalse();
					}
				}
				*/

			}
		}
	}

	void lee(int px,int py,int pmx,int pmy){



		leeOn = 1;
		for (int i=1; i <= matrixSizeX; i++) {
			for (int j=1; j <= matrixSizeY;j++){
				markedMat[i,j] = 0;
			}
		}
		
		

		firstPosX = px;
		firstPosY = py;
		
		for (int i=1; i <= matrixSizeX; i++) {
			for (int j=1; j <= matrixSizeY;j++){
				b[i,j] = 0;
				if (matrix[i,j] == 1){
					b[i,j] = -1;
				}




				if (i == pmx && j == pmy){

				}
				else{
					if (matrix[i,j] == 9){
						b[i,j] = -9;
					}
		     	}

				if (i == globalPlayerPosX && j == globalPlayerPosY){
					b[i,j] = 1;
				}
			}
		}
		if (verify (px,py,pmx,pmy) == 1) {
			rec (px,py,pmx,pmy , 1);
		}
	}

	void drum(int pmx,int pmy,int k){

		int px, py,ok,kkk,KK;
		ok = 0;
		kkk = k - 1;
		KK = k - 1;
		for (int i = 1; i <= matrixSizeX; i++) {
			for (int j = 1; j <= matrixSizeY;j++){
				if (pmx == i && pmy == j && k>1){
					px = i+1;
					py = j;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}
					px = i;
					py = j+1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}
					px = i-1;
					py = j;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}
					px = i;
					py = j-1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}




					px = i+1;
					py = j+1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}
					
					px = i-1;
					py = j+1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}

					px = i+1;
					py = j-1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}

					px = i-1;
					py = j-1;
					if (b[px,py] == KK && ok == 0) {
						cooX[kkk] = px;
						cooY[kkk] = py;
						ok = 1;
						drum (px,py,k-1);
					}


					//diagonalaEnd


				}
			}
		}
	}

	private int firstPosX = 0;
	private int firstPosY = 0;

	void setMarkedMat(){
		for (int i = 1; i<cooX.Length; i++) {
			if (cooX[i] != 0){
				markedMat[cooX[i],cooY[i]] = 1;
			}
		}
		
		isMoving = 1;
	}

	void riseSpikes(int x,int y){
		foreach (Transform child in GameObject.Find("spike " + x +" "+ y).transform)
		{
			
			if (child.name == "Spikes"){
				//0.156 default value
				child.position = new Vector3(child.position.x,0.3f,child.position.z);
			}
		}
	}



	void MovePlayer(){
		/*for (int i = 1; i<cooX.Length; i++) {
			if (cooX[i] != 0){
				markedMat[cooX[i],cooY[i]] = 1;
			}
		}
		
		isMoving = 1;
		
		firstPosX = cooX[1];
		markedMat[cooX[1],cooY[1]] = 0;
		for (int i = 1; i<cooX.Length; i++) {
			if (i == cooX.Length - 1){
				cooX[i] = 0;
			}
			else{
				cooX[i] = cooX[i+1];
			}
		}
		firstPosY = cooY[1];
		for (int i = 1; i<cooY.Length; i++) {
			if (i == cooY.Length - 1){
				cooY[i] = 0;
			}
			else{
				cooY[i] = cooY[i+1];
			}
		}
		globalPlayerPosX = firstPosX;
		globalPlayerPosY = firstPosY;

		if (matrix[cooX[1],cooY[1]] == 3){
			spikeHit = 1;
		}*/






		markedMat [cooX [1], cooY [1]] = 0;



		if (spikeHit == 1){
			spikeDamage = UnityEngine.Random.Range(spikeDamageMin,spikeDamageMax+1);

			playerHealth = playerHealth-spikeDamage;
			spikeHit = 0;
			cooX = new int[3];
			cooY = new int[3];

			cooX[1] = spikeHitX;
			cooY[1] = spikeHitY;


			riseSpikes(spikeHitX,spikeHitY);



			spikeHitX = 0;
			spikeHitY = 0;


			cooX[2] = globalPlayerPosX;
			cooY[2] = globalPlayerPosY;

			for (int i=1; i <= matrixSizeX; i++) {
				for (int j=1; j <= matrixSizeY; j++) {
					markedMat [i, j] = 0;
				}
			}
			cancelMoveAndContinue = 0;
			cancelMoveAndStop = 0;
		}




		firstPosX = cooX [1];
		for (int i = 1; i<cooX.Length; i++) {
			
			if (i == cooX.Length - 1) {
				cooX [i] = 0;
			} else {
				cooX [i] = cooX [i + 1];
			}
		}
		firstPosY = cooY [1];
		for (int i = 1; i<cooY.Length; i++) {
			if (i == cooY.Length - 1) {
				cooY [i] = 0;
			} else {
				cooY [i] = cooY [i + 1];
			}
		}
		globalPlayerPosX = firstPosX;
		globalPlayerPosY = firstPosY;
		
		if (cancelMoveAndContinue == 1) {
			
			isMoving = 0;
			cancelMoveAndContinue = 0;
			for (int i=1; i <= matrixSizeX; i++) {
				for (int j=1; j <= matrixSizeY; j++) {
					markedMat [i, j] = 0;
				}
			}
			
			globalPlayerPosX = firstPosX;
			globalPlayerPosY = firstPosY;
			leeOn = 1;
			okToChangePath = 1;
			lee (globalPlayerPosX,globalPlayerPosY,sendPmx,sendPmy);
			
			
			
			
		}
		if (cancelMoveAndStop == 1) {
			isMoving = 0;
			
			
			for (int i=1; i <= matrixSizeX; i++) {
				for (int j=1; j <= matrixSizeY; j++) {
					markedMat [i, j] = 0;
				}
			}
			
			
			globalPlayerPosX = firstPosX;
			globalPlayerPosY = firstPosY;
			cancelMoveAndStop = 0;
			leeOn = 1;
		}

		if (matrix[cooX[1],cooY[1]] == 3){
			spikeHit = 1;
			spikeHitX = cooX[1];
			spikeHitY = cooY[1];
		}
	}
	
	
	
	
	private int isMoving = 0;
	
	
	
	
	
	
	private int cancelMoveAndContinue = 0;

	private int okToChangePath = 0;
	private int cancelMoveAndStop = 0;

	public GameObject healthBar;
	private Vector2 healthBarSize;


	// Use this for initialization
	void Start () {
		difficulty = changeScene.difficulty;


		winscreen = GameObject.FindGameObjectWithTag ("WinScreen");
		winscreen.SetActive (false);
		losingscreen = GameObject.FindGameObjectWithTag ("LosingScreen");
		losingscreen.SetActive (false);

		loadingScreen = GameObject.FindGameObjectWithTag ("LoadingScreen");
		loadingScreen.SetActive (false);
		LoadingBarInside = GameObject.FindGameObjectWithTag ("LoadingBarInside");

		calculateMap ();
		readDamageFile ();
		instantiateMatrixLists();



		RenderSettings.ambientLight = Color.black;


		cooX = new int[1];
		cooY = new int[1];

		sizeToSendX = matrixSizeX;
		sizeToSendY = matrixSizeY;

		InitMatrix();


		floorMask = LayerMask.GetMask ("Floor");


		t = Time.realtimeSinceStartup;


		//set fog    -2 : fog

		for (int i=1; i <= matrixSizeX; i++) {
			for (int j=1; j <= matrixSizeY;j++){
				fogMap[i,j] = -2;
			}
		}
		//set fog


		//set health bar
		healthBar = GameObject.FindGameObjectWithTag("HealthBar");
		healthBarSize = healthBar.GetComponent<RectTransform> ().sizeDelta;
		HealthPercentage = GameObject.FindGameObjectWithTag("HealthPercentage");

		if (playerHealth > 75f){
			HealthPercentage.GetComponent<Text>().color = Color.green;
		}
		if (playerHealth > 25f && playerHealth <= 75f){
			HealthPercentage.GetComponent<Text>().color = new Color(255.0f,127.0f,80.0f,1f);//255,127,80
		}
		if (playerHealth <= 25f){
			HealthPercentage.GetComponent<Text>().color = Color.red;
		}
		sizeToModify = new Vector2 (healthBarSize.x-healthBarSize.x*((100f-playerHealth)/100f),healthBarSize.y);
		//set health bar

	}
	
	
	//TEST
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	//TEST

	public bool run = true;
	private int sendPmx = 0;
	private int sendPmy = 0;
	private int firstClick = 0;
	private Vector2 sizeToModify;

	// Update is called once per frame
	void Update () {

		if (oldHealth != playerHealth){
			oldHealth = playerHealth;
			HealthPercentage.GetComponent<Text>().text = playerHealth + " %";
			if(playerHealth <= 0){
				HealthPercentage.GetComponent<Text>().text = "0 %";
			}
			if (playerHealth > 75f){
				HealthPercentage.GetComponent<Text>().color = new Color(0.0f,128.0f,0.0f);//0,128,0
			}
			if (playerHealth > 25f && playerHealth <= 75f){
				HealthPercentage.GetComponent<Text>().color = new Color(255.0f,128.0f,0.0f);//255,128,0
			}
			if (playerHealth <= 25f){
				HealthPercentage.GetComponent<Text>().color = Color.red;
			}
			//Debug.Log (healthBar.GetComponent<RectTransform>().sizeDelta);
			sizeToModify = new Vector2 (healthBarSize.x-healthBarSize.x*((100f-playerHealth)/100f),healthBarSize.y);
			//Debug.Log (healthBar.GetComponent<RectTransform>().sizeDelta);
		}

		if (sizeToModify.x > healthBar.GetComponent<RectTransform> ().sizeDelta.x + 1.5f || sizeToModify.x < healthBar.GetComponent<RectTransform> ().sizeDelta.x - 1.5f) {
			healthBar.GetComponent<RectTransform> ().sizeDelta = healthBar.GetComponent<RectTransform> ().sizeDelta - new Vector2 (1f, 0f)*3f;
		}
		else {
			healthBar.GetComponent<RectTransform> ().sizeDelta = sizeToModify;
		}


		if (run) {





			int okMove = 0;
			int px = 0, py = 0, pmx = 0, pmy = 0;//px - Player X,  pmx - Player move X analog y
			int xxxx, yyyy;
			string str = "";

			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit floorHit;

			GameObject[] objects = GameObject.FindGameObjectsWithTag ("Matrix");

			for (int i = 0; i < objects.Length; i++) {
				str = objects [i].transform.name;
				string[] coo = str.Split (' ');
				xxxx = Int32.Parse (coo [0]);
				yyyy = Int32.Parse (coo [1]);
				if (markedMat [xxxx, yyyy] != 1) {
					if (objects [i] != null) {
					//if (GameObject.Find("path " + xxxx +" "+ yyyy) != null) {
						//objects [i].gameObject.GetComponent<MeshRenderer> ().material = def;
						if (matrix[xxxx,yyyy] == 0){
							if (GameObject.Find("path " + xxxx +" "+ yyyy) != null){
								GameObject.Find("path " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = def;
							}
						}
						if (matrix[xxxx,yyyy] == 3){

							if (GameObject.Find("spike " + xxxx +" "+ yyyy) != null){
							//GameObject.Find("spike " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = marked;
								foreach (Transform child in GameObject.Find("spike " + xxxx +" "+ yyyy).transform)
								{

									if (child.name == "Cube"){

										child.gameObject.GetComponent<MeshRenderer> ().material = spikeDef;
									}
								}
							}
						}
						if (matrix[xxxx,yyyy] == 9){

							if (GameObject.Find("waypoint " + xxxx +" "+ yyyy) != null){
								//GameObject.Find("waypoint " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = wayPointDef;
								GameObject.Find("path " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = def;

							}
						}

					}
				} 
				else {
					//objects [i].gameObject.GetComponent<MeshRenderer> ().material = marked;
					if (matrix[xxxx,yyyy] == 0 ){//|| matrix[xxxx,yyyy] == 9){
						GameObject.Find("path " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = marked;
					}
					if (matrix[xxxx,yyyy] == 3){
						//GameObject.Find("spike " + xxxx +" "+ yyyy).gameObject.GetComponent<MeshRenderer> ().material = marked;
						foreach (Transform child in GameObject.Find("spike " + xxxx +" "+ yyyy).transform)
						{
							if (child.transform.name == "Cube"){
								child.gameObject.GetComponent<MeshRenderer> ().material = marked;
							}
						}
					}
				}
				if (matrix [xxxx, yyyy] == 1) {
					if (GameObject.Find ("w " + xxxx + " " + yyyy) != null) {
						GameObject.Find ("w " + xxxx + " " + yyyy).gameObject.GetComponent<MeshRenderer> ().material = WallDef;
					}
				}
			}

			if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {

				if (Input.GetKeyDown ("s")) {
					Debug.Log ("S is pressed");
					if (isMoving == 1) {
						cancelMoveAndStop = 1;
					}
				}
				if (Input.GetButtonDown ("Fire1") && floorHit.transform.name != null) {
					firstClick = 1;
					str = floorHit.transform.name;
					string[] coo = str.Split (' ');
					pmx = Int32.Parse (coo [0]);
					pmy = Int32.Parse (coo [1]);
					
					
					if (fogMap [pmx, pmy] != -2) {
						//floorHit.transform.GetComponent<MeshRenderer> ().material = blue;
						if (matrix[pmx,pmy] == 0){
							GameObject.Find("path " + pmx + " " + pmy).transform.GetComponent<MeshRenderer> ().material = blue;
						}
						if (matrix[pmx,pmy] == 3){
							foreach (Transform child in GameObject.Find("spike " + pmx +" "+ pmy).transform)
							{
								if (child.transform.name == "Cube"){
									child.gameObject.GetComponent<MeshRenderer> ().material = blue;
								}
							}
						}
					}
					
					
					
					for (int i=1; i <= matrixSizeX; i++) {
						for (int j=1; j <= matrixSizeY; j++) {
							
							if (i == globalPlayerPosX && j == globalPlayerPosY) {
								px = i;
								py = j;
							}
						}
					}
					if (isMoving == 0) {
						lee (px, py, pmx, pmy);
					} else {
						sendPmx = pmx;
						sendPmy = pmy;
						cancelMoveAndContinue = 1;
					}
					
				} else {
					str = floorHit.transform.name;
					string[] coo = str.Split (' ');
					pmx = Int32.Parse (coo [0]);
					pmy = Int32.Parse (coo [1]);
					
					if ((matrix [pmx, pmy] == 0 || matrix [pmx, pmy] == 9) && fogMap [pmx, pmy] != -2) {
						//floorHit.transform.GetComponent<MeshRenderer> ().material = green;
						GameObject.Find("path " + pmx + " " + pmy).transform.GetComponent<MeshRenderer> ().material = green;
					}
					if (matrix [pmx, pmy] == 1) {
						if (fogMap [pmx, pmy] != -2) {
							GameObject.Find ("w " + pmx + " " + pmy).transform.GetComponent<MeshRenderer> ().material = greenWall;
						}
					}
					if (matrix[pmx,pmy] == 3){
						foreach (Transform child in GameObject.Find("spike " + pmx +" "+ pmy).transform)
						{
							if (child.transform.name == "Cube"){
								child.gameObject.GetComponent<MeshRenderer> ().material = green;
							}
						}
					}
					
				}
				if (Input.GetButton ("Fire1") && floorHit.transform.name != null) {
					if (fogMap [pmx, pmy] != -2) {
						//floorHit.transform.GetComponent<MeshRenderer> ().material = blue;
						//GameObject.Find("path " + pmx + " " + pmy).GetComponent<MeshRenderer> ().material = blue;
						if (matrix[pmx,pmy] == 0){
							GameObject.Find("path " + pmx + " " + pmy).transform.GetComponent<MeshRenderer> ().material = blue;
						}
						if (matrix[pmx,pmy] == 3){
							foreach (Transform child in GameObject.Find("spike " + pmx +" "+ pmy).transform)
							{
								if (child.transform.name == "Cube"){
									child.gameObject.GetComponent<MeshRenderer> ().material = blue;
								}
							}
						}
					}
				}
				/*if (Input.GetButton ("Fire1") && floorHit.transform.name != null && firstClick == 0) {

					str = floorHit.transform.name;
					string[] coo = str.Split (' ');
					pmx = Int32.Parse (coo [0]);
					pmy = Int32.Parse (coo [1]);
					
					
					if (fogMap [pmx, pmy] != -2) {
						floorHit.transform.GetComponent<MeshRenderer> ().material = blue;
					}
					
					
					
					for (int i=1; i <= matrixSizeX; i++) {
						for (int j=1; j <= matrixSizeY; j++) {

							if (i == globalPlayerPosX && j == globalPlayerPosY) {
								px = i;
								py = j;
							}
						}
					}
					if (isMoving == 0) {
						lee (px, py, pmx, pmy);
					} else {
						sendPmx = pmx;
						sendPmy = pmy;
						cancelMoveAndContinue = 1;
					}
					
				} else {
					str = floorHit.transform.name;
					string[] coo = str.Split (' ');
					pmx = Int32.Parse (coo [0]);
					pmy = Int32.Parse (coo [1]);
					
					if ((matrix [pmx, pmy] == 0 || matrix [pmx, pmy] == 9) && fogMap [pmx, pmy] != -2) {
						floorHit.transform.GetComponent<MeshRenderer> ().material = green;
					}
					if (matrix [pmx, pmy] == 1) {
						if (fogMap [pmx, pmy] != -2) {
							GameObject.Find ("w " + pmx + " " + pmy).transform.GetComponent<MeshRenderer> ().material = greenWall;
						}
					}

				}*/
				firstClick = 0;
			}

		
			if (isMoving == 1) {

				if (cooX [1] != 0) {



					GameObject thePlayerObject = GameObject.FindGameObjectWithTag ("Player");
					GameObject tileToMove = GameObject.Find (cooX [1] + " " + cooY [1]);

					Vector3 vectorOfMovement = new Vector3 (0, 0, 0);

					journeyLength = Vector3.Distance (thePlayerObject.transform.position, new Vector3 (tileToMove.transform.position.x, 0.5f, tileToMove.transform.position.z));


					float distCovered = Time.deltaTime * speed;
					float fracJourney = distCovered / 0.8f;
					thePlayerObject.transform.position = Vector3.Lerp (thePlayerObject.transform.position, new Vector3 (tileToMove.transform.position.x, 0.5f, tileToMove.transform.position.z), fracJourney);

					if (journeyLength < 0.5f) {

					} else {
						thePlayerObject.transform.position = thePlayerObject.transform.position + new Vector3 (0, 0.05f, 0);
					}

					float distX = Math.Abs (thePlayerObject.transform.position.x - tileToMove.transform.position.x);
					float distY = Math.Abs (thePlayerObject.transform.position.z - tileToMove.transform.position.z);

					if (distX < 0.1f && distY < 0.1f) {

						thePlayerObject.transform.position = new Vector3 (tileToMove.transform.position.x, 0.5f, tileToMove.transform.position.z);
						okMove = 0;
						for (int i = 1; i<cooX.Length; i++) {
							if (cooX [i] != 0) {
								okMove = 1;
								markedMat [cooX [i], cooY [i]] = 1;
							}
						}


					
						if (okMove == 1) {
							MovePlayer();
							/*markedMat [cooX [1], cooY [1]] = 0;
							firstPosX = cooX [1];
							for (int i = 1; i<cooX.Length; i++) {

								if (i == cooX.Length - 1) {
									cooX [i] = 0;
								} else {
									cooX [i] = cooX [i + 1];
								}
							}
							firstPosY = cooY [1];
							for (int i = 1; i<cooY.Length; i++) {
								if (i == cooY.Length - 1) {
									cooY [i] = 0;
								} else {
									cooY [i] = cooY [i + 1];
								}
							}
							globalPlayerPosX = firstPosX;
							globalPlayerPosY = firstPosY;

							if (cancelMoveAndContinue == 1) {

								isMoving = 0;
								cancelMoveAndContinue = 0;
								for (int i=1; i <= matrixSizeX; i++) {
									for (int j=1; j <= matrixSizeY; j++) {
										markedMat [i, j] = 0;
									}
								}

								globalPlayerPosX = firstPosX;
								globalPlayerPosY = firstPosY;
								leeOn = 1;
								okToChangePath = 1;
								lee (globalPlayerPosX,globalPlayerPosY,sendPmx,sendPmy);




							}
							if (cancelMoveAndStop == 1) {
								isMoving = 0;


								for (int i=1; i <= matrixSizeX; i++) {
									for (int j=1; j <= matrixSizeY; j++) {
										markedMat [i, j] = 0;
									}
								}


								globalPlayerPosX = firstPosX;
								globalPlayerPosY = firstPosY;
								cancelMoveAndStop = 0;
								leeOn = 1;
							}
							if (cancelMoveAndContinue == 0 && cancelMoveAndStop == 0){
								if (spikeHit == 1){

									Debug.Log ("Intra");

									spikeHit = 0;
								}
							}
							if (matrix[cooX[1],cooY[1]] == 3){
								spikeHit = 1;
							}*/
						}




	
					}
				} 
				else {
					isMoving = 0;

				}
			
			
			
			}
		

		}

		if (globalFinalWaypointPosX == globalPlayerPosX && globalFinalWaypointPosY == globalPlayerPosY && isMoving == 0) {
			run = false;
			winscreen.SetActive(true);
		}
		if (playerHealth <= 0) {
			run = false;
			losingscreen.SetActive(true);
		}
	}

	public void reloadLevel(){
		run = true;
		globalPlayerPosX = 0;
		globalPlayerPosY = 0;
		globalFinalWaypointPosX = 0;
		globalFinalWaypointPosY = 0;
		playerHealth = 100;

		loadingScreen.SetActive (true);

		Application.LoadLevel (Application.loadedLevel);
	}

}
