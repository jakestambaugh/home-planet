
using UnityEngine;
/**
 * Pure data class to represent a passenger
 */
[System.Serializable]
public class Passenger : System.Object {
    [SerializeField]
    private Planet homeworld;
    private string clue;

    public Passenger(Planet homeworld) {
        this.homeworld = homeworld;
        clue = homeworld.GetClue();
    }

    public string GetHomeworldClue(){
        return clue;
    }
    public Planet GetHomeworld()
    {
        return homeworld;
    }
}