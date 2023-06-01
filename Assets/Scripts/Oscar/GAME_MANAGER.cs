using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_MANAGER : MonoBehaviour
{
    public static GAME_MANAGER _GAME_MANAGER;
    #region Reputation
    [Header ("Reputation")]
    [SerializeField] public float noise;

    [SerializeField] public bool lightsOn;

    [SerializeField] private Image defNoiseImg;
    [SerializeField] private Image noiseImg;

    [SerializeField] public AudioSource noiseAudio;
    #endregion

    #region GameBasics
    [Header("Game Basics")]
    public bool isGamePaused;
    public bool isPicked;
    public bool isInspecting;
    public bool initDialogue;
    public bool isDialoging;
    public bool endDialogue = false;
    public bool menuOpen;
    public bool stopArmMovement;
    public bool decisionMode = false;
    public bool caseEnded;
    public bool tutorialStarted;
    public bool hasShootedR;
    public bool hasShootedL;
    public bool isHoldingSpace;
    public bool isDoneInspecting;
    public bool isPickingHammer;
    public bool isPickingRules;
    public bool areOrder;
    public bool iscaseOver;
    public bool canDecision;
    public float timeHolding;
    public float objectVel;
    float fillBackUpNoiseTargetTime;
    public float fillBackUpTime;
    public bool noiseTuto;
    #endregion

    #region SaveInfo
    [Header("Save Info")]
    public string complaintResume;
    public string denunciantName;
    public string denunciantID;
    public string accusedName;
    public string accusedID;
    public string decisionCase;
    #endregion

    #region GetCurrentScene
    [Header("Get Scene")]
    public Scene currentScene;
    public GameObject reputationCanvas;
    public string lastScene;
    public bool isMenu;
    #endregion

    #region IndicacionesInput
    public GameObject exclamationPoint;
    #endregion

    private void Awake()
    {
        if (_GAME_MANAGER != null && _GAME_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _GAME_MANAGER = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        objectVel = 800;
        caseEnded = false;
        isGamePaused = false;
        decisionMode = false;
        areOrder = false;
        currentScene = SceneManager.GetActiveScene();
        if (exclamationPoint != null)
        {
            exclamationPoint.SetActive(false);
        }
        fillBackUpNoiseTargetTime = fillBackUpTime;
        if (currentScene.name != "Game" || currentScene.name == "Case2" || currentScene.name == "Case3" || currentScene.name == "Case4" || currentScene.name == "Case5" || currentScene.name == "Case6" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
        }
        
        //Reputation Bars
        noiseAudio.volume = 0;

        if (noiseImg != null)
        {
            noiseImg.fillAmount = noise;
        }
        if(currentScene.name == "Tutorial" && !noiseTuto )
        {
            if (noiseAudio != null)
            {
                noise = 0f;
                noiseAudio.volume = 0f;
            }
        }
    }

    void Update()
    {
        //if (noise > 0.75f)
        //{
        //    if (!areOrder)
        //    {
        //        noise = noise + 0.000001f;
        //    }
        //}

        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "CaseOver")
        {
            lastScene = currentScene.name;
        }
        if (currentScene.name != "Menu")
        {
            reputationCanvas.SetActive(true);

            if (noiseImg != null)
            {
                noiseImg.fillAmount = noise;
            }


            if (!isGamePaused)
            {
                if (noise > 0.90f && currentScene.name != "Fired")
                {
                    SceneManager.LoadScene("Fired");
                    isGamePaused = true;
                }
            }

            if (isGamePaused == false)
            {
                if (noise < 1)
                {
                    if(currentScene.name == "Tutorial" && noiseTuto)
                    {
                        if (areOrder == false)
                        {
                            noise = noise + 0.0001f;
                            if (noiseAudio != null)
                            {
                                noiseAudio.volume = noiseAudio.volume + 0.0001f;
                            }
                        }
                    } 
                    if(currentScene.name != "Tutorial")
                    {
                        if (areOrder == false)
                        {
                            noise = noise + 0.0001f;
                            if (noiseAudio != null)
                            {
                                noiseAudio.volume = noiseAudio.volume + 0.0001f;
                            }
                        }
                    }
                        

                    
                }
                else
                {
                    noiseAudio.volume = 1;
                    noise = 1;
                }
                if (areOrder)
                {
                    fillBackUpNoiseTargetTime -= Time.deltaTime;
                    if(fillBackUpNoiseTargetTime <= 0)
                    {
                        areOrder = false;
                        fillBackUpNoiseTargetTime = fillBackUpTime;
                    }
                }

            }
        }
        else
        {
            if (exclamationPoint != null)
            {
                exclamationPoint.SetActive(false);
            }
        }

        if (currentScene.name == "Menu"  && reputationCanvas != null )
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            areOrder = false;
            decisionMode = false;
            endDialogue = false;
        }

        if(currentScene.name == "Menu")
        {
            tutorialStarted = false;
        }
        if (currentScene.name == "Settings" && reputationCanvas != null)
        {
            
            reputationCanvas.SetActive(false);
            noise = 0;
            areOrder = false;

        }
        if (currentScene.name == "Credits" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            areOrder = false;

        }
        if (currentScene.name == "CaseOver" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
            areOrder = false;
        }
        if (currentScene.name == "Fired" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
            areOrder = false;
            endDialogue = false;
        }
        if (currentScene.name == "Win" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
            endDialogue = false;
            areOrder = false;
        }
        if (currentScene.name == "Scenario2" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = false;
            areOrder = false;
        }
        if (currentScene.name == "Scenario3" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = false;
            areOrder = false;
        }

        if (currentScene.name == "Game" || currentScene.name == "Tutorial" || currentScene.name == "Case2" || currentScene.name == "Case3" || currentScene.name == "Case4" || currentScene.name == "Case5" || currentScene.name == "Case6" && reputationCanvas != null)
        {
            Cursor.visible = false;
            reputationCanvas.SetActive(true);
            if(isInspecting == false)
            {
                isGamePaused = false;
            }
            if (menuOpen)
            {
                isGamePaused = true;
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }

        if (currentScene.name == "Menu")
        {
            Cursor.visible = true;
            isMenu = true;
        }
        else
        {
            isMenu = false;
        }
    }

    //Reputation
    public void goodCase()
    {
        if (currentScene.name == "Tutorial")
        {
            decisionCase = "SUSPENDED";
        }
        else
        {
            if (decisionMode)
            {
                noise = noise - 0.03f;
            }
            if (currentScene.name == "Game")
            {
                decisionCase = "ARNAO";
            }

            if (currentScene.name == "Case2")
            {
                decisionCase = "Jankduj";
            }

            if (currentScene.name == "Case3")
            {
                decisionCase = "Rikar Hegber";
            }

            if (currentScene.name == "Case4")
            {
                decisionCase = "Humberto Triste";
            }

            if (currentScene.name == "Case5")
            {
                decisionCase = "Pisabel Payuso";
            }

            if (currentScene.name == "Case6")
            {
                decisionCase = "Maria Cardaxian";
            }
        }
    }
    public void badCase()
    {
        if (currentScene.name == "Tutorial")
        {
            decisionCase = "SUSPENDED";
        }
        else
        {
            if (decisionMode)
            {
                noise = noise + 0.04f;
            }

            if (currentScene.name == "Game")
            {
                decisionCase = "ROGIRA";
            }

            if (currentScene.name == "Case2")
            {
                decisionCase = "Alexa Pegej";
            }

            if (currentScene.name == "Case3")
            {
                decisionCase = "Marka Volteikg";
            }

            if (currentScene.name == "Case4")
            {
                decisionCase = "Abrahim Pezlo";
            }

            if (currentScene.name == "Case5")
            {
                decisionCase = "Samid Concejal";
            }

            if (currentScene.name == "Case6")
            {
                decisionCase = "Cada Culiao";
            }
        }
    }

    //Sobornos
    public void firstBribe()
    {
        noise = noise + 0.01f;
    }

    public void secondBribe()
    {
        noise = noise + 0.03f;
    }

    public void thirdBribe()
    {
        noise = noise + 0.07f;
    }

    //Callar sala
    public void Order()
    {
        areOrder = true;
        noiseAudio.volume = noiseAudio.volume - 0.03f;

        if (noise < 0 || noiseAudio.volume < 0)
        {
            noise = 0;
            noiseAudio.volume = 0;
        }
    }
    
    public void TurnUpLights()
    {
        noiseAudio.volume = noiseAudio.volume - 0.06f;

        if (noise < 0 || noiseAudio.volume < 0)
        {
            noise = 0;
            noiseAudio.volume = 0;
        }
    }
    
    public bool SetCaseStatus(bool isCaseOver)
    {
        iscaseOver=isCaseOver;
        return isCaseOver;
    }

    public bool ResetCaseStatus(bool isCaseOver)
    {
        iscaseOver = isCaseOver;
        return isCaseOver;
    }

    public void NextLevel()
    {
        if(lastScene == "Day1")
        {
            SceneManager.LoadScene("Scenario2");
        }
        if (lastScene == "Scenario2")
        {
            SceneManager.LoadScene("Day2");
        }
        if (lastScene == "Day2")
        {
            SceneManager.LoadScene("Scenario3");
        }
        if (lastScene == "Scenario3")
        {
            SceneManager.LoadScene("Day3");
        }
        if (lastScene == "Day3")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
