using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "Create Planet", order = 1)]
public class PlanetData : ScriptableObject 
{
    public Transform location;

    public float radius;

    public float gravityRadius;
    public float gravityScale = 1.0f;

    public Texture texture;
}