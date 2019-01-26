using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSensor : MonoBehaviour
{
    private Collider2D cd;
    private PassengerSeat seat;
    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
        seat = GetComponent<PassengerSeat>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, 8);
        foreach(Collider2D check in nearby){
            if(cd.IsTouching(check)){
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1);
                if(hit.collider != null && hit.collider == check){
                    PassengerLifecycle pass = check.gameObject.GetComponent<PassengerLifecycle>();
                    if (!seat.HasPassenger() && pass.IsWaiting())
                    {
                        pass.updatePassengerStatusPickup();
                        seat.LoadPassenger(pass);
                    }
                    //if has passenger and planet is the target, switch to arriving
                    else if(seat.HasPassenger() && seat.GetPassengerHomeworld() == check)
                    {
                        pass.updatePassengerStatusDrop();
                        seat.UnloadPassenger();
                    }
                }
            }
        }
    }
}
