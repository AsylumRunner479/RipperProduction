﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
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
        if (GameManager.player == true)
        {
            CurSpeed = MaxSpeed;
        }
    }
}
