using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Planet";
    }

    private string DescribePeople() {
        return "cat-like creatures";
    }

    private string DescribeColor () {
        return "blue";        
    }

    private string DescribeSize() {
        return "very big";
    }

    private string Intro() {
        string[] possibleIntros = { 
            "I'm from a planet that ",
            "My planet ",
            "Please take me to a planet that ",
            "I would like to go to a planet that ",
            "My home is a planet that ",
            "My home planet ",
            "The planet that I'm from "
        };
        int i = Random.Range(0, possibleIntros.Length);
        return possibleIntros[i];
    }

    public string GetClue() {
        string[] possibleClues = {
            "has a " + DescribeColor() + " color!",
            "is very " + DescribeColor() + ".",
            "is a " + DescribeSize() + " planet.",
            "is full of " + DescribePeople() + "."            
        };
        int i = Random.Range(0, possibleClues.Length);

        return "" + Intro() + possibleClues[i];
    }
}
