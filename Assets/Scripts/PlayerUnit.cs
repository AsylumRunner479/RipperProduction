using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private int MaxSpeed, CurSpeed;
    public GameObject deathImage, victoryImage;
    public static bool isDead = false;
    public static bool HasWon = false;
    public Vector2Int currentIndex,nextIndex;
    [Tooltip("The amount of time it takes to move from one node to the next.")]
    public float maxTime = 1;
    //public CharacterController controller;
    private int knife, map, medication;
    public bool hasKnife, hasMap, hasMedication;
    public GameObject[] inventory;
    public Grid grid;
    public GameManager game;

    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //targetPosition = transform.position;
        CurSpeed = 2;
        MaxSpeed = 2;
        currentIndex = new Vector2Int(5, 5);
        nextIndex = currentIndex;
        currentTime = maxTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && medication <= 1)
        {
            if (knife >= 1)
            {
                Win();
            }
            else
            {
                Death();
            }
            
        }
        else if (other.tag == "Respawn")
        {
            Win();
        }
        else if (other.tag == "medication")
        {
            hasMedication = true;
            inventory[0].SetActive(true);
        }
        else if (other.tag == "Knife")
        {
            hasKnife = true;
            inventory[1].SetActive(true);
        }
        else if (other.tag == "Map")
        {
            hasMap = true;
            inventory[2].SetActive(true);
        }
    }
    private void Death()
    {
        deathImage.SetActive(true);
        isDead = false;
    }
    private void Win()
    {
        victoryImage.SetActive(true);
        HasWon = true;
    }
    public void MoveUp(bool Up)
    {
        
        
    }
    private void powerDown()
    {
        knife--;
        medication--;
        map--;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (medication <= 0)
        {
            inventory[0].SetActive(false);
        }
        if (knife <= 0)
        {
            inventory[1].SetActive(false);
        }
        if (map <= 0)
        {
            inventory[2].SetActive(false);
        }
        if (GameManager.isPlayerTurn == false)
        {
            CurSpeed = MaxSpeed;
        }
        
        else
        {
            //Vector3 newPos = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);

            //if (Vector2.Distance(currentIndex,nextIndex) > Mathf.Epsilon)
            //{
            //    grid.GetPosition(transform, currentIndex, nextIndex);

            //}
            // If we haven't moved completely, add time to this frame
            if (currentTime < maxTime)
            {
                currentTime += Time.deltaTime;
                grid.GetPosition(transform, currentIndex, nextIndex, Mathf.Clamp01(currentTime / maxTime));
            }
            else
            {
                if (CurSpeed <= 0)
                {
                    powerDown();
                    game.EndPlayerTurn();
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
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    medication = 3;
                    hasMedication = false;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    knife = 1;
                    hasKnife = false;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    map = 3;
                    hasMap = false;
                }
            }
        }
        if (isDead == false)
        {

        }
    }
}
