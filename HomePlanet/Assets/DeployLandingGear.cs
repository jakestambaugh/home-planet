using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployLandingGear : MonoBehaviour
{
    Animator anim;
    GameObject[] gameObjects;
    bool deployed = false;
    float animTime = 0.0f;
    float animRate = 0.02f;

    bool nearPlanet = false;
    int nearcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObjects = GameObject.FindGameObjectsWithTag("Planet");
        anim.speed = 0.0f;

        foreach(GameObject plnt in gameObjects)
        {
            Debug.Log(plnt);
        }
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
            
            //Debug.Log("ypos: " + transform.position.y + ", distToPlanet: " + distToPlanet + ", planetRadius: " + planetRadius + ", distToPlanetSurface: " + distToPlanetSurface);

            if(distToPlanetSurface < 1.5)
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
