using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployLandingGear : MonoBehaviour
{
    Animator anim;
    GameObject[] gameObjects;
    bool deployed = false;
    float animTime = 0.0f;
    float animRate = 0.015f;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(deployed == false)
            {
                deployed = true;
            }
            else
            {
                deployed = false;
            }
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
