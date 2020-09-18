using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for(int y = 0; y < gridArray.GetLength(1); y++){
            for(int x = 0; x < gridArray.GetLength(0); x++){
                Testing.CreateCube(GetWorldPosition(x,y));
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,y) * cellSize;
    }

    public Vector2Int GetXY(Vector3 worldPosition){
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x / cellSize), Mathf.FloorToInt(worldPosition.y / cellSize));
    }

    public void SetValue(int x, int y, int value){
        if(x >= 0 && y >= 0 && x < width && y < height ){
            gridArray[x,y] = value;
            Debug.Log("Set Value: " + value + ", at x=" + x + ", y=" + y);
        }
    }
    public void SetValue(Vector3 worldPosition, int value){
        Vector2Int xy = GetXY(worldPosition);
        SetValue(xy.x, xy.y, value);
    }
    public int GetValue(int x, int y){
        return gridArray[x,y];
    }

    public void printGrid(){
        string s = "";
        for(int y = 0; y < gridArray.GetLength(1); y++){
            for(int x = 0; x < gridArray.GetLength(0); x++){
                s += gridArray[x,y].ToString();
            }
            s += "\n";
        }

        Debug.Log(s);
    }
    public int getWidth(){
        return width;
    }
    public int getHeight(){
        return height;
    }
}
