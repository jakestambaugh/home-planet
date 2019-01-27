using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    Component[] pe2d;
    public float magnitude = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        float planetRadius = GetComponent<CircleCollider2D>().bounds.size.x/2;
        pe2d = GetComponentsInChildren<PointEffector2D>();
        
        foreach (PointEffector2D pef in pe2d)
        {
            pef.forceMagnitude = planetRadius*magnitude;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
