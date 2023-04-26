using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_MANAGER : MonoBehaviour
{
    public static GAME_MANAGER _GAME_MANAGER;
    #region Reputation
    [Header ("Reputation")]
    [SerializeField] public float courtReputation;
    [SerializeField] public float townReputation;
    [SerializeField] public float noise;

    [SerializeField] public bool lightsOn;

    [SerializeField] private Image courtReputationImg;
    [SerializeField] private Image townReputationImg;
    [SerializeField] private Image defCourtReputation;
    [SerializeField] private Image defTownReputation;

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

    public float timeHolding;
    public float objectVel;
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
        currentScene = SceneManager.GetActiveScene();
        if (exclamationPoint != null)
        {
            exclamationPoint.SetActive(false);
        }

        if (currentScene.name != "Game" || currentScene.name == "Case2" || currentScene.name == "Case3" || currentScene.name == "Case4" || currentScene.name == "Case5" || currentScene.name == "Case6" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
        }
        
        //Reputation Bars
        noiseAudio.volume = 0;
        if (courtReputationImg != null && townReputationImg != null)
        {
            courtReputationImg.fillAmount = courtReputation;
            townReputationImg.fillAmount = townReputation;
        }

        if (noiseImg != null)
        {
            noiseImg.fillAmount = noise;
        }
        if(currentScene.name == "Tutorial")
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
        if (noise > 0.75f)
        {
            courtReputation = courtReputation + 0.000001f;
            townReputation = townReputation + 0.000001f;
        }

        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "CaseOver")
        {
            lastScene = currentScene.name;
            decisionMode = false;
        }
        if (endDialogue)
        {
            decisionMode = true;
        }
        if (currentScene.name != "Menu")
        {
            reputationCanvas.SetActive(true);
            //Reputation
            if (courtReputationImg != null && townReputationImg != null)
            {
                courtReputationImg.fillAmount = courtReputation;
                townReputationImg.fillAmount = townReputation;
            }

            if (noiseImg != null)
            {
                noiseImg.fillAmount = noise;
            }


            if (!isGamePaused)
            {
                if (townReputation < 0.15f || townReputation > 0.85f && currentScene.name != "Fired")
                {
                    SceneManager.LoadScene("Fired");
                    isGamePaused = true;
                }

                if (courtReputation < 0.15f || courtReputation > 0.85f && currentScene.name != "Fired")
                {
                    SceneManager.LoadScene("Fired");
                    isGamePaused = true;
                }
            }
            

            if (isGamePaused == false)
            {

                if(noise < 1)
                {
                    if(currentScene.name != "Tutorial")
                    {
                        noise = noise + 0.0001f;
                        if (noiseAudio != null)
                        {
                            noiseAudio.volume = noiseAudio.volume + 0.0001f;
                        }
                    }
                    
                    
                }
                else
                {
                    noiseAudio.volume = 1;
                    noise = 1;
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
           
        }
        if(currentScene.name == "Menu")
        {
            tutorialStarted = false;
        }
        if (currentScene.name == "Settings" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;

        }
        if (currentScene.name == "Credits" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;

        }
        if (currentScene.name == "CaseOver" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
        }
        if (currentScene.name == "Fired" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
        }
        if (currentScene.name == "Win" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = true;
        }
        if (currentScene.name == "Scenario2" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = false;
        }
        if (currentScene.name == "Scenario3" && reputationCanvas != null)
        {
            decisionMode = false;
            reputationCanvas.SetActive(false);
            noise = 0;
            noiseAudio.volume = 0;
            isGamePaused = false;
        }

        if (currentScene.name == "Game" || currentScene.name == "Tutorial" || currentScene.name == "Case2" || currentScene.name == "Case3" || currentScene.name == "Case4" || currentScene.name == "Case5" || currentScene.name == "Case6" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(true);
            if(isInspecting == false)
            {
                isGamePaused = false;
            }
            if (menuOpen)
            {
                isGamePaused = true;
            }
        }

        if (currentScene.name == "Menu")
        {
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
                courtReputation = courtReputation + 0.08f;
                townReputation = townReputation + 0.08f;
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
                courtReputation = courtReputation + 0.08f;
                townReputation = townReputation + 0.08f;
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
        courtReputation = courtReputation + 0.01f;
        townReputation = townReputation - 0.01f;
    }

    public void secondBribe()
    {
        courtReputation = courtReputation + 0.03f;
        townReputation = townReputation - 0.03f;
    }

    public void thirdBribe()
    {
        courtReputation = courtReputation + 0.1f;
        townReputation = townReputation - 0.1f;
        // Open Investigation 
        courtReputation = courtReputation - 0.05f;
        townReputation = townReputation - 0.05f;
    }

    public void fourthBribe()
    {
        courtReputation = courtReputation - 0.12f;
        townReputation = townReputation - 0.12f;
    }

    public void fiveBribe()
    {
        courtReputation = courtReputation - 0.15f;
        townReputation = townReputation - 0.15f;
        // Fired!
    }

    //Callar sala
    public void Order()
    {
        noise = noise - 0.03f;
        noiseAudio.volume = noiseAudio.volume - 0.03f;

        if (noise < 0 || noiseAudio.volume < 0)
        {
            noise = 0;
            noiseAudio.volume = 0;
        }
    }

    public void TurnUpLights()
    {
        noise = noise - 1f;
        noiseAudio.volume = noiseAudio.volume - 1f;

        if (noise < 0 || noiseAudio.volume < 0)
        {
            noise = 0;
            noiseAudio.volume = 0;
        }
    }
    
}
