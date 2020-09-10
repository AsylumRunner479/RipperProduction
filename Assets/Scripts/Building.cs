using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private GameObject player;
    public Shader blue;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    //public static void SetGlobalVector(Blue, );
    // Update is called once per frame
    void Update()
    {
        
    }
}
