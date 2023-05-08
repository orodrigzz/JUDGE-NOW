using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform player;
    public Vector3 direction;
    public LayerMask layer;
    [SerializeField] Transform Shooter_L;
    [SerializeField] Rigidbody Proyectile;
    [SerializeField] public float leftShooterTargetTime;
    [SerializeField] float leftShooterTime;
    [SerializeField] Vector3 leftVel;

    public GameObject exclamation;

    private void Awake()
    {
        if(exclamation != null)
        {
            exclamation.SetActive(false);
        }
        
    }

    void Start()
    {
        leftShooterTargetTime = leftShooterTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.noise >= 0.2)
        {
            leftShooterTargetTime -= Time.deltaTime;

            if (leftShooterTargetTime <= 2)
            {
                exclamation.SetActive(true);
            }

            if (leftShooterTargetTime <= 0)
            {
                direction = player.position;
                leftVel = CalculateVelocity(direction, Shooter_L.transform.position, 1f);
                ShootLeft();
                GAME_MANAGER._GAME_MANAGER.hasShootedL = true;
                leftShooterTargetTime = leftShooterTime;
                StartCoroutine(Wait());
            }
        }
        if(GAME_MANAGER._GAME_MANAGER.currentScene.name == "Tutorial")
        {
            direction = player.position;
            leftVel = CalculateVelocity(direction, Shooter_L.transform.position, 1f);
        }
        
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

    public void ShootLeft()
    {
        Rigidbody obj = Instantiate(Proyectile, Shooter_L.position, Quaternion.identity);
        obj.velocity = leftVel;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        GAME_MANAGER._GAME_MANAGER.hasShootedL = false;
        exclamation.SetActive(false);
    }
}
