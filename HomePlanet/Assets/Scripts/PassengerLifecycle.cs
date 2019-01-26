using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLifecycle : MonoBehaviour
{
    private enum PassengerState {
        Waiting,
        InFlight,
        Arriving,
        Off
    }

    private PassengerState state;

    void Start() {
        state = PassengerState.Off;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PassengerState.Waiting) {
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (state == PassengerState.InFlight) {
            transform.GetChild(1).gameObject.SetActive(false);
          // Update some piece of UI to show their description of home
          // Set their target planet
          // Check if we have landed on their home planet, then switch to
          // "Arriving"
        }
        if (state == PassengerState.Arriving) {
            //message about arrival
            GameGenerator master = GameObject.FindObjectOfType<GameGenerator>();
            master.pickNextPlanet();
        }
    }

    public void updatePassengerStatusPickup(){
        state = PassengerState.InFlight;
    }

    public void updatePassengerStatusHelp(){
        state = PassengerState.Waiting;
    }
    public bool IsWaiting(){
        if(state == PassengerState.Waiting){
            return true;
        }
        return false;
    }
    public bool IsArriving()
    {
        if (state == PassengerState.Arriving)
        {
            return true;
        }
        return false;
    }
}
