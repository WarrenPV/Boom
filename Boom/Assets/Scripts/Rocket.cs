using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //written by lars
    public float duration = 5f;
    public float speed = 5f;
    private float launchTime = 0f;
    public float force = 100f;
    public float radius = 5f;
    public float lift = 2f;
    public GameObject explosionHitbox;
    public GameObject Renderer;
    private bool moving;

    //stuff snagged from other rocket code
    // --- Audio ---
    public AudioSource inFlightAudioSource;
    public AudioSource ExplodeSound;
    // --- VFX ---
    public ParticleSystem disableOnHit;
    // --- Explosion VFX ---
    public GameObject rocketExplosion;

    void Start()
    {
        moving = true;
        launchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsGamePaused)
        {
            if (Time.time - launchTime < duration)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
                if (colliders.Length != 0)
                {
                    Explode();
                }
                if (moving)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }

            }
            else
            {
                // Blow Up
                //Explode();
            }
        }
        
    }

    private void Explode() {
        //audioSource.PlayOneShot(ExplosionAudio);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        moving = false;
        foreach (Collider hit in colliders) {
            if(hit.tag == "Movable") {
                hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
            }
        }
        // --- Instantiate new explosion option. I would recommend using an object pool ---
        GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation, null);
        StartCoroutine("ExplosionDestroyMe");
    }

    IEnumerator ExplosionDestroyMe()
    {
        
        explosionHitbox.SetActive(true);
        Renderer.SetActive(false);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }


}
