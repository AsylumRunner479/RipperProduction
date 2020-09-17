using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{

    public Grid grid;
    public GameManager game;
    public Vector2Int currentIndex, nextIndex, playerIndex;
    [Tooltip("The amount of time it takes to move from one node to the next.")]
    public float maxTime = 1;
    private int MaxSpeed, CurSpeed;
    private float currentTime = 0;
    private int number0;
    // Start is called before the first frame update
    void Start()
    {
        CurSpeed = 2;
        MaxSpeed = 2;
        playerIndex = new Vector2Int(2, 1);
        currentIndex = new Vector2Int(1, 2);
        nextIndex = currentIndex;
        currentTime = maxTime;
    }
    private void RandomX(int number)
    {
        number0 = Random.Range(0, number);
    }
    public void Move()
    {
        CurSpeed -= 1; 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.isPlayerTurn == true)
        {
            CurSpeed = MaxSpeed;
            //playerIndex = 
        }
        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            grid.GetPosition(transform, currentIndex, nextIndex, Mathf.Clamp01(currentTime / maxTime));
        }
        else
        {


            if (CurSpeed <= 0)
            {

                game.StartPlayerTurn();
            }

            //targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextIndex.y + 1 <= grid.height - 1)
            {
                currentIndex = nextIndex;
                nextIndex.y++;
                currentTime = 0;
                CurSpeed -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextIndex.y - 1 >= 0)
            {
                currentIndex = nextIndex;
                nextIndex.y--;
                currentTime = 0;
                CurSpeed -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextIndex.x + 1 <= grid.width - 1)
            {
                currentIndex = nextIndex;
                nextIndex.x++;
                currentTime = 0;
                CurSpeed -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextIndex.x + 1 >= 0)
            {
                currentIndex = nextIndex;
                nextIndex.x--;
                currentTime = 0;
                CurSpeed -= 1;
            }
        }
    }
}
