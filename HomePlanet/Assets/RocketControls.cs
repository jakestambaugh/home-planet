﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {

    private Rigidbody2D rb;
    public float thrust = 5;
    public float torque = 0.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")) {
            rb.AddForce(this.transform.up * thrust, ForceMode2D.Force);
        }
        if(Input.GetAxis("Horizontal") > .4){
            //this.transform.Rotate(Vector3.right * Time.deltaTime * 10);
            rb.AddTorque(-torque);
        }
        if(Input.GetAxis("Horizontal") < -.4){
            //this.transform.Rotate(Vector3.left * Time.deltaTime * 10);
            rb.AddTorque(torque);
        }
	}
}
