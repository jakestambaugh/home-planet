
/**
 * Pure data class to represent a passenger
 */
public class Passenger {
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