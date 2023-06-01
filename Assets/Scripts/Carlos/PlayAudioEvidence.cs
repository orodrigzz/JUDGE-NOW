using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioEvidence : MonoBehaviour
{
    [SerializeField] AudioSource evidenceSound;
    [SerializeField] bool hasPlayed;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.isPicked && !hasPlayed && GAME_MANAGER._GAME_MANAGER.isPickingHammer == false && GAME_MANAGER._GAME_MANAGER.isPickingRules == false)
        {
            evidenceSound.Play();
            hasPlayed = true;
        }
        if(GAME_MANAGER._GAME_MANAGER.isPicked==false && hasPlayed)
        {
            evidenceSound.Stop();
            hasPlayed = false;
        }
    }
}
