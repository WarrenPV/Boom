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
    public GameObject explosion;
    public GameObject Renderer;
    private bool moving;

    // Start is called before the first frame update
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
                Explode();
            }
        }
        
    }

    private void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        moving = false;
        foreach (Collider hit in colliders) {
            if(hit.tag == "Movable") {
                hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
            }
        }
        StartCoroutine("ExplosionDestroyMe");
        //Destroy(gameObject);
    }

    IEnumerator ExplosionDestroyMe()
    {
        explosion.SetActive(true);
        Renderer.SetActive(false);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }


}
