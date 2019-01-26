using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConvoTester : MonoBehaviour
{
    public TextMeshProUGUI questionText;

    public void SayYes() {
        questionText.text = "This is your new home planet!";
    }

    public void SayNo() {
        questionText.text = "Get out of here!";
    }
}
