using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootR : MonoBehaviour
{
    public Transform player;
    public Vector3 direction;
    public LayerMask layer;
    [SerializeField] Transform Shooter_R;
    [SerializeField] Rigidbody Proyectile;
    [SerializeField] float rightShooterTargetTime;
    [SerializeField] float rightShooterTime;
    [SerializeField] Vector3 rightVel;
    void Start()
    {
        rightShooterTargetTime = rightShooterTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.noise >= 0.1)
        {
            rightShooterTargetTime -= Time.deltaTime;
            if (rightShooterTargetTime <= 0)
            {
                direction = player.position;
                rightVel = CalculateVelocity(direction, Shooter_R.transform.position, 1f);
                ShootRight();
                rightShooterTargetTime = rightShooterTime;
            }
        }
    }

    public void ShootRight()
    {
        Rigidbody obj = Instantiate(Proyectile, Shooter_R.position, Quaternion.identity);
        obj.velocity = rightVel;
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
