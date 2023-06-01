using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HammerBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    
    [SerializeField] AudioSource AudioMazo;
    [SerializeField] AudioSource Bonk;
    [SerializeField] AudioSource Interruptor;
    [SerializeField] AudioSource Ouch;
    [SerializeField] AudioSource silencio;
    [SerializeField] AudioSource OuchWoman;
    [SerializeField] AudioSource Notificacion;
    [SerializeField] AudioSource Diana;
    [SerializeField] AudioSource chargeSound;
    [SerializeField] AudioSource macetazo;
    [SerializeField] bool charHasSound;

    [SerializeField] int mazazos;

    [SerializeField] GameObject particle_1;
    [SerializeField] GameObject particle_2;
    [SerializeField] GameObject particle_3;
    private void Awake()
    {
        mazazos = 0;
        particle_1.SetActive(false);
        particle_2.SetActive(false);
        particle_3.SetActive(false);
    }

    private void Update()
    {
        rb = GetComponent<Rigidbody>();

        if (mazazos % 10 == 0 && mazazos > 0)
        {
            silencio.Play();
        }
        if (GAME_MANAGER._GAME_MANAGER.isPickingHammer)
        {
            if (GAME_MANAGER._GAME_MANAGER.objectVel <= 800F)
            {
                particle_1.SetActive(false);
                particle_2.SetActive(false);
                particle_3.SetActive(false);
                chargeSound.Stop();
                charHasSound = false;
            }
            if (GAME_MANAGER._GAME_MANAGER.objectVel >= 850f)
            {
                particle_1.SetActive(true);
                if (!charHasSound)
                {
                    chargeSound.Play();
                    charHasSound = true;
                }

            }
            if (GAME_MANAGER._GAME_MANAGER.objectVel >= 950f)
            {
                particle_1.SetActive(false);
                particle_2.SetActive(true);
                chargeSound.pitch = 2f;
            }
            if (GAME_MANAGER._GAME_MANAGER.objectVel >= 1000f)
            {
                particle_1.SetActive(false);
                particle_2.SetActive(false);
                particle_3.SetActive(true);
                chargeSound.pitch = 3f;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            if(AudioMazo != null)
            {
                AudioMazo.Play();
            }
            
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                GAME_MANAGER._GAME_MANAGER.Order();
                
                mazazos++;
            }
        }

        if (collision.gameObject.tag == "Testigo_M")
        {
            Bonk.Play();
            Ouch.Play();

            if (GAME_MANAGER._GAME_MANAGER.decisionMode)
            {
                StartCoroutine(WaitForDestroy(2.5f));
            }
            else
            {
                StartCoroutine(WaitForDestroy(1.5f));
            }
        }

        if (collision.gameObject.tag == "Testigo_W")
        {
            Bonk.Play();
            OuchWoman.Play();
            
            if (GAME_MANAGER._GAME_MANAGER.decisionMode)
            {
                StartCoroutine(WaitForDestroy(2.5f));
                
            }
            else
            {
                StartCoroutine(WaitForDestroy(1.5f));
            }
        }

        if (collision.gameObject.tag == "NPC")
        {
            Bonk.Play();
            Ouch.Play();
            StartCoroutine(WaitForDestroy(1.5f));
           
        }

        if (collision.gameObject.tag == "NPC_W")
        {
            Bonk.Play();
            OuchWoman.Play();
            StartCoroutine(WaitForDestroy(1.5f));
            
        }

        if (collision.gameObject.tag == "Diana")
        {
            Diana.Play();
            Notificacion.Play();
            StartCoroutine(WaitForDestroy(1.5f));
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door" || collision.gameObject.tag == "Atril")
        {
            //AudioMazo.Play();
            if (GAME_MANAGER._GAME_MANAGER.isPicked == false)
            {
                GAME_MANAGER._GAME_MANAGER.objectVel = 800f;
                if (GAME_MANAGER._GAME_MANAGER.decisionMode)
                {
                    GAME_MANAGER._GAME_MANAGER.decisionMode = false;
                }

                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.tag == "Apple" || collision.gameObject.tag == "Tomatoe" || collision.gameObject.tag == "Mobile" || collision.gameObject.tag == "Rules1" || collision.gameObject.tag == "Rules2" || collision.gameObject.tag == "Rules3")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider>());
        }

        if (collision.gameObject.tag == "Table")
        {
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        if(collision.gameObject.tag == "Flecha")
        {
            GAME_MANAGER._GAME_MANAGER.caseEnded = true;
        }

        if (collision.gameObject.tag == "Planta")
        {
            macetazo.Play();
            StartCoroutine(WaitForDestroy(1));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Switch")
        {
            Interruptor.Play();
            StartCoroutine(WaitForDestroy(1));
            if (GAME_MANAGER._GAME_MANAGER.lightsOn == false)
            {
                GAME_MANAGER._GAME_MANAGER.TurnUpLights();
                GAME_MANAGER._GAME_MANAGER.lightsOn = true;
                GAME_MANAGER._GAME_MANAGER.noise -= 0.2f;
                GAME_MANAGER._GAME_MANAGER.noiseAudio.volume -= 0.2f;
            }
           
        }
    }

    IEnumerator WaitForDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        GAME_MANAGER._GAME_MANAGER.objectVel = 800f;
        if (GAME_MANAGER._GAME_MANAGER.decisionMode)
        {
            GAME_MANAGER._GAME_MANAGER.decisionMode = false;
        }
        Destroy(this.gameObject);   
    }

   
}
