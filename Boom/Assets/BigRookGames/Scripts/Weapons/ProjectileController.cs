using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace BigRookGames.Weapons

    public class ProjectileController : MonoBehaviour
    {
        // --- Config ---
        public float speed = 100;
        public LayerMask collisionLayerMask;

        // --- Explosion VFX ---
        public GameObject rocketExplosion;

        // --- Projectile Mesh ---
        public MeshRenderer projectileMesh;

        // --- Script Variables ---
        private bool targetHit;

        // --- Audio ---
        public AudioSource inFlightAudioSource;
        public AudioSource ExplodeSound;

        // --- VFX ---
        public ParticleSystem disableOnHit;

        float launchTime;
        public float duration;
        public float force = 100f;
        public float radius = 5f;
        public float lift = 2f;

        public GameObject explosionDamage;
        bool exploded;

        private void Start()
        {
        exploded = false;
            launchTime = Time.time;
        }


        private void Update()
        {
            // --- Check to see if the target has been hit. We don't want to update the position if the target was hit ---
            if (targetHit) return;

            // --- moves the game object in the forward direction at the defined speed ---
            transform.position += transform.forward * (speed * Time.deltaTime);

            if (Time.time - launchTime > duration)
            {
                Destroy(gameObject);
            }
        }


        /// <summary>
        /// Explodes on contact.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            registerCollision(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            registerCollision(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            registerCollision(collision);
        }

        private void registerCollision(Collision collision) 
        {
            if (collision.gameObject.layer == 3) return;
            exploded = true;
            // --- return if not enabled because OnCollision is still called if compoenent is disabled ---
            if (!enabled) return;

            // --- Explode when hitting an object and disable the projectile mesh ---
            Explode();
            projectileMesh.enabled = false;
            targetHit = true;
            inFlightAudioSource.Stop();
            foreach (Collider col in GetComponents<Collider>())
            {
                col.enabled = false;
            }
            disableOnHit.Stop();


            // --- Destroy this object after 2 seconds. Using a delay because the particle system needs to finish ---
            Destroy(gameObject, 5f);
        }

        /// <summary>
        /// Instantiates an explode object.
        /// </summary>
        private void Explode()
        {
        
            exploded = true;
            ExplodeSound.Play();

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.tag == "Movable")
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, lift);
                }
            }
            // --- Instantiate new explosion option. I would recommend using an object pool ---
            GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation, null);
            explosionDamage.SetActive(true);
            
        
            

        }
}
