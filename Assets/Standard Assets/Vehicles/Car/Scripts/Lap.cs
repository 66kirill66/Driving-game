using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SaveScript.LastLapS = SaveScript.LapTimeSeconds;
            SaveScript.LastLapM = SaveScript.LapTimeMinutes;                    
            SaveScript.LapsNumber++;
            SaveScript.LapsChange = true;

            if (SaveScript.LapsNumber == 2)
            {
                SaveScript.BestLapTimeM = SaveScript.LastLapM;
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
                SaveScript.NewRecord = true;
            }
            SaveScript.ChekPoinrPass1 = false;
            SaveScript.ChekPoinrPass2 = false;
            SaveScript.LastCheckPoint1 = SaveScript.ThisCheckPoint1;
            SaveScript.LastCheckPoint2 = SaveScript.ThisCheckPoint2;
        }
    }
}
