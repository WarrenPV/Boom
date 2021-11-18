using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float duration = 5f;
    public float speed = 5f;
    private float launchTime = 0f;
    public float force = 100f;
    public float radius = 5f;
    public float lift = 2f;
    // Start is called before the first frame update
    void Start()
    {
        launchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - launchTime < duration) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
            if (colliders.Length != 0) {
                Explode();
            } 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        } else {
            // Blow Up
            Explode();
        }
    }

    private void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); 
        foreach (Collider hit in colliders) {
            if(hit.tag == "Movable") {
                hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
            }
        }
        Destroy(gameObject);
    }
}
