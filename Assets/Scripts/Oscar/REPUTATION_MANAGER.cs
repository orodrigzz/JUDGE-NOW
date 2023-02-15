using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class REPUTATION_MANAGER : MonoBehaviour
{
    public static REPUTATION_MANAGER _REPUTATION_MANAGER;

    [SerializeField] private float courtReputation;
    [SerializeField] private float townReputation;
    [SerializeField] private Image courtReputationImg;
    [SerializeField] private Image townReputationImg;
    [SerializeField] private Image defCourtReputation;
    [SerializeField] private Image defTownReputation;

    private void Awake()
    {
        if (_REPUTATION_MANAGER != null && _REPUTATION_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _REPUTATION_MANAGER = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        courtReputationImg.fillAmount = courtReputation;
        townReputationImg.fillAmount = townReputation;
    }

    // Update is called once per frame
    void Update()
    {
        courtReputationImg.fillAmount = courtReputation;
        townReputationImg.fillAmount = townReputation;

        if ( townReputation < 0.25 || townReputation > 0.75)
        {
            SceneManager.LoadScene("Fired");
        }

        if (courtReputation < 0.25 || courtReputation > 0.75)
        {
            SceneManager.LoadScene("Fired");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    goodCase();
        //    Debug.Log("goodCase");
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    badCase();
        //}

        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    firstBribe();   
        //}

        //if (Input.GetKeyDown(KeyCode.F2))
        //{
        //    secondBribe();
        //}

        //if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    thirdBribe();
        //}

        //if (Input.GetKeyDown(KeyCode.F4))
        //{
        //    fourthBribe();
        //}

        //if (Input.GetKeyDown(KeyCode.F5))
        //{
        //    fiveBribe();
        //}

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Order();
        //}
    }

    public void goodCase()
    {
        courtReputation = courtReputation + 0.01f;
        townReputation = townReputation + 0.01f;
    }

    public void badCase()
    {
        courtReputation = courtReputation - 0.01f;
        townReputation = townReputation - 0.01f; ;
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
    }

}
