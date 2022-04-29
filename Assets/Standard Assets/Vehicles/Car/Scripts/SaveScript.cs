using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SaveScript : MonoBehaviour
{
    //Speed
    public static float Speed;
    public static float TopSpeed;
    public static string SpeedValue;
    //Gear
    public static int Gearbox;
    //Laps
    public static int LapsNumber;
    public static bool LapsChange;
    //Time
    public static float LapTimeMinutes;
    public static float LapTimeSeconds;
    //Race Time
    public static float RaceTimeMinutes;
    public static float RaceTimeSeconds;
    //Best Time
    public static float BestLapTimeM;
    public static float BestLapTimeS;
    //Last Lap
    public static float LastLapM;
    public static float LastLapS;
    //CheckPoint
    public static float GameTime;  // Check point time
    public static float LastCheckPoint1;
    public static float ThisCheckPoint1;
    public static float LastCheckPoint2;
    public static float ThisCheckPoint2;

    public static bool ChekPoinrPass1 = false;
    public static bool ChekPoinrPass2 = false;

    public static bool NewRecord = false;

    //on the road
    public static bool OnTheRoad = true;
    public static bool OnTheTerrain = false;
    // Rumblestrip
    public static bool Rumble1 = false;
    public static bool Rumble2 = false;


    public static bool WrongWay = false;


    void Start()
    {
        LapsChange = false;
    }

    void Update()
    {
        if(LapsChange == true)
        {
            LapsChange = false;
            LapTimeSeconds = 0f;
            LapTimeMinutes = 0f;
            GameTime = 0f;   

        }
        if(LapsNumber >= 1)
        {
            LapTimeSeconds = LapTimeSeconds + 1 * Time.deltaTime;
            RaceTimeSeconds = RaceTimeSeconds + 1 * Time.deltaTime;
            GameTime = GameTime + 1 * Time.deltaTime;
        }
        if(LapTimeSeconds > 59)
        {
            LapTimeSeconds = 0f;
            LapTimeMinutes++;
        }
        if (RaceTimeSeconds > 59)
        {
            RaceTimeSeconds = 0f;
            RaceTimeMinutes++;
        }
    }
}
