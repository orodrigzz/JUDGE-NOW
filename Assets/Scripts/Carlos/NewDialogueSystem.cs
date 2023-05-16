using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueSystem : MonoBehaviour
{
    [System.Serializable]
   public struct Dialogues
   {
        public Text sentence_1;
        public Text sentence_2;
        public Text nameText;
        public Text idText;
        
        public GameObject textBox_1;
        public GameObject textBox_2;
        public GameObject evidence;
        public GameObject spawnPoint;
        public GameObject NPC_1;
        public GameObject NPC_2;

        public GameObject evidence2;
        public GameObject spawnPoint2;
        

        public string dialogueLines_1;
        public string dialogueLines_2;
        public string characterName;
        public string characterID;

        public int sentenceIndex;
        public int diactivateCount;

        public bool currentDialogueEnded;
        public bool evidence1HasSpawned;
        public bool evidence2HasSpawned;
        public bool npc1IsActive;
        public bool npc2IsActive;

        public bool caseStarted;
        public bool caseOver;


    }
    [NonReorderable]

    public Dialogues[] dialogues;
    public string caseResume;
    public bool dialogueOn;
    public int caseIndex = -1;

    public GameObject evidence_1;
    public GameObject evidence_2;


   private GameObject decisionMode;


    public bool isRevealed;
    public bool evidenceInstantiated;

    public bool spawnNow = false;

    

    private void Awake()
    {
        for(int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i].textBox_1 != null || dialogues[i].textBox_1 != null)
            {
                dialogues[i].textBox_1.SetActive(false);
                dialogues[i].textBox_2.SetActive(false);
               
            }
            
            dialogues[i].currentDialogueEnded = false;
            if(dialogues[i].NPC_1 != null && dialogues[i].NPC_2 != null)
            {
                dialogues[i].NPC_1.SetActive(false);
                dialogues[i].NPC_2.SetActive(false);
            }
            

        }
        dialogueOn = false;
        
        GAME_MANAGER._GAME_MANAGER.denunciantName = dialogues[0].characterName;
        GAME_MANAGER._GAME_MANAGER.denunciantID = dialogues[0].characterID;
        GAME_MANAGER._GAME_MANAGER.accusedID = dialogues[1].characterID;
        GAME_MANAGER._GAME_MANAGER.accusedName = dialogues[1].characterName;
        GAME_MANAGER._GAME_MANAGER.complaintResume = caseResume;
        
    }
    void Start()
    {
        if( decisionMode != null){
            
            decisionMode.SetActive(false);
        }
       
       
        
    }

 
    void Update()
    {
        if(caseIndex >= 0 && dialogues[dialogues.Length - 1].caseOver != true)
        {
            dialogues[caseIndex].caseOver = GAME_MANAGER._GAME_MANAGER.iscaseOver;

        }
        else if(caseIndex >= 0 && dialogues[dialogues.Length - 1].caseOver == true)
        {
            GAME_MANAGER._GAME_MANAGER.NextLevel();
        }
       
        if (GAME_MANAGER._GAME_MANAGER.initDialogue && !dialogueOn && dialogues[0].caseStarted == false)
        {
            //Funcion que da inicio al primer dialogo
            //Ira vinculada al collaider
            GAME_MANAGER._GAME_MANAGER.isDialoging = true;
            dialogues[0].caseStarted = true;
            dialogues[0].textBox_1.SetActive(true);
            dialogues[0].textBox_2.SetActive(true);
            dialogues[0].sentence_1.text = dialogues[0].dialogueLines_1;
            dialogues[0].sentence_2.text = dialogues[0].dialogueLines_1;

        }
        
        if (caseIndex >= 0 && dialogues[dialogues.Length - 1].caseOver != true)
        {
            if (GAME_MANAGER._GAME_MANAGER.initDialogue == true)
            {

                dialogues[caseIndex].textBox_1.SetActive(true);
                dialogues[caseIndex].textBox_2.SetActive(true);
                if(dialogues[caseIndex].evidence != null && dialogues[caseIndex].evidence1HasSpawned == false)
                {
                    Instantiate(dialogues[caseIndex].evidence, dialogues[caseIndex].spawnPoint.transform, false);
                    evidence_1 = dialogues[caseIndex].evidence;
                    dialogues[caseIndex].evidence1HasSpawned = true;

                }
                if (dialogues[caseIndex].evidence2 != null && dialogues[caseIndex].evidence2HasSpawned == false)
                {
                    Instantiate(dialogues[caseIndex].evidence2, dialogues[caseIndex].spawnPoint2.transform, false);
                    evidence_1 = dialogues[caseIndex].evidence2;
                    dialogues[caseIndex].evidence1HasSpawned = true;

                }

            }

           


        }
        if (caseIndex <= 0  )
        {
            caseIndex = 0;
            


        }if(caseIndex == 0 && dialogues[0].npc1IsActive == false)
        {
            dialogues[0].NPC_1.SetActive(true);
            dialogues[0].npc1IsActive = true;
        }
        if (caseIndex == 0 && dialogues[0].npc2IsActive == false)
        {
            dialogues[0].NPC_2.SetActive(true);
            dialogues[0].npc2IsActive = true;
        }
        if (dialogues[caseIndex].caseOver == true && caseIndex >=0 && dialogues[dialogues.Length - 1].caseOver != true)
        {
            dialogues[caseIndex].NPC_1.SetActive(false);
            dialogues[caseIndex].NPC_2.SetActive(false);
            if (dialogues[caseIndex].evidence != null)
            {
                evidence_1.SetActive(false);
                evidence_1 = null;
               
            }
            if (dialogues[caseIndex].evidence2 != null)
            {
                evidence_2.SetActive(false);
                evidence_2 = null;
               
            }

            if (GAME_MANAGER._GAME_MANAGER.exclamationPoint != null)
            {
                GAME_MANAGER._GAME_MANAGER.exclamationPoint.SetActive(false);
            }
            
            if (dialogues[caseIndex].textBox_1 != null && dialogues[caseIndex].textBox_2 != null)
            {
                dialogues[caseIndex].textBox_1.SetActive(false);
                dialogues[caseIndex].textBox_2.SetActive(false);
            }
           
            caseIndex++;
            dialogues[caseIndex].NPC_1.SetActive(true);
            dialogues[caseIndex].NPC_2.SetActive(true);
            dialogues[caseIndex].sentence_1.text = dialogues[caseIndex].dialogueLines_1;
            dialogues[caseIndex].sentence_2.text = dialogues[caseIndex].dialogueLines_1;
            GAME_MANAGER._GAME_MANAGER.ResetCaseStatus(false);
            GAME_MANAGER._GAME_MANAGER.isDialoging = false;
            GAME_MANAGER._GAME_MANAGER.initDialogue = false;
            

        }

        
           

    }

    

}
