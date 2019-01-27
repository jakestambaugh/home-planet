using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    Planet[] planets;
    Queue<Planet> unpicked;
    List<Planet> picked;
    // Start is called before the first frame update
    void Start()
    {
        unpicked = new Queue<Planet>();
        picked = new List<Planet>();
        planets = GameObject.FindObjectsOfType<Planet>();
        List<Planet> ps = new List<Planet>();
        ps.AddRange(planets);
        Shuffle(ps);
        foreach (Planet p in ps) {
            unpicked.Enqueue(p);
        }
        SetupNewPassenger();
    }

    public void Update() {
    }

    public void SetupNewPassenger(){
        Planet startPlanet = GetNextPlanet();
        Debug.Log("Picked starting planet! " + startPlanet.name);
        // Sets the passenger on the new planet
        PassengerPickupPoint ppp = startPlanet.GetComponent<PassengerPickupPoint>();
        Planet destinationPlanet = GetNextPlanet();
        Debug.Log("Picked new planet! " + destinationPlanet.name);
        Debug.Assert(startPlanet != destinationPlanet);
        Debug.Log("Setting up the passenger");
        ppp.SetPassenger(destinationPlanet);
    }

    public Planet GetNextPlanet() {
        Planet newPlanet = unpicked.Dequeue();
        if (unpicked.Count == 0) {
           Shuffle(picked);
           foreach (Planet p in picked) {
               unpicked.Enqueue(p);
           }
           picked = new List<Planet>();
        }
        picked.Add(newPlanet);
        return newPlanet;
    }

    void Shuffle(List<Planet> a)
	{
		// Loops through array
		for (int i = a.Count-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			Planet temp = a[i];
			
			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}
	}
}
