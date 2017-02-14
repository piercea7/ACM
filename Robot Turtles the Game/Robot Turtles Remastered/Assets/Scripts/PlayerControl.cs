using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameManager manager;
	public GameBoard board;
	public Tile currentTile; //not sure what to do with this yet, or if it is used
	private int direction = 0; //internal handle for where you're facing
	
	// Use this for initialization
	void Start () {
		transform.Translate = new Vector3(currentTile.getX(), currentTile.getY, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void turnLeft(){
		//Turns the turtle counter-clockwise
		transform.Rotate(0, 270, 0);
		if(--direction < 0)
			direction = 3;
	}

	public void turnRight(){
		//Turns the turtle clockwise
		transform.Rotate(0, 90, 0);
		if(++direction > 3)
			direction = 0;
	}

	public void moveForward(){
		switch(direction){
			case 0:{
				Tile target = board.getAdjacentUp(currentTile);
				if(!target.getOccupied()) {}//Do stuff
				break;
			}
		//I need to know how the board is set up to do this.
		//It will check to see if the space in front of it is empty or a puddle.
		//If so, it will move into that space.
	}

	public void fireLaser(){
		//I need information on the board.
		//This will look at whatever is in the tile in front of it.
		//If it's an ice wall, it will melt it.
	}
}
