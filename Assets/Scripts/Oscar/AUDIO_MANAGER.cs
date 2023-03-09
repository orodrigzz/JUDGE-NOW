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
        if (pickUp.itemPicked != null)
        {
            if (pickUp.itemPicked.name == "Movil(Clone)" && pickUp.isInspecting)
            {
                AudioMobil.Play();
            }
            else
            {
                AudioMobil.Stop();
            }
        }

        if (hammerBehaviour != null)
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
