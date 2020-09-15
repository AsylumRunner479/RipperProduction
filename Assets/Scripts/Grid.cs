using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int height;
    private int width;
    private float cellSize;
    private int[,] gridArray;
    Node[,] node;
    
   public void Setup(int width, int height, float cellSize, GameObject Building)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];
        
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Vector3 worldPoint = new Vector3(x * cellSize, 0, y * cellSize);
                Instantiate(Building, worldPoint, Quaternion.identity);
                
            }
        }
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    public void SetValue(int x, int y, int value)
    {
        //if (x >= 0 && y >= 0 && x <)
        {

        }
    }
}
