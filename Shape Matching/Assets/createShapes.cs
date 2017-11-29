using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class createShapes : MonoBehaviour {

	public Transform Circle;
	public Transform Triangle;
	public Transform Square;
	public Transform Pentagon;
	public Transform Hexagon;
	public Transform Hourglass;
	public Transform Trapezoid;
	public Transform Star;
	public Transform Moon;

	public GameObject[] circleList;
	public GameObject[] triangleList;
	public GameObject[] squareList;
	public GameObject[] pentagonList;
	public GameObject[] hexagonList;
	public GameObject[] hourglassList;
	public GameObject[] trapezoidList;
	public GameObject[] starList;
	public GameObject[] moonList;

	public int[] activeList = new int[9];
	int[,] errorTracker;

	public int shapeNum = 10;
	public bool trigger = true;
	public bool storyMode = false;
	public int levelNum = 0;

	bool checkArray(int checkInt, int checkInt2, int[] checkArray, int[] checkArray2){
		for (int i = 0; i < checkArray.Length; i++) {
			if (checkArray [i] == checkInt && checkArray2 [i] == checkInt2) {
				return(true);
			}
		}
		return(false);
	}

	bool checkShape(GameObject[] shapeList){
		foreach (GameObject shape in shapeList) {
			if (shape.activeSelf) {
				return(true);
			}
		}
		return(false);
	}

	// Use this for initialization
	void Start () {
		//check if it's story mode
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Story") {
			storyMode = true;
			shapeNum = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		circleList = GameObject.FindGameObjectsWithTag ("Match Circle");
		triangleList = GameObject.FindGameObjectsWithTag ("Match Triangle");
		squareList = GameObject.FindGameObjectsWithTag ("Match Square");
		pentagonList = GameObject.FindGameObjectsWithTag ("Match Pentagon");
		hexagonList = GameObject.FindGameObjectsWithTag ("Match Hexagon");
		hourglassList = GameObject.FindGameObjectsWithTag ("Match Hourglass");
		trapezoidList = GameObject.FindGameObjectsWithTag ("Match Trapezoid");
		starList = GameObject.FindGameObjectsWithTag ("Match Star");
		moonList = GameObject.FindGameObjectsWithTag ("Match Moon");

		if(!(checkShape(circleList) || checkShape(triangleList) || checkShape(squareList) || checkShape(pentagonList) || checkShape(hexagonList)
			|| checkShape(hourglassList) || checkShape(trapezoidList) || checkShape(starList) || checkShape(moonList))){
			trigger = true;

			//while in story mode, up the level if a level has been completed
			if(storyMode){
				levelNum += 1;
				shapeNum += 1;
				if (shapeNum > 6) {
					shapeNum = 6;
				}

				//if the player has won the game, go to the win screen
				if (levelNum == 10) {
					trigger = false;
					SceneManager.LoadScene ("CutScene2", LoadSceneMode.Single);
				}
			}
		}

		if (trigger) {
			errorTracker = GameObject.FindWithTag ("StaticObject").GetComponent<SceneAnalyzer> ().errortracker;
			int errorTot = 0;
			int errorNum = 0;
			for (int i = 0; i < errorTracker.GetLength (0); i++) {
				for(int j = 0; j < errorTracker.GetLength (1); j++){
					if (errorTracker [i, j] > 0) {
						errorNum++;
						errorTot += errorTracker [i, j];
					}
				}
			}

			int errorAvg = 0;
			if (errorNum > 0) {
				 errorAvg = errorTot / errorNum;
			}

			if (errorAvg > 10) {
				for (int i = 0; i < errorTracker.GetLength (0); i++) {
					for (int j = 0; j < errorTracker.GetLength (1); j++) {
						if (errorTracker [i, j] > errorAvg * 0.35f) {
							if (Random.value > 0.5f) {
								activeList [i] = -1;
							} else {
								activeList [j] = -1;
							}
						}
					}
				}
			}

			//if the number is out of range, select a random number in range
			if (shapeNum <= 0 || shapeNum > 20) {
				shapeNum = Random.Range (1, 21);
			}

			//set up for the shape creation
			int randnum;
			int xVal;
			int yVal;
			int[] xVals;
			xVals = new int[2*shapeNum];
			int[] yVals;
			yVals = new int[2*shapeNum];

			//first select which shape will be created, then create a pair of that shape
			// shapes cannot be spawned in the same location, and each is 2x2, so only allow even values
			for( int i = 0; i < shapeNum; i++){
				randnum = Random.Range (1, 10);
				while (activeList [randnum - 1] == -1) {
					randnum = Random.Range (1, 10);
				}

				//for story mode, limit which shapes can spawn depending on the level
				if(storyMode){
					randnum = Random.Range (1, levelNum + 1);
				}

				//create a pair of circles
				if (randnum == 1) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Circle, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Circle, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;

				} 

				//triangles
				else if (randnum == 2) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Triangle, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Triangle, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				} 

				//squares
				else if (randnum == 3) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Square, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Square, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				} 

				//pentagons
				else if (randnum == 4) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Pentagon, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Pentagon, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				} 

				//hexagons
				else if (randnum == 5) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Hexagon, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Hexagon, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}

				//trapezoids
				else if (randnum == 6) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Trapezoid, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Trapezoid, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}

				//hourglasses
				else if (randnum == 7) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Hourglass, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Hourglass, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}

				//stars
				else if (randnum == 8) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Star, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Star, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}

				//moons
				else if (randnum == 9) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}

					//create the shape, and mark off the position
					Instantiate (Moon, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					if (storyMode) {
						yVal = Random.Range(0, 3) * 2;
					}
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
						if (storyMode) {
							yVal = Random.Range(0, 3) * 2;
						}
					}
					Instantiate (Moon, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}
			}
			trigger = false;
		}
	}
}
