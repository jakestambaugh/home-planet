using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSensor : MonoBehaviour
{
    private Collider2D cd;
    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, 8);
        foreach(Collider2D check in nearby){
            if(cd.IsTouching(check)){
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1);
                if(hit.collider == check){
                    if (check.gameObject.GetComponent<PassengerLifecycle>().IsWaiting())
                    {
                        check.gameObject.GetComponent<PassengerLifecycle>().updatePassengerStatusPickup();
                    }
                    else if (check.gameObject.GetComponent<PassengerLifecycle>().IsArriving())
                    {

                    }
                }
            }
        }
    }
}
