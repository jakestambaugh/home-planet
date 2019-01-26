using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSeat : MonoBehaviour
{
    PassengerLifecycle passenger;

    public void LoadPassenger(PassengerLifecycle p) {
        if (passenger == null) {
            passenger = p;
        }
    }

    public string GetPassengerClue() {
        return passenger.GetHomeworldClue();
    }

    public GameObject GetPassengerHomeworld() {
        return passenger.GetHomeworld();
    } 

    public PassengerLifecycle UnloadPassenger() {
        PassengerLifecycle p = passenger;
        passenger = null;
        return p;
    }

    public bool HasPassenger(){
        if(passenger == null){
            return false;
        }
        return true;
    }
}
