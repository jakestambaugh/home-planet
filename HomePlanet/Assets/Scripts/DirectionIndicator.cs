using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    private GameObject currentDestination;
    public GameObject player;
    private Image indicator;

    private int indicatorAlpha = 255;
    public float distanceToFadeBegin = 7.0f;
    public float fadeRate = 36.0f;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the direction of the indicator to point to the destination
        Vector3 vecToDest = currentDestination.transform.position - player.transform.position;
        float distToDest = Vector3.Distance(player.transform.position, currentDestination.transform.position);

        transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(vecToDest.x*-1.0f, vecToDest.y)*Mathf.Rad2Deg);

        // Fade the indicator image when close to the destination
        float planetRadius = currentDestination.GetComponent<CircleCollider2D>().bounds.size.x/2;
        float distToPlanetSurface = distToDest-planetRadius;

        indicatorAlpha = (int)Mathf.Clamp((((distToPlanetSurface*2.0f)-distanceToFadeBegin)*fadeRate), 0.0f, 255.0f);

        // Hide the indicator if we have a passenger
        PassengerPickupPoint ppp = currentDestination.GetComponent<PassengerPickupPoint>();
        if(!ppp.HasPassenger()){
            indicatorAlpha = 0;
        }

        indicator.color = new Color32(0,255,225, (byte)indicatorAlpha);
    }

    public void SetCurrentDestination(GameObject dest)
    {
        currentDestination = dest;
    }
}
