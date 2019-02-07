using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField]
    private float rotationValueX;
    [SerializeField]
    private float rotationValueY;
    [SerializeField]
    private float rotationValueZ;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationValueX, rotationValueY, rotationValueZ);
    }
}
