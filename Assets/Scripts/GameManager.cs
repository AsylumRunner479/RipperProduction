using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void EndPlayerTurn()
    {
        player = false;
    }
    public void StartPlayerTurn()
    {
        player = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
