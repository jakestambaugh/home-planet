
using UnityEngine;
/**
 * Pure data class to represent a passenger
 */
[System.Serializable]
public class Passenger : System.Object {
    [SerializeField]
    private Planet homeworld;

    public Passenger(Planet homeworld) {
        this.homeworld = homeworld;
    }

    public string GetHomeworldClue(){
        return homeworld.GetClue();
    }
    public Planet GetHomeworld()
    {
        return homeworld;
    }
}