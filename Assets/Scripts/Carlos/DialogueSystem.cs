using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;
    [SerializeField] Text nameBox;
    [SerializeField] Text textBox;
    [SerializeField] string name;
    [SerializeField] string[] dialogueLines;
    [SerializeField] int countLines;
    [SerializeField] bool isDialogueActivated;
    void Start()
    {
        Dialogue.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            DialogueOn();
            countLines++;
            if (countLines <= dialogueLines.Length - 1)
            {
                Dialogue.SetActive(false);
                countLines = 0;
                isDialogueActivated = false;

            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
           
        }
    }

    public void DialogueOn()
    {
        Dialogue.SetActive(true);
        nameBox.text += name;
        isDialogueActivated = true;
        if(countLines == 0)
        {
            textBox.text += dialogueLines[0];
        }
        else
        {
            textBox.text += dialogueLines[countLines];
        }
    }

    public void ActivateDialogue()
    {
        if(countLines == 0)
        {
            DialogueOn();
        }
        else if(countLines == 0 && isDialogueActivated)
        {
            countLines++;
        }
        
    }
}
