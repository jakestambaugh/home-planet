using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLifecycle : MonoBehaviour
{
    private enum PassengerState {
        Waiting,
        InFlight,
        Arriving
    }

    private PassengerState state;

    void Start() {
        state = PassengerState.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PassengerState.Waiting) {
          // Create the bubble, give the passenger a collider
          // When the rocket lands inside the collider, the passenger
          // describes their destination and moves into "InFlight"
        }

        if (state == PassengerState.InFlight) {
          // Update some piece of UI to show their description of home
          // Set their target planet
          // Check if we have landed on their home planet, then switch to
          // "Arriving"
        }
        if (state == PassengerState.Arriving) {
          // Unload them from the ship, make the Ship able to pick up a new
          // Passenger
          // Play a little animation of them departing
        }
    }
}
