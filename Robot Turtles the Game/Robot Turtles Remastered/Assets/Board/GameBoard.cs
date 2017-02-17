using UnityEngine;
using System.Collections;

public class GameBoard : Tile {
    private Tile[,] board;
    private int boardSize;
    public GameBoard() : base(8, 8)
    {
        boardSize = 8;
        board = new Tile[boardSize, boardSize];
        
    }
    public Tile getAdjacentUP(Tile curTile)//double check here
    {
        if(curTile.getMyY() > 0)
        {
            curTile.setMyY(curTile.getMyY() - 1);
        }
        return curTile;
        
    }
    public Tile getAdjacentDOWN(Tile curTile)//double check here
    {
        if (curTile.getMyY() < boardSize - 1)
        {
            curTile.setMyY(curTile.getMyY() + 1);
        }
        return curTile;
    }
    public Tile getAdjacentLEFT(Tile curTile)//double check here
    {
        if (curTile.getMyX() > 0)
        {
            curTile.setMyX(curTile.getMyX() - 1);
        }
        return curTile;
    }
    public Tile getAdjacentRIGHT(Tile curTile)//double check here
    {
        if (curTile.getMyX() < boardSize - 1)
        {
            curTile.setMyX(curTile.getMyX() + 1);
        }
        return curTile;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
