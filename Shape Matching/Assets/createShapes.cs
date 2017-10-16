using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createShapes : MonoBehaviour {

	public Transform Circle;
	public Transform Triangle;
	public Transform Square;
	public Transform Pentagon;
	public Transform Hexagon;

	public GameObject[] circleList;
	public GameObject[] triangleList;
	public GameObject[] squareList;
	public GameObject[] pentagonList;
	public GameObject[] hexagonList;

	public int shapeNum = 10;
	public bool trigger = true;

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
	}
	
	// Update is called once per frame
	void Update () {
		circleList = GameObject.FindGameObjectsWithTag ("Match Circle");
		triangleList = GameObject.FindGameObjectsWithTag ("Match Triangle");
		squareList = GameObject.FindGameObjectsWithTag ("Match Square");
		pentagonList = GameObject.FindGameObjectsWithTag ("Match Pentagon");
		hexagonList = GameObject.FindGameObjectsWithTag ("Match Hexagon");

		if(!(checkShape(circleList) || checkShape(triangleList) || checkShape(squareList) || checkShape(pentagonList) || checkShape(hexagonList))){
			trigger = true;
		}

		if (trigger) {
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
				randnum = Random.Range (1, 6);

				//create a pair of circles
				if (randnum == 1) {
					//set the shapes position
					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}

					//create the shape, and mark off the position
					Instantiate (Circle, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
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

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}

					//create the shape, and mark off the position
					Instantiate (Triangle, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
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

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}

					//create the shape, and mark off the position
					Instantiate (Square, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
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

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}

					//create the shape, and mark off the position
					Instantiate (Pentagon, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
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

					//make sure the position isn't taken
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}

					//create the shape, and mark off the position
					Instantiate (Hexagon, new Vector3(xVal, yVal, 0), Quaternion.identity);

					//repeat for it's pair
					xVals [i * 2] = xVal;
					yVals [i * 2] = yVal;

					xVal = Random.Range(-5, 6) * 2;
					yVal = Random.Range(-2, 3) * 2;
					while(checkArray(xVal, yVal, xVals, yVals)){
						xVal = Random.Range(-5, 6) * 2;
						yVal = Random.Range(-2, 3) * 2;
					}
					Instantiate (Hexagon, new Vector3(xVal, yVal, 0), Quaternion.identity);
					xVals [(i * 2) + 1] = xVal;
					yVals [(i * 2) + 1] = yVal;
				}
			}
			trigger = false;
		}
	}
}
