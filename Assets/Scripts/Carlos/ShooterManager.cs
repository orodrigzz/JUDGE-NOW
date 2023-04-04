using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] Transform Shooter_R;
    [SerializeField] Transform Shooter_L;
    [SerializeField] Rigidbody Proyectile;
    [SerializeField] float rightShooterTargetTime;
    [SerializeField] float rightShooterTime;
    [SerializeField] float leftShooterTargetTime;
    [SerializeField] float leftShooterTime;
    public Transform player;
    public Vector3 direction;
    public LayerMask layer;

    private void Awake()
    {
        direction = (player.position - transform.position).normalized;
    }
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
        Vector3 Vo = CalculateVelocity(direction, Shooter_R.transform.position, 20f);
        Instantiate(Proyectile, Shooter_R, false);

        Proyectile.velocity = Vo;
    }
    public void ShootLeft()
    {
        Vector3 Vo = CalculateVelocity(direction, Shooter_L.transform.position, 20f);
        Instantiate(Proyectile, Shooter_L, false);

        Proyectile.velocity = Vo;
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
