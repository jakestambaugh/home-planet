using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    // Rotates attached object within the min/max bounds below in all 3 dimensions.
    [SerializeField] float minRotationAngle = 0f;
    [SerializeField] float maxRotationAngle = 0f;

    // Didn't inherit from this because I didn't want to have these properties in the inspector
    // Then again, the class was so stupid simple it probably wasn't worth reusing.
    Rotator rotator;
    void Start()
    {
        // rotator's Update() will be called automagically
        this.rotator = gameObject.AddComponent(typeof(Rotator)) as Rotator;
        rotator.rotationValueX = Random.Range(minRotationAngle, maxRotationAngle);
        rotator.rotationValueY = Random.Range(minRotationAngle, maxRotationAngle);
        rotator.rotationValueZ = Random.Range(minRotationAngle, maxRotationAngle);
        rotator.transform.parent = this.transform;
    }
}
