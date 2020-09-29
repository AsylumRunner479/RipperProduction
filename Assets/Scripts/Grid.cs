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
    public Transform buildingHolder;
    public float moveSpeed = 0;
    private int homeX, homeY;
    public bool homeSpawn = false;
    private int random0;
    //Vector2Int currentNodeIndex
    //Vector2Int nextNodeIndex
    //Vector3.lerp(node[currentNodeIndex.x][currentNodeIndex.y], node[nextNodeIndex.x][nextNodeIndex.y]
    public void RandomX(int random)
    {
        random0 = Random.Range(0, random - 1);
    }
    public void GetPosition(Transform _transform, Vector2Int _currentIndex, Vector2Int _nextIndex, float _factor)
    {

        Vector3 start = buildings[_currentIndex.x, _currentIndex.y].position;
        Vector3 end = buildings[_nextIndex.x, _nextIndex.y].position;
        _transform.rotation = Quaternion.LookRotation((end - start).normalized);
        _transform.position = Vector3.Lerp(start, end, _factor);
    }

    public void Setup(int width, int height, float cellSize, GameObject Building, GameObject home, GameObject knife, GameObject map, GameObject medic)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];
        buildings = new Transform[width, height];
        homeX = Random.Range(0, 2);
        homeY = Random.Range(0, 2);
        while (homeSpawn == false)
        {
            foreach (Transform child in buildingHolder)
            {
                Destroy(child.gameObject);
            }
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    Vector3 worldPoint = new Vector3(x * cellSize, 0, y * cellSize);

                    if (x == homeX && y == homeY)
                    {
                        RandomX(4);
                        if (random0 == 0)
                        {
                            buildings[x, y] = Instantiate(knife, worldPoint, Quaternion.identity, buildingHolder).transform;
                        }
                        else if (random0 == 1)
                        {
                            buildings[x, y] = Instantiate(map, worldPoint, Quaternion.identity, buildingHolder).transform;
                        }
                        else if (random0 == 2 && homeSpawn == false)
                        {
                            buildings[x, y] = Instantiate(home, worldPoint, Quaternion.identity, buildingHolder).transform;
                            homeSpawn = true;
                        }
                        else
                        {
                            buildings[x, y] = Instantiate(medic, worldPoint, Quaternion.identity, buildingHolder).transform;
                        }
                        homeX += Random.Range(0, 2);
                        if (homeX >= width)
                        {
                            homeX = Random.Range(0, 2);
                        }
                        homeY += Random.Range(0, 2);
                        if (homeY >= height)
                        {
                            homeX = Random.Range(0, 2);
                        }
                    }
                    else
                    {
                        buildings[x, y] = Instantiate(Building, worldPoint, Quaternion.identity, buildingHolder).transform;
                    }

                }
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
