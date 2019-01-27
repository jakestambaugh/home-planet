using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSensor : MonoBehaviour
{
    private Collider2D cd;

    public float raycastMagnitude = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
    }

    // Update from our original script. Currently dead code
    /*
    void OldUpdate()
    {
        PassengerSeat seat = GetComponent<PassengerSeat>();
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
    */

    /**
     * Gets the Collider2D of whatever GameObject is directly below the rocket.
     * This is intended to be used to detect the planet that we are landing on.
     */
    public Planet GetPlanetBelow() {
       RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1 * raycastMagnitude);
       if (hit.collider == null) {
           // Not hovering over anything
           return null;
       }

       if (!cd.IsTouching(hit.collider)) {
           // Hovering over, but not touching
           // Debug.Log("Near a " + hit.collider.name);
           return null;
       }

       GameObject objectUnderneathShip = hit.collider.gameObject;
       Planet planet = objectUnderneathShip.GetComponent<Planet>();
       // Returns null if we are hovering over something other than a planet, or the Planet
       // Debug.Log("Found a " + planet + " on the " + objectUnderneathShip);
       return planet;
    }
}
