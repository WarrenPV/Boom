using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosiveBarrel : MonoBehaviour
{

    public float barrelDamage;
    public float breakForce;

    public GameObject Barrel, Explosion;
    public ParticleSystem explosionParticles;

    public Animator barrelAnim;
    public bool explodeBool = false;
    public float explosionDelay;

    private AudioSource source;
    public float duration;
    public float force = 100f;
    public float radius = 5f;
    public float lift = 2f;
    bool blinking;

    [SerializeField]
    private float range;

    private void Awake()
    {

        Barrel.SetActive(true);
        Explosion.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        Barrel.SetActive(false);
        Explosion.SetActive(true);
        explosionParticles.Play();
        source.Play();
        StartCoroutine("DestroyMyself");
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider hit in colliders)
        {
            if (hit.tag == "Movable")
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
            }
        }
    }

    private void Update()
    {

        if (blinking)
        {
            StartCoroutine("Blinking");
        }
            
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.relativeVelocity.magnitude >= breakForce)
    //    {
    //        Explode();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missile")
        {
            Explode();
        }
        if (other.tag == "Player")
        {
            barrelAnim.SetTrigger("BarrelExplode");
            StartCoroutine("ExplosionDelay");
        }
    }
    IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(explosionDelay);
        StopCoroutine("Blinking");
        yield return new WaitForSeconds(.1f);
        Explode();
    }
    
    
}
