using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    private int MaxSpeed, CurSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Move()
    {
        CurSpeed -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.player == false)
        {
            CurSpeed = MaxSpeed;
        } 
    }
}
