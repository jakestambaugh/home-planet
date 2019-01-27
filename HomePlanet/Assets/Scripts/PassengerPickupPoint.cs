using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerPickupPoint : MonoBehaviour
{
    public GameObject helpBubble;
    private Passenger passenger;
    // Start is called before the first frame update

    public bool HasPassenger() {
        return passenger != null;
    }

    /**
     * This method can return null, and should only be called if it
     * has been checked that the other function has a Passenger
     */
    public Passenger GetNextPassenger() {
        if(HasPassenger()) {
            helpBubble.SetActive(false);
        }
        Passenger p = passenger;
        passenger = null;
        return p;
    }

    /**
     * Should only be called by the GameMaster entity when a new Passenger needs to be
     * generated
     */
    public void SetPassenger(Planet destination) {
        Debug.Log("Setting the passenger on planet");
        SetPassenger(new Passenger(destination));
    }

    public void SetPassenger(Passenger passenger) {
        Debug.Log("Setting the passenger with target: " + passenger.GetHomeworld());
        helpBubble.SetActive(true);
        this.passenger = passenger;
    }
}
