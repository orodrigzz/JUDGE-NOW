using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDecision : MonoBehaviour
{
    [SerializeField] GameObject flechaDefendant;
    [SerializeField] GameObject flechaComplaint;

    private void Start()
    {
       
        if (flechaDefendant != null && flechaComplaint != null)
        {
            flechaComplaint.SetActive(false);
            flechaDefendant.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            if(GAME_MANAGER._GAME_MANAGER.decisionMode == false)
            {
                GAME_MANAGER._GAME_MANAGER.decisionMode = true;
                if(flechaDefendant != null && flechaComplaint != null)
                {
                    flechaComplaint.SetActive(true);
                    flechaDefendant.SetActive(true);
                }
                

            }
            else
            {
                GAME_MANAGER._GAME_MANAGER.decisionMode = false;
                
                if (flechaDefendant != null && flechaComplaint != null)
                {
                    flechaComplaint.SetActive(false);
                    flechaDefendant.SetActive(false);
                }
            }
        }
    }
}
