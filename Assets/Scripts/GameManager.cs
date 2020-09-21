﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static bool isPlayerTurn
    {
        get
        {
            return instance.playerTurn;
        }
    }

    private bool playerTurn = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        playerTurn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPlayerTurn();
    }
    public void EndPlayerTurn()
    {
        playerTurn = false;
    }
    public void StartPlayerTurn()
    {
        playerTurn = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}