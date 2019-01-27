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

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        rocketbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vel = Mathf.Clamp(rocketbody.velocity.magnitude, 0f, 100f);
        Vector3 playerPos = player.transform.position;
        float size = Mathf.Lerp(cam.orthographicSize, project(vel), Time.deltaTime * lerpSpeed);
        Vector3 camPos = new Vector3 (playerPos.x, playerPos.y, -700.0f);

        cam.orthographicSize = size;
        transform.position = camPos;
    }

    private float project(float velocity) {
        float scale = (velocity / 100f) * (biggest - smallest);
        float shift = scale + smallest;
        Debug.Log(shift);
        return shift;
    }
}
