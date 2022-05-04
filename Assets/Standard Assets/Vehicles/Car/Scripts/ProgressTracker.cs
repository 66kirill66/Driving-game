using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private AudioSource Player;
    private bool isPlaying = false;
    public int CurrentWP = 0;
    public int ThisWPNumber;
    public int LastWPNumber;

    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Barrier"))
        {
            if(isPlaying == false)
            {
                isPlaying = true;
                Player.Play();               
            }
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (isPlaying == true)
            {
                isPlaying = false;
            }
        }
    }
    private void Update()
    {
        if(CurrentWP > LastWPNumber)
        {
            StartCoroutine(CheckDirection());
        }
        if(LastWPNumber > ThisWPNumber)
        {
            SaveScript.WrongWay = false;
        }
        if(LastWPNumber < ThisWPNumber)
        {
            SaveScript.WrongWay = true;
        }
    }
    IEnumerator CheckDirection()
    {
        yield return new WaitForSeconds(0.5f);
        ThisWPNumber = LastWPNumber;
    }
}
