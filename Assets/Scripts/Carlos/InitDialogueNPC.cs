using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDialogueNPC : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            Debug.Log("Pum");
            GAME_MANAGER._GAME_MANAGER.initDialogue = true;
            
        }
    }
}
