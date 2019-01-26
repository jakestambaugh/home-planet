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
    private GameGenerator master;
    private PassengerState state;
    public GameObject bubble;

    private GameObject homeworld;

    void Start() {
        state = PassengerState.Off;
        master = FindObjectOfType<GameGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PassengerState.Waiting) {
            bubble.SetActive(true);
        }

        if (state == PassengerState.InFlight) {
           // bubble.SetActive(false);
           // homeworld = master.pickAndReturnNextPlanet();
          // Update some piece of UI to show their description of home
          // Set their target planet
          // Check if we have landed on their home planet, then switch to
          // "Arriving"
        }
        if (state == PassengerState.Arriving) {
            //message about arriving
            master.pickNextPlanet();
            state = PassengerState.Off;
        }
    }

    public void updatePassengerStatusPickup(){
        state = PassengerState.InFlight;
        bubble.SetActive(false);
        homeworld = master.pickAndReturnNextPlanet();
        Debug.Log("TAKE ME TO: " + homeworld.name);
    }

    public void updatePassengerStatusDrop()
    {
        state = PassengerState.Arriving;
        Debug.Log("I am at: " + homeworld.name);
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

    public string GetHomeworldClue(){
        return null;
    }
    public GameObject GetHomeworld()
    {
        return homeworld;
    }
}
