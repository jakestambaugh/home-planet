using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour {

    private Rigidbody2D rb;
    private AudioSource boostAudio;
    public float thrust = 5;
    public float torque = 0.5f;

    public RocketJuice rj;
    public RocketJuice lt;
    public RocketJuice rt;
    public bool exploding = false;

    public DeployLandingGear dlg;

    public GameObject splosion;

    float maxSpeed = 6.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dlg = GetComponentInChildren<DeployLandingGear>();
        boostAudio = GetComponent<AudioSource>();
        boostAudio.Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2") || Input.GetButton("Fire1")) {
            rj.IncreaseRocketAnimation();
            rb.AddForce(this.transform.up * thrust, ForceMode2D.Force);
            boostAudio.UnPause();
        }
        else
        {
            boostAudio.Pause();
        }

        if(Input.GetAxis("Horizontal") > .05){
            //this.transform.Rotate(Vector3.right * Time.deltaTime * 10);
            lt.IncreaseRocketAnimation();
            rb.AddTorque(Input.GetAxis("Horizontal") * -1.25f, ForceMode2D.Force);
        }
        if(Input.GetAxis("Horizontal") < -.05){
            //this.transform.Rotate(Vector3.left * Time.deltaTime * 10);
            rt.IncreaseRocketAnimation();
            rb.AddTorque(Input.GetAxis("Horizontal") * -1.25f, ForceMode2D.Force);
        }
	}

    void FixedUpdate()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(dlg.nearPlanet != true)
        {
            GameObject explosion = (GameObject) Instantiate(splosion, transform.position, transform.rotation);
            exploding = true;
        }
    }

    public void MoveToCenter()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void ArrestMotion()
    {
        rb.velocity = Vector2.zero;
    }
}
