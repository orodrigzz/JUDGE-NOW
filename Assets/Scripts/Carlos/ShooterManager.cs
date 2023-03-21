using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] Transform Shooter_R;
    [SerializeField] Transform Shooter_L;
    [SerializeField] GameObject Proyectile;
    [SerializeField] float rightShooterTargetTime;
    [SerializeField] float rightShooterTime;
    [SerializeField] float leftShooterTargetTime;
    [SerializeField] float leftShooterTime;

    void Start()
    {
        rightShooterTargetTime = rightShooterTime;
        leftShooterTargetTime = leftShooterTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.noise >= 0.1)
        {
            rightShooterTargetTime -= Time.deltaTime;
            if(rightShooterTargetTime <= 0)
            {
                ShootRight();
                rightShooterTargetTime = rightShooterTime;
            }
        }
        if (GAME_MANAGER._GAME_MANAGER.noise >= 0.2)
        {
            leftShooterTargetTime -= Time.deltaTime;
            if (leftShooterTargetTime <= 0)
            {
                ShootLeft();
                leftShooterTargetTime = rightShooterTime;
            }
        }
    }

    public void ShootRight()
    {
        Instantiate(Proyectile, Shooter_R, false);
    }
    public void ShootLeft()
    {
        Instantiate(Proyectile, Shooter_L, false);
    }
}
