﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployLandingGear : MonoBehaviour
{
    Animator anim;
    GameObject[] gameObjects;
    bool deployed = false;
    float animTime = 0.0f;
    float animRate = 0.04f;
    public bool nearPlanet = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObjects = GameObject.FindGameObjectsWithTag("Planet");
        anim.speed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Armature|LandingGearDeploy", 0, animTime);

        nearPlanet = false;

        foreach(GameObject planet in gameObjects)
        {
            // Find distance from rocket to planet surface
            float distToPlanet = Vector3.Distance(transform.position, planet.transform.position);
            float planetRadius = planet.GetComponent<CircleCollider2D>().bounds.size.x/2;
            float distToPlanetSurface = distToPlanet-planetRadius;

            Vector3 heading =   transform.position - planet.transform.position;
            Vector3 rocketOri = transform.TransformDirection(Vector3.up);
            var dotProduct = Vector3.Dot(heading, rocketOri);
            
            //Debug.Log("ypos: " + transform.position.y + ", distToPlanet: " + distToPlanet + ", planetRadius: " + planetRadius + ", distToPlanetSurface: " + distToPlanetSurface);

            if(distToPlanetSurface < 1.5 && (dotProduct > (distToPlanet-1.0f) && dotProduct < (distToPlanet+1.0f)))
            {
                nearPlanet = true;
            }
        }

        if(nearPlanet == true)
        {
            deployed = true;
        }
        else
        {
            deployed = false;
        }

        if(deployed == true)
        {
            animTime += animRate;
            if(animTime > 1.0f)
            {
                animTime = 1.0f;
            }
        }
        else
        {
            animTime -= animRate;
            if(animTime < 0.0f)
            {
                animTime = 0.0f;
            }
        }
    }
}
