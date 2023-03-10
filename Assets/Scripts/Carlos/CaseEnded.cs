using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseEnded : MonoBehaviour
{
    public Text complainerName;
    public Text complainerID;
    public Text accusedName;
    public Text accusedID;
    public Text complainResume;
    public Text decision;


   
    private void Awake()
    {
        complainerName.text = GAME_MANAGER._GAME_MANAGER.denunciantName;
        complainerID.text = GAME_MANAGER._GAME_MANAGER.denunciantID;
        accusedName.text = GAME_MANAGER._GAME_MANAGER.accusedName;
        accusedID.text = GAME_MANAGER._GAME_MANAGER.accusedID;
        complainResume.text = GAME_MANAGER._GAME_MANAGER.complaintResume;
        decision.text = GAME_MANAGER._GAME_MANAGER.decisionCase;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    void Update()
    {
        
    }
}
