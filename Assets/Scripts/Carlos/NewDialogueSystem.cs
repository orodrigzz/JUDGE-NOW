using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueSystem : MonoBehaviour
{
    [System.Serializable]
   public struct Dialogues
   {
        public Text[] sentences;
        public Text nameText;
        public Text idText;
        
        public GameObject textBox;
        public GameObject evidence;
        public GameObject spawnPoint;

        public string[] dialogueLines;
        public string characterName;
        public string characterID;

        public int sentenceIndex;
        public int diactivateCount;

        public bool currentDialogueEnded;
   }
    [NonReorderable]

    public Dialogues[] dialogues;
    public string caseResume;
    public bool dialogueOn;
    public int dialoguesIndex = -1;

    public GameObject guiltyBut;
    public GameObject innocentBut;
    public bool isRevealed;
    private void Awake()
    {
        for(int i = 0; i < dialogues.Length; i++)
        {
            dialogues[i].textBox.SetActive(false);
            dialogues[i].currentDialogueEnded = false;
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
        innocentBut.SetActive(false);
        guiltyBut.SetActive(false);
    }

 
    void Update()
    {

        if (GAME_MANAGER._GAME_MANAGER.initDialogue && !dialogueOn)
        {
            //Funcion que da inicio al primer dialogo
            //Ira vinculada al collaider
            CurrentDialogue();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Funcion que ira vinculada al input una vez iniciado el dialogo
            if (dialogueOn)
            {
                OnDialogue();
            }

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isRevealed)
            {

                innocentBut.SetActive(true);
                guiltyBut.SetActive(true);
                isRevealed = true;
            }
            else
            {

                innocentBut.SetActive(false);
                guiltyBut.SetActive(false);
                isRevealed = false;
            }
        }
        if (dialoguesIndex >= 0)
        {
            if (dialogueOn)
            {
               
                //Comprobamos si ha acabado el dialogo actual y si es asi pasamos al siguiente
                if (dialogues[dialoguesIndex].sentenceIndex >= dialogues[dialoguesIndex].sentences.Length-1)
                {
                    if (dialogues[dialoguesIndex].spawnPoint != null && dialogues[dialoguesIndex].evidence != null)
                    {
                        Instantiate(dialogues[dialoguesIndex].evidence, dialogues[dialoguesIndex].spawnPoint.transform, false);
                    }
                    dialogues[dialoguesIndex].currentDialogueEnded = true;                   
                    dialoguesIndex++;
                    dialogues[dialoguesIndex-1].textBox.SetActive(false);
                }

            }


            //comprobamos si quedan mas dialogos 
            if (dialoguesIndex > dialogues.Length-1)
            {
                GAME_MANAGER._GAME_MANAGER.endDialogue = true;
                GAME_MANAGER._GAME_MANAGER.initDialogue = false;
                for (int i = 0; i < dialogues.Length; i++)
                {
                    dialogues[i].textBox.SetActive(false);
                    dialogues[i].currentDialogueEnded = false;
                }
                dialogueOn = false;
            }

        }
        
        
    }
    public void CurrentDialogue()
    {
        if(dialoguesIndex <= 0)
        {
            dialoguesIndex++;
        }
        dialogueOn = true;
        OnDialogue();   
    }
    public void OnDialogue()
    {
            dialogues[dialoguesIndex].nameText.text = null;
            dialogues[dialoguesIndex].idText.text = null;
            dialogues[dialoguesIndex].nameText.text += dialogues[dialoguesIndex].characterName;
            dialogues[dialoguesIndex].idText.text += dialogues[dialoguesIndex].characterID;
            
            if (dialogues[dialoguesIndex].sentenceIndex < dialogues[dialoguesIndex].sentences.Length)
            {
                dialogues[dialoguesIndex].textBox.SetActive(true);
                dialogues[dialoguesIndex].currentDialogueEnded = false;
                dialogues[dialoguesIndex].sentenceIndex++;
                dialogues[dialoguesIndex].sentences[dialogues[dialoguesIndex].sentenceIndex].enabled = true;
                dialogues[dialoguesIndex].sentences[dialogues[dialoguesIndex].sentenceIndex].text += dialogues[dialoguesIndex].dialogueLines[dialogues[dialoguesIndex].sentenceIndex];
            }
            if (dialogues[dialoguesIndex].sentenceIndex > 0)
            {
                dialogues[dialoguesIndex].diactivateCount = dialogues[dialoguesIndex].sentenceIndex - 1;
                dialogues[dialoguesIndex].sentences[dialogues[dialoguesIndex].diactivateCount].enabled = false;
            }
        
            
               
    }

 
}
