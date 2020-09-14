using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    //public Shader blue;
    public GameObject mesh;
    public List<GameObject> neighbour;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Mathf.Infinity;
        FindNeighBour();
        
    }
    private void FindNeighBour()
    {
        neighbour = new List<GameObject>(GameObject.FindGameObjectsWithTag("Building"));

        Vector3 position = transform.position;
        while (neighbour.Count >= 6)
        {
            for (int i = 0; i < neighbour.Count; i++)
            {
                Vector3 diff = neighbour[i].transform.position - position;
                if (diff.sqrMagnitude >= 1)
                {
                    neighbour.RemoveAt(i);

                }

            }
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mesh.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mesh.SetActive(true);
        }
    }
    //public static void SetGlobalVector(Blue, );
    // Update is called once per frame
    void Update()
    {
        
    }
}
