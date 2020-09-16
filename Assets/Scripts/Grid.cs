using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int height;
    public int width;
    private float cellSize;
    private int[,] gridArray;
    Node[,] node;
    Transform[,] buildings;
    public float moveSpeed = 0;
    //Vector2Int currentNodeIndex
    //Vector2Int nextNodeIndex
    //Vector3.lerp(node[currentNodeIndex.x][currentNodeIndex.y], node[nextNodeIndex.x][nextNodeIndex.y]

    public void GetPosition(Transform _transform, Vector2Int _currentIndex, Vector2Int _nextIndex, float _factor)
    {
        Vector3 start = buildings[_currentIndex.x, _currentIndex.y].position;
        Vector3 end = buildings[_nextIndex.x, _nextIndex.y].position;
        _transform.position = Vector3.Lerp(start, end, _factor);
    }

    public void Setup(int width, int height, float cellSize, GameObject Building)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];
        buildings = new Transform[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Vector3 worldPoint = new Vector3(x * cellSize, 0, y * cellSize);
                buildings[x,y] = Instantiate(Building, worldPoint, Quaternion.identity).transform;
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
