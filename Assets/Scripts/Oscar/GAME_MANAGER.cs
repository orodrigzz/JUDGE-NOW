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
    public bool endDialogue = false;
    public bool menuOpen;
    public bool stopArmMovement;
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
    #endregion

    #region IndicacionesInput
    public GameObject eForInspect;
    public GameObject qForExitInspect;
    public GameObject mForDecisionMode;
    public GameObject mForExitDecisionMode;
    public GameObject lClickForPickItUp;
    public GameObject rClickForLetItGo;
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
        isGamePaused = false;
        currentScene = SceneManager.GetActiveScene();
       
        if (currentScene.name != "Game" || currentScene.name == "Case2" || currentScene.name == "Case3" && reputationCanvas != null)
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
    }

    void Update()
    {
        //if (noise > 0.75f)
        //{
        //    courtReputation = courtReputation + 0.000001f;
        //    townReputation = townReputation + 0.000001f;
        //}

        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "CaseOver")
        {
            lastScene = currentScene.name;
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
                if (townReputation < 0.20f || townReputation > 0.80f && currentScene.name != "Fired")
                {
                    SceneManager.LoadScene("Fired");
                    isGamePaused = true;
                }

                if (courtReputation < 0.20f || courtReputation > 0.80f && currentScene.name != "Fired")
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
                    else
                    {
                        noise = noise + 0.00025f;
                        if (noiseAudio != null)
                        {
                            noiseAudio.volume = noiseAudio.volume + 0.0025f;
                        }
                    }
                    
                }
                else
                {
                    noiseAudio.volume = 1;
                    noise = 1;
                }
               
            }
            if(qForExitInspect != null && eForInspect != null)
            {
                if (isInspecting && isPicked)
                {
                    qForExitInspect.SetActive(true);
                    eForInspect.SetActive(false);
                    rClickForLetItGo.SetActive(false);
                    lClickForPickItUp.SetActive(false);
                }
                if (!isInspecting && isPicked)
                {
                    qForExitInspect.SetActive(false);
                    eForInspect.SetActive(true);
                    rClickForLetItGo.SetActive(true);
                    lClickForPickItUp.SetActive(false);
                }
                if (!isInspecting && !isPicked)
                {
                    rClickForLetItGo.SetActive(false);
                    qForExitInspect.SetActive(false);
                    eForInspect.SetActive(false);
                }
            }
            
        }

        if (currentScene.name == "Menu"  && reputationCanvas != null )
        {
            reputationCanvas.SetActive(false);
            noise = 0;
           
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
            reputationCanvas.SetActive(false);
            noise = 0;
            isGamePaused = true;
        }
        if (currentScene.name == "Fired" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            isGamePaused = true;
        }
        if (currentScene.name == "Win" && reputationCanvas != null)
        {
            reputationCanvas.SetActive(false);
            noise = 0;
            isGamePaused = true;
        }

        if (currentScene.name == "Game" || currentScene.name == "Tutorial" || currentScene.name == "Case2" || currentScene.name == "Case3" && reputationCanvas != null)
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
    }

    //Reputation
    public void goodCase()
    {
        courtReputation = courtReputation + 0.1f;
        townReputation = townReputation + 0.1f;

        if (currentScene.name == "Game")
        {
            decisionCase = "INNOCENT";
        }
        else
        {
            decisionCase = "GUILTY";
        }
    }

    public void badCase()
    {
        courtReputation = courtReputation - 0.1f;
        townReputation = townReputation - 0.1f;

        if (currentScene.name == "Game")
        {
            decisionCase = "GUILTY";
        }
        else
        {
            decisionCase = "INNOCENT";
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
        noise = noise - 0.05f;
        noiseAudio.volume = noiseAudio.volume - 0.05f;

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
