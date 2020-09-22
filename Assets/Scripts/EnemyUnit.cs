using UnityEngine;

public class EnemyUnit : MonoBehaviour
{

    public Grid grid;
    public GameManager game;
    public Vector2Int currentIndex, nextIndex, playerIndex;
    public GameObject player, enemy;
    [Tooltip("The amount of time it takes to move from one node to the next.")]
    public float maxTime = 1;
    private int MaxSpeed, CurSpeed;
    private float currentTime = 0;
    private int number0;
    public GameObject Marker;
    private PlayerUnit playerUnit;
    // Start is called before the first frame update
    void Start()
    {
        playerUnit = player.GetComponent<PlayerUnit>();

        CurSpeed = 2;
        MaxSpeed = 2;
        //playerIndex = new Vector2Int(2, 1);
        currentIndex = new Vector2Int(Random.Range(0, grid.width), Random.Range(0,grid.height));
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
            enemy.SetActive(false);
        }
        else
        {


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
                RandomX(3);
                if (number0 == 0)
                {
                    //if (player.transform.position.x > transform.position.x)
                    //{
                    //    currentIndex = nextIndex;
                    //    nextIndex.y++;
                    //    currentTime = 0;
                    //    CurSpeed -= 1;
                    //}
                    //else if (player.transform.position.x < transform.position.x)
                    //{
                    //    currentIndex = nextIndex;
                    //    nextIndex.y--;
                    //    currentTime = 0;
                    //    CurSpeed -= 1;
                    //}
                    //else if (player.transform.position.z > transform.position.z)
                    //{
                    //    currentIndex = nextIndex;
                    //    nextIndex.x++;
                    //    currentTime = 0;
                    //    CurSpeed -= 1;
                    //}
                    //else
                    //{
                    //    currentIndex = nextIndex;
                    //    nextIndex.x--;
                    //    currentTime = 0;
                    //    CurSpeed -= 1;
                    //}
                    if (playerUnit.currentIndex.y > currentIndex.y)
                    {
                        currentIndex = nextIndex;
                        nextIndex.y++;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else if (playerUnit.currentIndex.y < currentIndex.y)
                    {
                        currentIndex = nextIndex;
                        nextIndex.y--;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else if (playerUnit.currentIndex.x > currentIndex.x)
                    {
                        currentIndex = nextIndex;
                        nextIndex.x++;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else
                    {
                        currentIndex = nextIndex;
                        nextIndex.x--;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                }
                else if (number0 == 1)
                {
                    CurSpeed -= 1;
                    //enemy.SetActive(true);
                    currentTime = 0;
                    Instantiate(enemy, Marker.transform.position, Quaternion.identity);
                }
                else
                {
                    if (playerUnit.currentIndex.x > currentIndex.x)
                    {
                        currentIndex = nextIndex;
                        nextIndex.x++;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else if (playerUnit.currentIndex.x < currentIndex.x)
                    {
                        currentIndex = nextIndex;
                        nextIndex.x--;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else if (playerUnit.currentIndex.y > currentIndex.y)
                    {
                        currentIndex = nextIndex;
                        nextIndex.y++;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                    else
                    {
                        currentIndex = nextIndex;
                        nextIndex.y--;
                        currentTime = 0;
                        CurSpeed -= 1;
                    }
                }
                //targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
