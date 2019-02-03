using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; 

    public float smallest = 1.0f;
    public float biggest = 3.0f;

    public float topSpeed = 100f;

    public float lerpSpeed = 0.8f;

    private Rigidbody2D rocketbody;

    public RocketControls rc;

    private Camera cam;

    bool explosionDelayEnabled = false;
    Vector3 explosionPos;

    float delayTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        rocketbody = player.GetComponent<Rigidbody2D>();
        rc = player.GetComponentInChildren<RocketControls>();
    }

    // Update is called once per frame
    void Update()
    {
        float vel = Mathf.Clamp(rocketbody.velocity.magnitude, 0f, 100f);
        Vector3 playerPos = player.transform.position;
        
        if(rc.exploding == true && explosionDelayEnabled == false)
        {
            explosionDelayEnabled = true;
            explosionPos = new Vector3(playerPos.x, playerPos.y);
            rc.exploding = false;
            rc.MoveToCenter();
        }

        Vector3 camPos;
        if(explosionDelayEnabled == true)
        {
            camPos = new Vector3 (explosionPos.x, explosionPos.y, -700.0f);
            delayTime += Time.deltaTime;
            rc.ArrestMotion();

            if(delayTime > 2.0f)
            {
                explosionDelayEnabled = false;
                delayTime = 0.0f;
            }
        }
        else
        {
            camPos = new Vector3 (playerPos.x, playerPos.y, -700.0f);
        }

        float size = Mathf.Lerp(cam.orthographicSize, project(vel), Time.deltaTime * lerpSpeed);

        cam.orthographicSize = size+0.04f;
        
        if(cam.orthographicSize > 22.0f)
        {
            cam.orthographicSize = 22.0f;
        }

        transform.position = camPos;
    }

    private float project(float velocity) {
        float scale = (velocity / 100f) * (biggest - smallest);
        float shift = scale + smallest;

        return shift;
    }
}
