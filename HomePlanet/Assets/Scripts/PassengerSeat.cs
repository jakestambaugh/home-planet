using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LandSensor))]
public class PassengerSeat : MonoBehaviour
{
    public GameGenerator gameMaster;
    [SerializeField]
    private Passenger passenger = null;

    private LandSensor sensor;

    void Start() {
        sensor = GetComponent<LandSensor>();
        passenger = null;
    }

    // Check every frame if we are over a planet that we could get a pickup from
    void Update() {
        Planet planetBelow = sensor.GetPlanetBelow();
        if (planetBelow != null) {
            // If we don't have a passenger on-board now, try to pick one up
            Debug.Log("Passenger " + passenger + ". Planet " + planetBelow);
            if (!HasPassenger()) {
                Debug.Log("Pickup!");
                PickupFromPlanet(planetBelow);
            }
            else {
                DropOffOnPlanet(planetBelow);
            }
        }
    }

    // Only attempts a pickup if there is a passenger available at the planet
    public void PickupFromPlanet(Planet planet) {
        PassengerPickupPoint pickup = planet.gameObject.GetComponent<PassengerPickupPoint>();
        if (pickup != null) {
            PickupFromPlanet(pickup);
        }
    }
    public void PickupFromPlanet(PassengerPickupPoint pickup) {
      Debug.Log("Pickup has passenger? " + pickup);
      if (pickup.HasPassenger()) {
        Debug.Log("Pickup has passenger " + pickup); 
        LoadPassenger(pickup.GetNextPassenger());
      }
    }

    public void DropOffOnPlanet(Planet planet) {
        Planet homePlanet = passenger.GetHomeworld();
        if(homePlanet == planet) {
            UnloadPassenger();
            // Ask the game manager to create another passenger
            gameMaster.SetupNewPassenger();
        }
    }

    public void LoadPassenger(Passenger p) {
        if (passenger == null || passenger.GetHomeworld() == null) {
            passenger = p;
        }
    }

    public string GetPassengerClue() {
        return passenger.GetHomeworldClue();
    }

    public Planet GetPassengerHomeworld() {
        return passenger.GetHomeworld();
    } 

    public Passenger UnloadPassenger() {
        Passenger p = passenger;
        passenger = null;
        return p;
    }

    public bool HasPassenger(){
        return passenger != null && passenger.GetHomeworld() != null;
    }
}
