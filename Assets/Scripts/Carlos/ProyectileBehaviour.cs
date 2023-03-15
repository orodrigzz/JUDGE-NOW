using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public Transform player;
    public Vector3 direction;
    private Rigidbody rb;

    private void Awake()
    {
        direction = (player.position - transform.position).normalized;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           GAME_MANAGER._GAME_MANAGER.courtReputation = GAME_MANAGER._GAME_MANAGER.courtReputation - 0.1f;
            GAME_MANAGER._GAME_MANAGER.courtReputation = GAME_MANAGER._GAME_MANAGER.townReputation - 0.1f;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}