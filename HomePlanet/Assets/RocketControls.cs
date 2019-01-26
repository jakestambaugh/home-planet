using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {

    private Rigidbody2D rb;
    public float thrust = 5;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")) {
            rb.AddForce(this.transform.up * thrust, ForceMode2D.Force);
        }
	}
}
