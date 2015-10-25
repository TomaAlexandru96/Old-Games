using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
public class Main : MonoBehaviour {
	private int cooX;
	private int cooY;
	private int player = 1;
	private int t11 = 1;
	private int t18 = 1;
	private int t81 = 1;
	private int t88 = 1;
	private int regA = 1;
	private int regN = 1;
	private int auxiliar = 0;
	public float speed;
	private int ktQB = 0;
	private int ktQA = 0;
	private int ktBB = 0;
	private int ktBA = 0;
	private int ktHB = 0;
	private int ktHA = 0;
	private int ktTB = 0;
	private int ktTA = 0;
	private int ktPB = 0;
	private int ktPA = 0;
	private int piesaInlocuita = 0;
	private int alege = 0;
	private int runGame;
	private GameObject sfarsit;
	private GameObject sfarsitText;
	private GameObject isCheck;

	int[][] a = 
	{
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,-2,-3,-4,-5,-6,-4,-3,-2},
		new int[] {0,-1,-1,-1,-1,-1,-1,-1,-1},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,1,1,1,1,1,1,1,1},
		new int[] {0,2,3,4,5,6,4,3,2},
	};

	int[][] b = 
	{
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
		new int[] {0,0,0,0,0,0,0,0,0},
	};


	public GameObject highlightSelect;
	public GameObject highlightBlue;
	public GameObject highlightGreen;
	public GameObject highlightRed;


	public GameObject SahTile;
	public GameObject pion;
	public GameObject tura;
	public GameObject cal;
	public GameObject nebun;
	public GameObject regina;
	public GameObject rege;
	public GameObject pionN;
	public GameObject turaN;
	public GameObject calN;
	public GameObject nebunN;
	public GameObject reginaN;
	public GameObject regeN;
	private int floorMask;
	private float camRayLength = 500f;

	//START

	void Pawn()
	{
		int i;
		for(i = 1; i <= 8; i++)
		{
			if(a[8][i] == 1)
			{
				//cin >> a[i][j];
			}
		}
		
		for(i = 1; i <= 8; i++)
		{
			if(a[2][i] == -1)
			{
				//cin >> a[i][j];
			}
		}
	}
	
	
	
	void deselect(){
		int i,j;
		for (i = 1; i <= 8; i++)
		{
			for(j = 1; j <= 8; j++)
			{
				b[i][j] = 0;
			}
		}
	}

	int movePiece(int x, int y, int x1, int y1,int ver)
	{


			if (a [x] [y] == 1) {
				if (y == y1) {
					if (x1 == x - 2 && a [x - 1] [y] == 0 && a [x - 2] [y] == 0 && x == 7) {
						return 1;
					}
					if (x1 == x - 1 && a [x - 1] [y] == 0) {
						return 1;
					}
				}
				if (a [x1] [y1] < 0) {
					if (x1 == x - 1) {
						if (y1 == y + 1)
							return 1;
						if (y1 == y - 1)
							return 1;
					}
				}
			}
		
			if (a [x] [y] == -1) {
				if (y == y1) {
					if (x1 == x + 2 && a [x + 1] [y] == 0 && a [x + 2] [y] == 0 && x == 2) {
						return 1;
					}
					if (x1 == x + 1 && a [x + 1] [y] == 0) {
						return 1;
					}
				}
				if (a [x1] [y1] > 0) {
					if (x1 == x + 1) {
						if (y1 == y + 1)
							return 1;
						if (y1 == y - 1)
							return 1;
					}
				}
			}

			int i, j;
			if (a [x] [y] == 2) {
				if (x == x1) {
					if (y > y1 && a [x1] [y1] <= 0) {
						for (i=y-1; i>y1; i--) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
					if (y < y1 && a [x1] [y1] <= 0) {
						for (i=y+1; i<y1; i++) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
				}
				if (y == y1) {
					if (x > x1 && a [x1] [y1] <= 0) {
						for (i=x-1; i>x1; i--) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
					if (x < x1 && a [x1] [y1] <= 0) {
						for (i=x+1; i<x1; i++) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
				}
			}
		
			if (a [x] [y] == -2) {
				if (x == x1) {
					if (y > y1 && a [x1] [y1] >= 0) {
						for (i=y-1; i>y1; i--) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
					if (y < y1 && a [x1] [y1] >= 0) {
						for (i=y+1; i<y1; i++) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
				}
				if (y == y1) {
					if (x > x1 && a [x1] [y1] >= 0) {
						for (i=x-1; i>x1; i--) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
					if (x < x1 && a [x1] [y1] >= 0) {
						for (i=x+1; i<x1; i++) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
				}
			}
		
		
			if (a [x] [y] == 4) {
				if (a [x1] [y1] <= 0) {
					if (x1 + y1 == x + y || x1 - y1 == x - y) {
						if (x < x1) {
							if (y < y1) {
								j = y + 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						} else {
							if (y < y1) {
								j = y + 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						}
					
					}
				}
			}
		
			if (a [x] [y] == -4) {
				if (a [x1] [y1] >= 0) {
					if (x1 + y1 == x + y || x1 - y1 == x - y) {
						if (x < x1) {
							if (y < y1) {
								j = y + 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						} else {
							if (y < y1) {
								j = y + 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						}
					
					}
				}
			}
		
			if (a [x] [y] == 5) {
				if (x == x1) {
					if (y > y1 && a [x1] [y1] <= 0) {
						for (i=y-1; i>y1; i--) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
					if (y < y1 && a [x1] [y1] <= 0) {
						for (i=y+1; i<y1; i++) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
				}
				if (y == y1) {
					if (x > x1 && a [x1] [y1] <= 0) {
						for (i=x-1; i>x1; i--) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
					if (x < x1 && a [x1] [y1] <= 0) {
						for (i=x+1; i<x1; i++) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
				}
			
			
				if (a [x1] [y1] <= 0) {
					if (x1 + y1 == x + y || x1 - y1 == x - y) {
						if (x < x1) {
							if (y < y1) {
								j = y + 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						} else {
							if (y < y1) {
								j = y + 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						}
					
					}
				}
			}
		
			if (a [x] [y] == -5) {
				if (a [x1] [y1] >= 0) {
					if (x1 + y1 == x + y || x1 - y1 == x - y) {
						if (x < x1) {
							if (y < y1) {
								j = y + 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x+1; i < x1; i++) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						} else {
							if (y < y1) {
								j = y + 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j++;
								}
								return 1;
							}
							if (y > y1) {
								j = y - 1;
								for (i=x-1; i > x1; i--) {
									if (a [i] [j] != 0) {
										return 0;
									}
									j--;
								}
								return 1;
							}
						}
					
					}
				}
			
				if (x == x1) {
					if (y > y1 && a [x1] [y1] >= 0) {
						for (i=y-1; i>y1; i--) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
					if (y < y1 && a [x1] [y1] >= 0) {
						for (i=y+1; i<y1; i++) {
							if (a [x] [i] != 0)
								return 0;
						}
						return 1;
					}
				}
				if (y == y1) {
					if (x > x1 && a [x1] [y1] >= 0) {
						for (i=x-1; i>x1; i--) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
					if (x < x1 && a [x1] [y1] >= 0) {
						for (i=x+1; i<x1; i++) {
							if (a [i] [y] != 0)
								return 0;
						}
						return 1;
					}
				}
			}
		
		
			if (a [x] [y] == 3) {
				if (a [x1] [y1] <= 0) {
					if (x1 == x + 2) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (x1 == x - 2) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (y1 == y + 2) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
					if (y1 == y - 2) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
				}
			}
		
		
			if (a [x] [y] == -3) {
				if (a [x1] [y1] >= 0) {
					if (x1 == x + 2) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (x1 == x - 2) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (y1 == y + 2) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
					if (y1 == y - 2) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
				}
			}
		
			if (a [x] [y] == 6) {
				if (a [x1] [y1] <= 0) {
					if (ver == 0) {
						for (i=1; i<=8; i++)
							for (j=1; j<=8; j++) {
								if (i == x && j == y) {
								} else {

									if (movePiece (i, j, x1, y1, 1) == 1 && a [i] [j] < 0)
										return 0;

								}
							}
					}
				
					if (x == x1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (y == y1) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
					if (x1 == x + 1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (x1 == x - 1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
				}
			}
			if (a [x] [y] == -6) {
				if (a [x1] [y1] >= 0) {
					if (ver == 0) {
						for (i=1; i<=8; i++)
							for (j=1; j<=8; j++) {
								if (i == x && j == y) {
								} else {
									if (movePiece (i, j, x1, y1, 1) == 1 && a [i] [j] > 0)
										return 0;
								}
							}
					}
				
					if (x == x1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (y == y1) {
						if (x1 == x + 1 || x1 == x - 1)
							return 1;
					}
					if (x1 == x + 1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
					if (x1 == x - 1) {
						if (y1 == y + 1 || y1 == y - 1)
							return 1;
					}
				}
			}
		return 0;
	}
	int rocada(){
		int ok,s=0,pl,aux;
		if (player == 1)
			pl = 6;
		else
			pl = -6;

		if (Chess (pl) == 0) {
			if (player == 1) {
				if (regA == 1) {
					if (t81 == 1) {
						ok = 1;
						if (a [8] [2] != 0) {
							ok = 0;
						}
						if (a [8] [3] != 0) {
							ok = 0;
						}
						if (a [8] [4] != 0) {
							ok = 0;
						}


						aux = a[8][3];
						a[8][3] = 6;
						a[8][5] = 0;



						if (Chess (6)==1){
							ok = 0;
						}
						a[8][3] = aux;
						a[8][5] = 6;



						aux = a[8][4];
						a[8][4] = 6;
						a[8][5] = 0;
						
						
						
						if (Chess (6)==1){
							ok = 0;
						}
						a[8][4] = aux;
						a[8][5] = 6;





						if (ok == 1) {

							s = s + 2;
						}

					}
					if (t88 == 1) {
						ok = 1;

						if (a [8] [6] != 0) {
							ok = 0;
						}
						if (a [8] [7] != 0) {
							ok = 0;
						}


						aux = a[8][7];
						a[8][7] = 6;
						a[8][5] = 0;
						
						if (Chess (6)==1){
							ok = 0;
						}
						a[8][7] = aux;
						a[8][5] = 6;


						aux = a[8][6];
						a[8][6] = 6;
						a[8][5] = 0;
						
						
						
						if (Chess (6)==1){
							ok = 0;
						}
						a[8][6] = aux;
						a[8][5] = 6;


						if (ok == 1) {
							s = s + 1;
						}
					}
				}
			} else {
				if (regN == 1) {
					if (t11 == 1) {
						ok = 1;
						if (a [1] [2] != 0) {
							ok = 0;
						}
						if (a [1] [3] != 0) {
							ok = 0;
						}
						if (a [1] [4] != 0) {
							ok = 0;
						}
						
						
						aux = a[1][3];
						a[1][3] = -6;
						a[1][5] = 0;
						
						
						
						if (Chess (-6)==1){
							ok = 0;
						}
						a[1][3] = aux;
						a[1][5] = -6;

						aux = a[1][4];
						a[1][4] = -6;
						a[1][5] = 0;
						
						
						
						if (Chess (-6)==1){
							ok = 0;
						}
						a[1][4] = aux;
						a[1][5] = -6;

						if (ok == 1) {
							
							s = s + 2;
						}
					}
					if (t18 == 1) {
						ok = 1;
						
						if (a [1] [6] != 0) {
							ok = 0;
						}
						if (a [1] [7] != 0) {
							ok = 0;
						}
						
						
						aux = a[1][7];
						a[1][7] = -6;
						a[1][5] = 0;
						
						if (Chess (-6)==1){
							ok = 0;
						}
						a[1][7] = aux;
						a[1][5] = -6;

						aux = a[1][6];
						a[1][6] = -6;
						a[1][5] = 0;
						
						if (Chess (-6)==1){
							ok = 0;
						}
						a[1][6] = aux;
						a[1][5] = -6;
						
						
						if (ok == 1) {
							s = s + 1;
						}
					}
				}
			}
		}
		return s;
	}
	void SahMat(){
		int i, j ,p,q,pl,aux,ok=1;
		if (player == 1)
			pl = 6;
		else
			pl = -6;

		for (i=1; i<=8; i++) {
			for (j=1;j<=8;j++){
				if ((pl == 6 && a[i][j] > 0)||(pl == -6 && a[i][j] < 0)){
					for (p = 1;p<=8;p++){
						for (q=1;q<=8;q++){
							if (movePiece(i,j,p,q,1) == 1){
								aux = a[p][q];
								a[p][q]=a[i][j];
								a[i][j] = 0;
								if (Chess (pl) == 0){
									ok = 0;
								}
								a[i][j]=a[p][q];
								a[p][q]=aux;
							}
						}
					}
				}
			}
		}
		if (ok == 1) {
			foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Yellow")) {
				Destroy (fooObj);
			}
			runGame = 0;
			Pion.SetActive(true);
			fillA.SetActive(true);
			fillB.SetActive(true);
			sfarsit.SetActive(true);
			if (player == 1){
				Debug.Log ("Check Mate! Player 2 has won!");
				fillA.GetComponent<Image>().color = new Color(225F, 0F, 0F, 1F);
				fillB.GetComponent<Image>().color = new Color(0F, 255F, 0F, 1F);
				sfarsitText.GetComponent<Text>().text = "Check Mate!\n Player 2 has won!";
			}
			else{
				Debug.Log ("Check Mate! Player 1 has won!");
				fillB.GetComponent<Image>().color = new Color(225F, 0F, 0F, 1F);
				fillA.GetComponent<Image>().color = new Color(0F, 255F, 0F, 1F);
				sfarsitText.GetComponent<Text>().text = "Check Mate!\n Player 1 has won!";
			}
		}
	}
	void Pat(){
		
	}

	int Chess(int p)
	{
		int i, j,x=0,y=0;
		for (i=1;i<=8;i++)
			for(j=1;j<=8;j++)
		{
			if (a[i][j] == p)
			{
				x=i;
				y=j;
			}
		}
		for (i=1;i<=8;i++)
			for(j=1;j<=8;j++)
		{
			if (i==x && j==y){

			}
			else{
				if (movePiece(i,j,x,y,0) == 1)
					return 1;
			}
		}
		return 0;
	}

	void select(int x,int y)
	{
		int i,j,aux,ok=0;
		for (i=1;i<=8;i++)
		for(j=1;j<=8;j++){
			if (i==x && y==j){
			}
			else{
				if (player == 1) {
						for (i=1;i<=8;i++){

							for (i=1 ; i<=8 ;i++){
								for (j=1;j<=8;j++){
									if (movePiece(x,y,i,j,1) == 1){
										aux = a[i][j];
										a[i][j]=a[x][y];
										a[x][y] = 0;
										if (Chess (6) == 0){
										ok=1;
										}
										a[x][y]=a[i][j];
										a[i][j]=aux;
										if (ok==1){
											ok=0;
											if (a[i][j] == 0)
												b[i][j]=1;
											else
												b[i][j]=2;
										}
									}
									if (a[x][y]==6){
										if ((rocada()==1 || rocada()==3) && i==8 && j==7){
											b[i][j] = 1;
										}
										if ((rocada()==2 || rocada()==3) && i==8 && j==3){
											b[i][j] = 1;
										}
									}
								}
							}

						}


				} else {
						for (i=1;i<=8;i++){
							
							for (i=1 ; i<=8 ;i++){
								for (j=1;j<=8;j++){
									if (movePiece(x,y,i,j,1) == 1){
										aux = a[i][j];
										a[i][j]=a[x][y];
										a[x][y] = 0;
										if (Chess (-6) == 0){
											ok=1;
										}
										a[x][y]=a[i][j];
										a[i][j]=aux;

										if (ok==1){
											ok=0;
											if (a[i][j] == 0)
												b[i][j]=1;
											else
												b[i][j]=2;
										}
									}
									if (a[x][y]==-6){
									if ((rocada()==1 || rocada()==3) && i==1 && j==7){
										b[i][j] = 1;
									}
									if ((rocada()==2 || rocada()==3) && i==1 && j==3){
										b[i][j] = 1;
									}
									}
								}
							}
							

					}

				}

			}
		}
	}


	int move(int x, int y, int x1, int y1){
		int ok = 0,aux,roc = 0 , hok=0;
		if (rocada () == 1) {
			roc = 1;
		}
		if (rocada () == 2) {
			roc = 2;
		}
		if (rocada () == 3) {
			roc = 3;
		}
		if (player == 1){

					aux = a[x1][y1];
					a[x1][y1] = a[x][y];
					a[x][y] = 0;
					if (Chess(6) == 0){
						Destroy (GameObject.Find (x1 + " " + y1));
						ok=1;	
							if (aux == -1){
								ktPB++;
							}
							if (aux == -2){
								ktTB++;
							}
							if (aux == -3){
								ktHB++;
							}
							if (aux == -4){
								ktBB++;
							}
							if (aux == -5){
								ktQB++;
							}
					}
					else{
						a[x][y] = a[x1][y1];
						a[x1][y1] = aux;
					}
					
		}
		if (player == 2){
			aux = a[x1][y1];
					a[x1][y1] = a[x][y];
					a[x][y] = 0;
					if (Chess(-6) == 0){
						Destroy (GameObject.Find (x1 + " " + y1));
						ok=1;	
							if (aux == 1){
								ktPA++;
							}
							if (aux == 2){
								ktTA++;
							}
							if (aux == 3){
								ktHA++;
							}
							if (aux == 4){
								ktBA++;
							}
							if (aux == 5){
								ktQA++;
							}
					}
					else{
						a[x][y] = a[x1][y1];
						a[x1][y1] = aux;
					}

		}
		
		if (ok == 1) {



			GameObject.Find("TextPB").GetComponent<Text>().text = ktPB.ToString();
			GameObject.Find("TextTB").GetComponent<Text>().text = ktTB.ToString();
			GameObject.Find("TextHB").GetComponent<Text>().text = ktHB.ToString();
			GameObject.Find("TextBB").GetComponent<Text>().text = ktBB.ToString();
			GameObject.Find("TextQB").GetComponent<Text>().text = ktQB.ToString();

			GameObject.Find("TextPA").GetComponent<Text>().text = ktPA.ToString();
			GameObject.Find("TextTA").GetComponent<Text>().text = ktTA.ToString();
			GameObject.Find("TextHA").GetComponent<Text>().text = ktHA.ToString();
			GameObject.Find("TextBA").GetComponent<Text>().text = ktBA.ToString();
			GameObject.Find("TextQA").GetComponent<Text>().text = ktQA.ToString();



			Destroy (GameObject.Find ("highlightBlue(Clone)"));
			deselect();
			
			foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Green"))
			{
				Destroy (fooObj);
			}

			if (a[x1][y1] == 6 && x1 == 8 && y1 == 3 && (roc == 2 || roc==3)){
				a[8][1] = 0;
				a[8][4] = 2;
				auxiliar = 81;
				/*
				GameObject.Find("8 1").transform.position = Vector3.Lerp(GameObject.Find("8 1").transform.position, GameObject.Find ("p83").transform.position, 1);
				GameObject.Find("8 1").transform.name = "8 3";*/
				regA = 0;
				hok=1;
			}
			if (a[x1][y1] == 6 && x1 == 8 && y1 == 7 && (roc == 1 || roc==3)){
				a[8][8] = 0;
				a[8][6] = 2;
				auxiliar = 88;
				/*
				GameObject.Find("8 8").transform.position = Vector3.Lerp(GameObject.Find("8 8").transform.position, GameObject.Find ("p85").transform.position, 1);
				GameObject.Find("8 8").transform.name = "8 5";*/
				
				regA = 0;
				hok=1;
			}
			if (a[x1][y1] == -6 && x1 == 1 && y1 == 3 && (roc == 2 || roc==3)){
				a[1][1] = 0;
				a[1][4] = -2;
				auxiliar = 11;
				/*
				GameObject.Find("8 1").transform.position = Vector3.Lerp(GameObject.Find("8 1").transform.position, GameObject.Find ("p83").transform.position, 1);
				GameObject.Find("8 1").transform.name = "8 3";*/
				regN = 0;
				hok=1;
			}
			if (a[x1][y1] == -6 && x1 == 1 && y1 == 7 && (roc == 1 || roc==3)){
				a[1][8] = 0;
				a[1][6] = -2;
				auxiliar = 18;
				/*
				GameObject.Find("8 1").transform.position = Vector3.Lerp(GameObject.Find("8 1").transform.position, GameObject.Find ("p83").transform.position, 1);
				GameObject.Find("8 1").transform.name = "8 3";*/
				regN = 0;
				hok=1;
			}


			/*
			GameObject.Find(x + " " + y).transform.position = Vector3.Lerp(GameObject.Find(x + " " + y).transform.position, GameObject.Find ("p"+x1+y1).transform.position, 1);
			GameObject.Find(x + " " + y).transform.name = x1 + " " +y1;
			*/

			int i,j;
			/*
			//AFISARE
			afisare = "";
			for (i=1; i <= 8; i++) {
				for (j=1; j <= 8;j++){
					afisare = afisare + a[i][j] + " ";
				}
				afisare = afisare + "\n";
			}
			
			
			Debug.Log(afisare);
			//AFISARE
			*/




			if (hok==0){
				auxiliar = 1;
				return 1;
			}
			else{
				return 1;
			}
		}
		return 0;
	}

	public void funcRet2(){
		 piesaInlocuita = 2;
	}
	public void funcRet3(){
		piesaInlocuita = 3;
	}
	public void funcRet4(){
		piesaInlocuita = 4;
	}
	public void funcRet5(){
		piesaInlocuita = 5;
	}



	private GameObject fillA;
	private GameObject fillB;
	private GameObject selPawnA;
	private GameObject selPawnB;
	private GameObject Pion;
	private float positiePA;
	private float positiePB;


	//STOP
	private string afisare = "";
	private GameObject clone;
	// Use this for initialization
	void Start () {
		runGame = 1;

		GameObject g;
		int i, j;

		string formare = "";

		isCheck = GameObject.Find ("Sah");
		isCheck.SetActive (false);

		floorMask = LayerMask.GetMask ("Floor");

		Pion = GameObject.Find ("Pion");
		Pion.SetActive(false);

		sfarsit = GameObject.Find ("SahMat");
		sfarsitText = GameObject.Find ("TextFinal");
		sfarsit.SetActive (false);

		selPawnB = GameObject.Find ("PawnSelectB");
		selPawnA = GameObject.Find ("PawnSelectA");
		positiePA = selPawnA.transform.position.y;
		positiePB = selPawnB.transform.position.y;

		selPawnA.SetActive(false);
		selPawnB.SetActive(false);


		fillA = GameObject.FindGameObjectWithTag ("FillA");
		fillB = GameObject.FindGameObjectWithTag ("FillB");


		if (player == 1) {
			fillA.SetActive(true);
			fillB.SetActive(false);
		} else {
			fillA.SetActive(false);
			fillB.SetActive(true);
		}


		for (i=1; i <= 8; i++) {
			for (j=1; j <= 8;j++){
				if (a[i][j]==1){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(pion , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==2){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(tura , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==3){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(cal , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==4){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(nebun , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==5){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(regina , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==6){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(rege , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}

				if (a[i][j]==-1){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(pionN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
				//	Debug.Log(clone.transform.name);
				}
				if (a[i][j]==-2){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(turaN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
				//	Debug.Log(clone.transform.name);
				}
				if (a[i][j]==-3){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(calN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
				//	Debug.Log(clone.transform.name);
				}
				if (a[i][j]==-4){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(nebunN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==-5){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(reginaN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
					//Debug.Log(clone.transform.name);
				}
				if (a[i][j]==-6){
					formare = "";
					formare = "p" + i.ToString() + j.ToString();
					g = GameObject.Find(formare);
					clone = Instantiate(regeN , g.transform.position , g.transform.rotation) as GameObject;
					clone.transform.name = i + " " + j;
				//	Debug.Log(clone.transform.name);
				}
			}
		}

		/*
		for (i=1; i <= 8; i++) {
			for (j=1; j <= 8;j++){
				afisare = afisare + b[i][j] + " ";
			}
			afisare = afisare + "\n";
		}


		Debug.Log(afisare);
		 */
		/*
		//STERGE
		alege = 1;
		selPawnA.SetActive(true);
		selPawnB.SetActive(true);
		moveP = 1;
		player = 2;
		//STERGE
		*/
	}

	void pawnCheck(){
		int i, j;

		if (player == 1) {
			xP = 1;
			for (i=1; i<=8; i++) {
				if (a [xP] [i] == 1) {
					yP = i;
					i = 8;
				}
			}
			if (yP != 0) {
				Pion.SetActive (true);
				selPawnA.SetActive (true);
				alege = 1;
				moveP = 1;
			}
			if (Chess(6)==1)
			{
				isCheck.SetActive(true);
				for (i=1;i<=8;i++){
					for(j=1;j<=8;j++){
						if (a[i][j] == 6)
						{
							cooX = i;
							cooY = j;
						}
					}
				}
				for (i=1;i<=8;i++){
					for(j=1;j<=8;j++){
						if (a[i][j] < 0 && movePiece(i,j,cooX,cooY,1) == 1)
						{
							Debug.Log ("Intra");
							clone = Instantiate(SahTile,GameObject.Find("p"+i+j).transform.position + new Vector3(0,0.01f,0),GameObject.Find("p"+i+j).transform.rotation) as GameObject;
						}
					}
				}
				
			}
		} else {
			xP = 8;
			for (i=1; i<=8; i++) {
				if (a [xP] [i] == -1) {
					yP = i;
					i = 8;
				}
			}
			if (yP != 0) {
				Pion.SetActive (true);
				selPawnB.SetActive (true);
				alege = 1;
				moveP = 1;
			}
			if (Chess(-6)==1)
			{
				isCheck.SetActive(true);
				for (i=1;i<=8;i++){
					for(j=1;j<=8;j++){
						if (a[i][j] == -6)
						{
							cooX = i;
							cooY = j;
						}
					}
				}
				for (i=1;i<=8;i++){
					for(j=1;j<=8;j++){
						if (a[i][j] > 0 && movePiece(i,j,cooX,cooY,1) == 1)
						{
							Debug.Log ("Intra");
							clone = Instantiate(SahTile,GameObject.Find("p"+i+j).transform.position + new Vector3(0,0.01f,0),GameObject.Find("p"+i+j).transform.rotation) as GameObject;
						}
					}
				}
			}
		}
	}


	private int mok = 0;
	private int mokk = 0;
	private int ok = 0;
	private int okk = 0;
	private string name = "";
	private string name2 = "";
	private int xx = 0;
	private int yy = 0;
	private int isMoving = 0;
	private int xm = 0;
	private int xm1 = 0;
	private int ym = 0;
	private int ym1 = 0;
	private int xP = 0;
	private int yP = 0;
	private int moveP = 0;
	// Update is called once per frame
	void Update () {
		if (runGame == 1) {


			string formare = "";
			string form;
			int i, j, x, y; // xx,yy coo piesa selectata

			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit floorHit;

			if (alege == 1) {
				foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Yellow")) {
					Destroy (fooObj);
				}
				if (moveP == 0) {
					if (player == 2) {
						if (piesaInlocuita == 2) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (tura, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = 2;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnA.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 3) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (cal, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = 3;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnA.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 4) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (nebun, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = 4;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnA.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 5) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (regina, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = 5;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnA.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
					} else {
						if (piesaInlocuita == 2) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (turaN, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = -2;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnB.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 3) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (calN, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = -3;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnB.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 4) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (nebunN, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = -4;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnB.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
						if (piesaInlocuita == 5) {
							formare = xP + " " + yP;
							Destroy (GameObject.Find (formare));
							clone = Instantiate (reginaN, GameObject.Find ("p" + xP + yP).transform.position, GameObject.Find ("p" + xP + yP).transform.rotation) as GameObject;
							clone.name = formare;
							formare = "";
							alege = 0;
							a [xP] [yP] = -5;
							xP = 0;
							yP = 0;
							Pion.SetActive (false);
							selPawnB.SetActive (false);
							piesaInlocuita = 0;
							pawnCheck();
						}
					}
				} else {
					//Debug.Log (selPawnA.transform.position.y + " "+ selPawnB.transform.position.y +" " +positiePB);
					//Debug.Log(positiePB - selPawnB.transform.position.y);
					if (player == 2) {
						selPawnA.transform.position -= new Vector3 (0, 2, 0);
						if (positiePA - selPawnA.transform.position.y > 115f)
							moveP = 0;
					} else {
						selPawnB.transform.position -= new Vector3 (0, 2, 0);
						if (positiePB - selPawnB.transform.position.y > 115f)
							moveP = 0;
					}

				}

			} else {
		
				if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
					if (player == 1) {
						fillA.SetActive (true);
						fillB.SetActive (false);
					} else {
						fillA.SetActive (false);
						fillB.SetActive (true);
					}
					if (ok == 1) {

						if (floorHit.transform.name != name) {
							ok = 0;
							//	Destroy (GameObject.Find ("highlight(Clone)"));
							foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Yellow")) {
								Destroy (fooObj);
							}
						}
					}
					if (ok == 0 && floorHit.transform.name != name2) {
						Instantiate (highlightSelect, floorHit.transform.position, floorHit.transform.rotation);
						ok = 1;
						name = floorHit.transform.name;
					}


					//	Debug.Log (floorHit.transform.name);

					form = name.Substring (1, 1);
					x = Int32.Parse (form);

					form = name.Substring (2, 1);
					y = Int32.Parse (form);

					if (isMoving == 0) {
						if (Input.GetMouseButtonDown (0)) {
							if (okk == 0) {      //select
								if (player == 1 && a [x] [y] > 0) {
									Instantiate (highlightBlue, floorHit.transform.position, floorHit.transform.rotation);
									okk = 1;
									name2 = floorHit.transform.name;
									//Destroy (GameObject.Find ("highlight(Clone)"));

									foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Yellow")) {
										Destroy (fooObj);
									}

									ok = 0;

									form = name.Substring (1, 1);
									xx = Int32.Parse (form);
						
									form = name.Substring (2, 1);
									yy = Int32.Parse (form);

								}
								if (player == 2 && a [x] [y] < 0) {
									Instantiate (highlightBlue, floorHit.transform.position, floorHit.transform.rotation);
									okk = 1;
									name2 = floorHit.transform.name;
									//Destroy (GameObject.Find ("highlight(Clone)"));


									foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Yellow")) {
										Destroy (fooObj);
									}


									ok = 0;

									form = name.Substring (1, 1);
									xx = Int32.Parse (form);
						
									form = name.Substring (2, 1);
									yy = Int32.Parse (form);

								}

								if (xx != 0 && yy != 0) {
									select (xx, yy);

									//Debug.Log ("text");

									for (i=1; i<=8; i++) {
										for (j=1; j<=8; j++) {
											if (b [i] [j] == 1) {
												Instantiate (highlightGreen, GameObject.Find ("p" + i + j).transform.position, GameObject.Find ("p" + i + j).transform.rotation);
											}
											if (b [i] [j] == 2) {
												Instantiate (highlightRed, GameObject.Find ("p" + i + j).transform.position, GameObject.Find ("p" + i + j).transform.rotation);
											}
										}
									}
								}
								/*
					//AFISARE
					afisare = "";
					for (i=1; i <= 8; i++) {
						for (j=1; j <= 8;j++){
							afisare = afisare + b[i][j] + " ";
						}
						afisare = afisare + "\n";
					}
					
					
					Debug.Log(afisare);
					//AFISARE
					 */

							} else {


								if (name2 == floorHit.transform.name) {	     //deselect
									okk = 0;
									Destroy (GameObject.Find ("highlightBlue(Clone)"));
									name2 = "";
									xx = 0;
									yy = 0;
									deselect ();

									foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Green")) {
										Destroy (fooObj);
									}

								} else {
									if (b [x] [y] > 0 && (movePiece (xx, yy, x, y, 1) == 1 || ((rocada () == 1 || rocada () == 2 || rocada () == 3) && (a [xx] [yy] == 6 && x == 8 && (y == 3 || y == 7)))
										|| ((rocada () == 1 || rocada () == 2 || rocada () == 3) && (a [xx] [yy] == -6 && x == 1 && (y == 3 || y == 7))))) {
										/*if (a[x][y]==6){
								if ((rocada()==1 || rocada()==3) && x1==8 && y1==2){
									ok=1;
								}
								if ((rocada()==2 || rocada()==3) && x1==8 && y1==6){
									ok=1;
								}
							}*/
										if (move (xx, yy, x, y) > 0) {

											if (a [x] [y] == 2 && xx == 8 && yy == 1) {
												t81 = 0;
											}
											if (a [x] [y] == 2 && xx == 8 && yy == 8) {
												t88 = 0;
											}
											if (a [x] [y] == -2 && xx == 1 && yy == 1) {
												t11 = 0;
											}
											if (a [x] [y] == -2 && xx == 1 && yy == 8) {
												t18 = 0;
											}
											if (a [x] [y] == 6 && xx == 8 && yy == 5) {
												regA = 0;
											}
											if (a [x] [y] == -6 && xx == 1 && yy == 5) {
												regN = 0;
											}
								
											xm = xx;
											ym = yy;
											xm1 = x;
											ym1 = y;

											name2 = "";
											xx = 0;
											yy = 0;
											deselect ();
											okk = 0;
											isMoving = 1;
										}
									}
									/*
						//AFISARE
						afisare = "";
						for (i=1; i <= 8; i++) {
							for (j=1; j <= 8;j++){
								afisare = afisare + a[i][j] + " ";
							}
							afisare = afisare + "\n";
						}
						
						
						Debug.Log(afisare);
						//AFISARE
						*/
								}

							}
						}

					} else {
						if (auxiliar == 1) {

							GameObject.Find (xm + " " + ym).transform.position = Vector3.Lerp (GameObject.Find (xm + " " + ym).transform.position, GameObject.Find ("p" + xm1 + ym1).transform.position, speed);
							if (Vector3.Distance (GameObject.Find (xm + " " + ym).transform.position, GameObject.Find ("p" + xm1 + ym1).transform.position) < 0.1f) {
								GameObject.Find (xm + " " + ym).transform.name = xm1 + " " + ym1;
								auxiliar = 0;
								isMoving = 0;
							}


						} else {
							if (mok == 0) {
								GameObject.Find (xm + " " + ym).transform.position = Vector3.Lerp (GameObject.Find (xm + " " + ym).transform.position, GameObject.Find ("p" + xm1 + ym1).transform.position, speed);
								if (Vector3.Distance (GameObject.Find (xm + " " + ym).transform.position, GameObject.Find ("p" + xm1 + ym1).transform.position) < 0.1f) {
									GameObject.Find (xm + " " + ym).transform.name = xm1 + " " + ym1;
									mok = 1;

								}
							}

							if (auxiliar == 81 && mokk == 0) {
								GameObject.Find ("8 1").transform.position = Vector3.Lerp (GameObject.Find ("8 1").transform.position, GameObject.Find ("p84").transform.position, speed);
								if (Vector3.Distance (GameObject.Find ("8 1").transform.position, GameObject.Find ("p84").transform.position) < 0.1f) {
									GameObject.Find ("8 1").transform.name = "8 4";
									mokk = 1;
								}
							}
							if (auxiliar == 88 && mokk == 0) {

								GameObject.Find ("8 8").transform.position = Vector3.Lerp (GameObject.Find ("8 8").transform.position, GameObject.Find ("p86").transform.position, speed);
								/*GameObject.Find("8 8").transform.name = "8 5";*/
								if (Vector3.Distance (GameObject.Find ("8 8").transform.position, GameObject.Find ("p86").transform.position) < 0.1f) {
									GameObject.Find ("8 8").transform.name = "8 6";
									mokk = 1;
								}

							}
							if (auxiliar == 11 && mokk == 0) {
								GameObject.Find ("1 1").transform.position = Vector3.Lerp (GameObject.Find ("1 1").transform.position, GameObject.Find ("p14").transform.position, speed);
								if (Vector3.Distance (GameObject.Find ("1 1").transform.position, GameObject.Find ("p14").transform.position) < 0.1f) {
									GameObject.Find ("1 1").transform.name = "1 4";
									mokk = 1;
								}
							}
							if (auxiliar == 18 && mokk == 0) {
						
								GameObject.Find ("1 8").transform.position = Vector3.Lerp (GameObject.Find ("1 8").transform.position, GameObject.Find ("p16").transform.position, speed);
								/*GameObject.Find("8 8").transform.name = "8 5";*/
								if (Vector3.Distance (GameObject.Find ("1 8").transform.position, GameObject.Find ("p16").transform.position) < 0.1f) {
									GameObject.Find ("1 8").transform.name = "1 6";
									mokk = 1;
								}
						
							}
							if (mok == 1 && mokk == 1) {

								isMoving = 0;
								auxiliar = 0;
								mok = 0;
								mokk = 0;
							}

						}
						if (isMoving == 0) {
							// ---->>SAHTILE
							foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SahTile")) {
								Destroy (fooObj);
							}

							isCheck.SetActive(false);
							// ---->>SAHTILE
							if (player == 1) {
								xP = 1;
								for (i=1; i<=8; i++) {
									if (a [xP] [i] == 1) {
										yP = i;
										i = 8;
									}
								}
								if (yP != 0) {
									Pion.SetActive (true);
									selPawnA.SetActive (true);
									alege = 1;
									moveP = 1;
								}

								player = 2;
								if (Chess(-6)==1)
								{
									isCheck.SetActive(true);
									for (i=1;i<=8;i++){
										for(j=1;j<=8;j++){
											if (a[i][j] == -6)
											{
												cooX = i;
												cooY = j;
											}
										}
									}
									for (i=1;i<=8;i++){
										for(j=1;j<=8;j++){
											if (a[i][j] > 0 && movePiece(i,j,cooX,cooY,1) == 1)
											{
												Debug.Log ("Intra");
												clone = Instantiate(SahTile,GameObject.Find("p"+i+j).transform.position + new Vector3(0,0.01f,0),GameObject.Find("p"+i+j).transform.rotation) as GameObject;
											}
										}
									}

								}
							} else {
								xP = 8;
								for (i=1; i<=8; i++) {
									if (a [xP] [i] == -1) {
										yP = i;
										i = 8;
									}
								}
								if (yP != 0) {
									Pion.SetActive (true);
									selPawnB.SetActive (true);
									alege = 1;
									moveP = 1;
								}

								player = 1;
								if (Chess(6)==1)
								{
									isCheck.SetActive(true);
									for (i=1;i<=8;i++){
										for(j=1;j<=8;j++){
											if (a[i][j] == 6)
											{
												cooX = i;
												cooY = j;
											}
										}
									}
									for (i=1;i<=8;i++){
										for(j=1;j<=8;j++){
											if (a[i][j] < 0 && movePiece(i,j,cooX,cooY,1) == 1)
											{
												Debug.Log ("Intra");
												clone = Instantiate(SahTile,GameObject.Find("p"+i+j).transform.position + new Vector3(0,0.01f,0),GameObject.Find("p"+i+j).transform.rotation) as GameObject;
											}
										}
									}
								}
							}
							SahMat ();
							Pat();
						}
					}
				}


	
			}
		}
	}
}
