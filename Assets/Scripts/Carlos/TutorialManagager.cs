using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManagager : MonoBehaviour
{
    [Header ("Cuadros de texto tutorial")]
    public GameObject inputTutorialText;
    public GameObject pickItemSysText;
    public GameObject trhowInputText;
    public GameObject lightText;
    public GameObject dodgeText;
    public GameObject noiseControlText;
    public GameObject inspectSysText;
    public GameObject decisionSystemText;
    

    [Header("Booleanos")]
    public bool startTutorial;
    public bool inputCompleted;
    public bool pickCompleted;
    public bool throwCompleted;
    public bool lightCompleted;
    public bool dodgeCompleted;
    public bool noiseCompleted;
    public bool inspectCompleted;
    public bool decisionCompleted;
    public bool tutorialCompleted;
    public bool barFilled;
    public bool startInspecting;
    public bool hasInspected;
    public bool hasSpawned;
    public bool lightOff;
    public bool hasShootedR;
    public bool hasShootedL;

    [Header("Inputs")]

    public bool wPressed;
    public bool aPressed;
    public bool sPressed;
    public bool dPressed;
    public bool leftClick;
    public bool rightClick;
   

    [Header("Objetivos")]
    public GameObject diana_1;
    public GameObject diana_2;
    public GameObject diana_3;
    public GameObject[] dianas;
    public GameObject evidence;
    public GameObject spawnPoint;
    public GameObject activateDecision;
    public Shoot shootL;
    public ShootR shootR;
    public float shootTimerR;
    public float shootTimeL;
    




    void Start()
    {
        diana_1.SetActive(false);
        diana_2.SetActive(false);
        diana_3.SetActive(false);
        inputTutorialText.SetActive(false);
        pickItemSysText.SetActive(false);
        trhowInputText.SetActive(false);
        lightText.SetActive(false);
        dodgeText.SetActive(false);
        noiseControlText.SetActive(false);
        inspectSysText.SetActive(false);
        decisionSystemText.SetActive(false);
        activateDecision.SetActive(false);
    }

    
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.tutorialStarted && !inputCompleted)
        {
            InputSystemTutorial();
        }
        if(inputCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            inputTutorialText.SetActive(false);
            PickUpSystemTutorial();
        }
        if(pickCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            pickItemSysText.SetActive(false);
            ThrowSystemTutorial();
        }
        if(pickCompleted && throwCompleted)
        {
            trhowInputText.SetActive(false);
            LightSystemTutorial();
        }
        if(lightCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            lightText.SetActive(false);
            ShootSystemTutorial();
        }
        if(dodgeCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            dodgeText.SetActive(false);
            NoiseSystemTutorial();
        }
        if(noiseCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            noiseControlText.SetActive(false);
            InspectSystemTutorial();
        }
        if(lightCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            lightText.SetActive(false);
        }
        if(inspectCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            inspectSysText.SetActive(false);
            DecisionSystemTutorial();
        }
        if(decisionCompleted && inputCompleted && pickCompleted && inputCompleted && throwCompleted && noiseCompleted && dodgeCompleted && lightCompleted && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
        {
            tutorialCompleted = true;
        }
        if (tutorialCompleted)
        {
            SceneManager.LoadScene("Game");
        }

    }

    public void InputSystemTutorial()
    {
        inputTutorialText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.W))
        {
            wPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dPressed = true;
        }
        if(wPressed && aPressed && sPressed && dPressed)
        {
            inputCompleted = true;

        }
    }
    public void PickUpSystemTutorial()
    {
        pickItemSysText.SetActive(true);
        if(Input.GetMouseButtonDown(0))
        {
            leftClick = true;
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            rightClick = true;
        }
        if(rightClick && leftClick)
        {
            pickCompleted = true;
        }
    }
    public void ThrowSystemTutorial()
    {
        trhowInputText.SetActive(true);
        if(diana_1 != null && diana_2 != null && diana_3 != null)
        {
            diana_1.SetActive(true);
            diana_2.SetActive(true);
            diana_3.SetActive(true);
        }
       
        dianas = GameObject.FindGameObjectsWithTag("Diana");
        if(dianas.Length <= 0)
        {
            throwCompleted = true;
        }

    }

    public void LightSystemTutorial()
    {
        lightText.SetActive(true);
        if(lightOff == false)
        {
            GAME_MANAGER._GAME_MANAGER.lightsOn = false;
            lightOff = true;
        }
       
        if (GAME_MANAGER._GAME_MANAGER.lightsOn == true)
        {
            lightCompleted = true;
        }
    }

    public void ShootSystemTutorial()
    {
        dodgeText.SetActive(true);
        if (!hasShootedL)
        {
            shootTimeL -= Time.deltaTime;
            if(shootTimeL <= 0)
            {
                shootL.ShootLeft();
                hasShootedL = true;
                shootTimeL = 0;
            } 
        }
        if(hasShootedL && !hasShootedR)
        {
            shootTimerR -= Time.deltaTime;
            if(shootTimerR <= 0)
            {
                shootR.ShootRight();
                hasShootedR = true;
                shootTimerR = 0;

            }
           
            
        }
        if(hasShootedR && hasShootedL)
        {
            dodgeCompleted = true;
        }
    }
    public void NoiseSystemTutorial()
    {
        noiseControlText.SetActive(true);
        if (!barFilled)
        {
            GAME_MANAGER._GAME_MANAGER.noise = 0.5f;
            GAME_MANAGER._GAME_MANAGER.noiseAudio.volume = 0.5f;
            barFilled = true;
        }      
        if(GAME_MANAGER._GAME_MANAGER.noiseAudio.volume <= 0f && GAME_MANAGER._GAME_MANAGER.noise <= 0)
        {
            noiseCompleted = true;
        }
    }
    
    public void InspectSystemTutorial()
    {
        inspectSysText.SetActive(true);
        if (!hasSpawned)
        {
            Instantiate(evidence, spawnPoint.transform.position, Quaternion.identity);
            hasSpawned = true;
        }

        if (GAME_MANAGER._GAME_MANAGER.isInspecting)
        {
            inspectCompleted = true;
        }
    }
    public void DecisionSystemTutorial()
    {
        decisionSystemText.SetActive(true);
        activateDecision.SetActive(true);
        if(GAME_MANAGER._GAME_MANAGER.caseEnded == true)
        {
            decisionCompleted = true;
        }
    }
}
