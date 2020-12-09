using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject EnemyTurn;
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

<<<<<<< Updated upstream
        //DontDestroyOnLoad(gameObject);
=======
<<<<<<< HEAD
       // DontDestroyOnLoad(gameObject);
=======
        //DontDestroyOnLoad(gameObject);
>>>>>>> 75bcc24aed85930eaebe8a2fd21ef19cf197f561
>>>>>>> Stashed changes

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
        EnemyTurn.SetActive(true);
    }
    public void StartPlayerTurn()
    {
        playerTurn = true;
        EnemyTurn.SetActive(false);
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
