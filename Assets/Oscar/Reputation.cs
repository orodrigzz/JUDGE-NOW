using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reputation : MonoBehaviour
{
    [SerializeField] private float courtReputation = 0.5f;
    [SerializeField] private float townReputation = 0.5f;
    [SerializeField] private Image courtReputationImg;
    [SerializeField] private Image townReputationImg;
    [SerializeField] private Image defCourtReputation;
    [SerializeField] private Image defTownReputation;

    // Start is called before the first frame update
    void Start()
    {
        courtReputationImg.fillAmount = courtReputation;
        townReputationImg.fillAmount = townReputation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goodCase();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            badCase();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            firstBribe();   
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            secondBribe();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            thirdBribe();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            fourthBribe();
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            fiveBribe();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Order();
        }
    }

    public void goodCase()
    {
        courtReputation = courtReputation + 0.03f;
        townReputation = townReputation + 0.03f;
    }

    public void badCase()
    {
        courtReputation = courtReputation - 0.05f;
        townReputation = townReputation - 0.05f;
    }

    //Sobornos
    public void firstBribe()
    {
        courtReputation = courtReputation + 0.03f;
        townReputation = townReputation - 0.03f;
    }

    public void secondBribe()
    {
        courtReputation = courtReputation + 0.03f;
        townReputation = townReputation - 0.05f;
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
