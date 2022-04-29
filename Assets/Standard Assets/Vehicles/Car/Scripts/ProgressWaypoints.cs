using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WPNumber;   //  WPNumber Check
    public int CarTracking = 0;   // == CurrentWP


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Progress"))
        {
            CarTracking = other.GetComponent<ProgressTracker>().CurrentWP;
            if (CarTracking < WPNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWP = WPNumber;
                Debug.Log("CurrentWP = " + other.GetComponent<ProgressTracker>().CurrentWP);
            }
            if (CarTracking > WPNumber)
            {
                SaveScript.WrongWay = true;
            }
        }
    }
}
