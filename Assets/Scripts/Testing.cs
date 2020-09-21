using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject Building, home, knife, map, medic;
    public int x = 5;
    public int y = 5;
   private void Start()
    {
        //Grid grid = new Grid(x, y, 3, Building);
        FindObjectOfType<Grid>().Setup(x, y, 3, Building, home, knife, map, medic);
    }
}
