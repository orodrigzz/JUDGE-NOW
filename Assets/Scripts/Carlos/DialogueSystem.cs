using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour
{

    public Text[] sentences;
    public Text nameText;
    public GameObject dialogueBox;

    public string[] dialogueLines;
    public string characterName;

    public int count = -1;
    public int deactivateCount;

    public bool dialogueOn;

    private void Awake()
    {
        dialogueBox.SetActive(false);
        dialogueOn = false;
        foreach (var sentence in sentences)
        {
            sentence.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextSentences();
        }
        if (dialogueOn)
        {
            nameText.text = null;
            nameText.text += characterName;
        }
        if (!dialogueOn)
        {
            nameText.text = null;
        }
    }


    public void NextSentences()
    {
        
        if (count == sentences.Length - 1)
        {
            dialogueOn = false;
            dialogueBox.SetActive(false);
            count = -1;
            deactivateCount = 0;
            
            foreach (var sentence in sentences)
            {
                sentence.enabled = false;
            }
            
            return;
        }

        if (count < sentences.Length)
        {
            dialogueBox.SetActive(true);
            dialogueOn = true;
            count++;
            sentences[count].enabled = true;
            sentences[count].text += dialogueLines[count];
        }
        if (count > 0)
        {
            deactivateCount = count - 1;
            sentences[deactivateCount].enabled = false;
            dialogueLines[0] = null;
            dialogueLines[deactivateCount+1] = null;
            
        }





    }
}
