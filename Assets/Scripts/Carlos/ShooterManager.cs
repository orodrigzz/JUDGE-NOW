using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] Transform Shooter_R;
    [SerializeField] Transform Shooter_L;
    [SerializeField] GameObject Proyectile;
    [SerializeField] float indexShooter;
    [SerializeField] float randNum;
    
    void Start()
    {
        indexShooter = -1;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
