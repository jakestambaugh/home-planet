using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    GameObject[] planets;
    HashSet<int> picked;
    // Start is called before the first frame update
    void Start()
    {
        picked = new HashSet<int>();
        planets = GameObject.FindGameObjectsWithTag("Planet");
        int test = Random.Range(0, planets.Length);
        GameObject q = planets[test];
        Debug.Log(q);
        picked.Add(test);
        planets[test].gameObject.GetComponent<PassengerLifecycle>().updatePassengerStatusHelp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickNextPlanet(){
        int newPlanet = Random.Range(0, planets.Length);
        while(picked.Contains(newPlanet)){
            newPlanet = Random.Range(0, planets.Length);
        }
        picked.Add(newPlanet);
        // Sets the passenger on the new planet
        planets[newPlanet].gameObject.GetComponent<PassengerLifecycle>().updatePassengerStatusHelp();
    }

    public GameObject pickAndReturnNextPlanet() {
        int newPlanet = Random.Range(0, planets.Length);
        while(picked.Contains(newPlanet)) {
            newPlanet = Random.Range(0, planets.Length);
        }
        picked.Add(newPlanet);
        return planets[newPlanet];
    }
}
