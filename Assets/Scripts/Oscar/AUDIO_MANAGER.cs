using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_MANAGER : MonoBehaviour
{
    public PickUpSystem pickUp;

    [SerializeField] AudioSource AudioMobil;

    private void Update()
    {
        if (pickUp.itemPicked != null && AudioMobil != null)
        {
            if (GAME_MANAGER._GAME_MANAGER.isInspecting && pickUp.itemPicked.tag == "Mobile")
            {
                  AudioMobil.Play();
                Debug.Log("Plalala");
            }
            else
            {
                AudioMobil.Stop();
            }
        }
    }    
}
