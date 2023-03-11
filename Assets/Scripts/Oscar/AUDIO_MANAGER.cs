using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO_MANAGER : MonoBehaviour
{
    public PickUpSystem pickUp;
    public HammerBehaviour hammerBehaviour;

    [SerializeField] private AudioSource AudioMobil;
    [SerializeField] private AudioSource AudioMazo;

    private void Update()
    {
        if (pickUp.itemPicked != null && AudioMobil != null)
        {
            if (pickUp.itemPicked.tag == "Mobile")
            {
                AudioMobil.Play();
            }
            else
            {
                AudioMobil.Stop();
            }
        }

        if (hammerBehaviour != null && AudioMazo != null)
        {
            if (hammerBehaviour.mazazo == true)
            {
                AudioMazo.Play();
            }
            else
            {
                AudioMazo.Stop();
            }
        }

    }    
}
