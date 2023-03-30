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
        if (!pickUp.isInspecting && pickUp.itemPicked != null && AudioMobil != null)
        {
            if (pickUp.itemPicked.tag == "Mobile")
            {
                AudioMobil.Play();
            }
        }
        else if (pickUp.itemPicked == null && AudioMobil != null)
        {
            AudioMobil.Stop();
        }
    }
}
