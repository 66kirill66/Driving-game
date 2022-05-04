using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WPNumber;   //  WPNumber Check
    public int CarTracking = 0;   // == CurrentWP
    public bool PenaltyOption = false;
    public int PenaltyWayPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Progress"))
        {
            CarTracking = other.GetComponent<ProgressTracker>().CurrentWP;
            if (CarTracking < WPNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWP = WPNumber;
                //Debug.Log("CurrentWP = " + other.GetComponent<ProgressTracker>().CurrentWP);
            }
            if (CarTracking > WPNumber)
            {
                other.GetComponent<ProgressTracker>().LastWPNumber = WPNumber;
            }
            if(PenaltyOption == true)
            {
                if(CarTracking < PenaltyWayPoint)
                {
                    Debug.Log("Penalty");
                }
            }
        }
    }
}
