using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameGenerator : MonoBehaviour
{
    public TextMeshProUGUI clueText;
    public Camera mini;

    private Timer timer;

    public GameObject directionalIndicator;

    Planet[] planets;
    Queue<Planet> unpicked;
    List<Planet> picked;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        mini.rect = new Rect(0f, 0f, 0.3f, 0.3f);
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

    public void UpdateScore() {
        clueText.SetText("Thanks for dropping me off!");
        timer.UpdateScore();
    }

    public void SetupNewPassenger(){
        Planet startPlanet = GetNextPlanet();
        // Sets the passenger on the new planet
        PassengerPickupPoint ppp = startPlanet.GetComponent<PassengerPickupPoint>();
        DirectionIndicator di = directionalIndicator.GetComponent<DirectionIndicator>();

        Planet destinationPlanet = GetNextPlanet();
        Debug.Assert(startPlanet != destinationPlanet);
        clueText.SetText("Find a new passenger!");
        ppp.SetPassenger(destinationPlanet);
        di.SetCurrentDestination(startPlanet.GetObject());
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

    public void ShowClue(string clue) {
        clueText.SetText(clue);
    }
}
