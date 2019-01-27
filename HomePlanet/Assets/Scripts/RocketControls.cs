using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {

    private Rigidbody2D rb;
    public float thrust = 5;
    public float torque = 0.5f;

    public RocketJuice rj;
    public RocketJuice lt;
    public RocketJuice rt;

    public DeployLandingGear dlg;

    public GameObject splosion;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dlg = GetComponentInChildren<DeployLandingGear>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2") || Input.GetButton("Fire1")) {
            rj.IncreaseRocketAnimation();
            rb.AddForce(this.transform.up * thrust, ForceMode2D.Force);
        }
        if(Input.GetAxis("Horizontal") > .4){
            //this.transform.Rotate(Vector3.right * Time.deltaTime * 10);
            lt.IncreaseRocketAnimation();
            rb.AddTorque(-torque, ForceMode2D.Force);
        }
        if(Input.GetAxis("Horizontal") < -.4){
            //this.transform.Rotate(Vector3.left * Time.deltaTime * 10);
            rt.IncreaseRocketAnimation();
            rb.AddTorque(torque, ForceMode2D.Force);
        }
	}
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(dlg.nearPlanet != true)
        {
            GameObject explosion = (GameObject) Instantiate(splosion, transform.position, transform.rotation);
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
