using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private int MaxSpeed, CurSpeed;
    public GameObject deathImage, victoryImage;
    public static bool isDead = false;
    public static bool HasWon = false;
    public Vector3 targetPosition;
    public float moveDistance;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        CurSpeed = 1;
        MaxSpeed = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Death();
        }
        else if (other.tag == "Respawn")
        {

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
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.isPlayerTurn == false)
        {
            CurSpeed = MaxSpeed;
        }
        else
        {
            Debug.Log(Vector3.Distance(transform.position, targetPosition));

            if (Vector3.Distance(transform.position, targetPosition) > Mathf.Epsilon)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, 8 * Time.deltaTime);

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    targetPosition += Vector3.forward * moveDistance;
                    CurSpeed -= 1;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    targetPosition += Vector3.back * moveDistance;
                    CurSpeed -= 1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    targetPosition += Vector3.right * moveDistance;
                    CurSpeed -= 1;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    targetPosition += Vector3.left * moveDistance;
                    CurSpeed -= 1;
                }
                else
                {

                }
            }
        }
        if (isDead == false)
        {

        }
    }
}
