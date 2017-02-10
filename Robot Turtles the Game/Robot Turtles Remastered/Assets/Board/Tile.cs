using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    private bool isOccupied;
    private const int TILE_SIZE = 2;
    private int myX;
    private int myY;
    public Tile(int x, int y)
    {
        myX = x;
        myY = y;
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
    public bool getIsOccupied()
    {
        return isOccupied;
    }
    public void setIsOccupied(bool occupied)
    {
        isOccupied = occupied;
    }
    public int getTile_Size()
    {
        return TILE_SIZE;
    }
    public void setMyX(int x)
    {
        myX = x;
    }
    public void setMyY(int y)
    {
        myY = y;
    }
    public int getMyX()
    {
        return myX;
    }
    public int getMyY()
    {
        return myY;
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
