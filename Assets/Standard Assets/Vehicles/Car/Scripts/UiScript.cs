using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] Image SpeedRing;
    public Text SpeedText;
    public Text KilometerMiles;
    public Text GearNum;
    //Laps
    public Text LapNumberText;
    public Text totalLapsText;
    public int totalLaps = 3;
    //Time
    public Text LapTimeMinutesText;
    public Text LapTimeSecondsText;
    //Race Time
    public Text RaceTimeMinutesText;
    public Text RaceTimeSecondsText;
    // Best Lap Time
    public Text BestLapTimeMinutes;
    public Text BestLapTimeSeconds;
    //Check Point Time
    public Text CheckPointTime;
    public GameObject CheckPointDisplay;
    //Record Lap
    public GameObject NewLapRecord;

    


    private float DisplaySpeed;
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        LapNumberText.text = "0";
        totalLapsText.text = "/" + totalLaps.ToString();
        CheckPointDisplay.SetActive(false);
        NewLapRecord.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SpeedDisplay();
        LapTime();
        RaceTime();
        BestLap();
        CheckPoints();
    }

    private void SpeedDisplay()   //speedometer
    {        
        DisplaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveScript.Speed).ToString());
        KilometerMiles.text = SaveScript.SpeedValue;
        GearNum.text = (SaveScript.Gearbox + 1).ToString();
    }

    private void LapTime()
    {
        LapNumberText.text = SaveScript.LapsNumber.ToString();

        if (SaveScript.LapTimeMinutes <= 9)
        {
            LapTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
        }
        else if (SaveScript.LapTimeMinutes >= 10)
        {
            LapTimeMinutesText.text = (Mathf.Round(SaveScript.LapTimeMinutes).ToString()) + ":";
        }
        if (SaveScript.LapTimeSeconds <= 9)
        {
            LapTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }
        else if (SaveScript.LapTimeSeconds >= 10)
        {
            LapTimeSecondsText.text = (Mathf.Round(SaveScript.LapTimeSeconds).ToString());
        }
    }

    private void RaceTime()
    {
        if (SaveScript.RaceTimeMinutes <= 9)
        {
            RaceTimeMinutesText.text = "0" + (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
        }
        else if (SaveScript.RaceTimeMinutes >= 10)
        {
            RaceTimeMinutesText.text = (Mathf.Round(SaveScript.RaceTimeMinutes).ToString()) + ":";
        }
        if (SaveScript.RaceTimeSeconds <= 9)
        {
            RaceTimeSecondsText.text = "0" + (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }
        else if (SaveScript.RaceTimeSeconds >= 10)
        {
            RaceTimeSecondsText.text = (Mathf.Round(SaveScript.RaceTimeSeconds).ToString());
        }

    }

    private void BestLap()  // fix best lap changes
    {
        // if (SaveScript.LapsChange == true)  //blink NewRekord GameObject Fix

        if (SaveScript.LastLapM == SaveScript.BestLapTimeM )
        {
            if (SaveScript.LastLapS < SaveScript.BestLapTimeS)
            {
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
                SaveScript.NewRecord = true;
            }
        }
        else if (SaveScript.LastLapM < SaveScript.BestLapTimeM)
        {
            SaveScript.BestLapTimeM = SaveScript.LastLapM;
            SaveScript.BestLapTimeS = SaveScript.LastLapS;
            SaveScript.NewRecord = true;
        }
        

        // Display Best Lap Time
        if (SaveScript.BestLapTimeM <= 9)
        {
            BestLapTimeMinutes.text = "0" + (Mathf.Round(SaveScript.BestLapTimeM).ToString()) + ":";
        }
        else if (SaveScript.BestLapTimeM >= 10)
        {
            BestLapTimeMinutes.text = (Mathf.Round(SaveScript.BestLapTimeM).ToString()) + ":";
        }
        if (SaveScript.BestLapTimeS <= 9)
        {
            BestLapTimeSeconds.text = "0" + (Mathf.Round(SaveScript.BestLapTimeS).ToString());
        }
        else if (SaveScript.BestLapTimeS >= 10)
        {
            BestLapTimeSeconds.text = (Mathf.Round(SaveScript.BestLapTimeS).ToString());
        }

        if(SaveScript.NewRecord == true)
        {
            NewLapRecord.SetActive(true);
            StartCoroutine(LapRecordOff());
        }

    }

    private void CheckPoints()
    {
        // Check Point Working 1
        if(SaveScript.ChekPoinrPass1 == true)
        {
            SaveScript.ChekPoinrPass1 = false;
            CheckPointDisplay.SetActive(true);

            if(SaveScript.ThisCheckPoint1 > SaveScript.LastCheckPoint1)
            {
                CheckPointTime.color = Color.red;
                CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1).ToString();
                StartCoroutine(CheckPointOff());
            }
            if (SaveScript.ThisCheckPoint1 < SaveScript.LastCheckPoint1)
            {
                CheckPointTime.color = Color.blue;
                CheckPointTime.text = "+" + (SaveScript.LastCheckPoint1 - SaveScript.ThisCheckPoint1).ToString();
                StartCoroutine(CheckPointOff());
            }
        }
        // Check Point Working 2
        if (SaveScript.ChekPoinrPass2 == true)
        {
            SaveScript.ChekPoinrPass2 = false;
            CheckPointDisplay.SetActive(true);

            if (SaveScript.ThisCheckPoint2 > SaveScript.LastCheckPoint2)
            {
                CheckPointTime.color = Color.red;
                CheckPointTime.text = "-" + (SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2).ToString();
                StartCoroutine(CheckPointOff());
            }
            if (SaveScript.ThisCheckPoint2 < SaveScript.LastCheckPoint2)
            {
                CheckPointTime.color = Color.blue;
                CheckPointTime.text = "+" + (SaveScript.LastCheckPoint2 - SaveScript.ThisCheckPoint2).ToString();
                StartCoroutine(CheckPointOff());
            }
        }

    }
    IEnumerator CheckPointOff()
    {
        yield return new WaitForSeconds(2);
        CheckPointDisplay.SetActive(false);
    }

    IEnumerator LapRecordOff()
    {
        yield return new WaitForSeconds(2);
        SaveScript.NewRecord = false;
        NewLapRecord.SetActive(false);
    }

}
