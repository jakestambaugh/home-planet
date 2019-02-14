using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float rotationValueX;
    public float rotationValueY;
    public float rotationValueZ;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationValueX, rotationValueY, rotationValueZ);
    }
}
