using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private AudioSource Player;
    private bool isPlaying = false;

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
                Debug.Log("Play");
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
}
