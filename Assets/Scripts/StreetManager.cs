using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public GameObject rain, player;
    private float dist, sightRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sightRange = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= sightRange)
        {
            rain.SetActive(true);
        }
        else 
        {
            rain.SetActive(false);
        }
    }
}
