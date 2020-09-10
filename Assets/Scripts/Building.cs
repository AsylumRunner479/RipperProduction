using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    //public Shader blue;
    public Renderer mesh;
    public GameObject[] neighbour;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Mathf.Infinity;
        //mesh = this.GetComponent<Renderer>();
        neighbour = GameObject.FindGameObjectsWithTag("Building");

        Vector3 position = transform.position;
        for (int i = 0; i < neighbour.Length; i++)
        {
            Vector3 diff = neighbour[i].transform.position - position;
            if (diff.sqrMagnitude >= 1f)
            {
                neighbour[i - 1] = neighbour[i];
               
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mesh.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mesh.enabled = true;
        }
    }
    //public static void SetGlobalVector(Blue, );
    // Update is called once per frame
    void Update()
    {
        
    }
}
