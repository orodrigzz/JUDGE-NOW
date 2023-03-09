using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_MANAGER : MonoBehaviour
{
    public static GAME_MANAGER _GAME_MANAGER;
    #region Reputation
    [SerializeField] private float courtReputation;
    [SerializeField] private float townReputation;
    [SerializeField] public float noise;

    [SerializeField] private Image courtReputationImg;
    [SerializeField] private Image townReputationImg;
    [SerializeField] private Image defCourtReputation;
    [SerializeField] private Image defTownReputation;

    [SerializeField] private Image defNoiseImg;
    [SerializeField] private Image noiseImg;

    [SerializeField] private AudioSource noiseAudio;
    #endregion

    #region GameBasics
    public bool isGamePaused;
    public bool isPicked;
    public bool initDialogue;
    public bool endDialogue = false;
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

        if ( townReputation < 0.20 || townReputation > 0.70)
        {
            SceneManager.LoadScene("Fired");
        }

        if (courtReputation < 0.20 || courtReputation > 0.70)
        {
            SceneManager.LoadScene("Fired");
        }

        noise = noise + 0.00002f;
        if(noiseAudio != null)
        {
            noiseAudio.volume = noiseAudio.volume + 0.00002f;
        }
    }

    //Reputation
    public void goodCase()
    {
        courtReputation = courtReputation + 0.1f;
        townReputation = townReputation + 0.1f;
    }

    public void badCase()
    {
        courtReputation = courtReputation - 0.1f;
        townReputation = townReputation - 0.1f;
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
        courtReputation = courtReputation + 0.02f;
        townReputation = townReputation - 0.02f;
        
        noise = noise - 0.05f;
        noiseAudio.volume = noiseAudio.volume - 0.05f;

        if (noise < 0 || noiseAudio.volume < 0)
        {
            noise = 0;
            noiseAudio.volume = 0;
        }
    }

}
