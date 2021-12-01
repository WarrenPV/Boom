using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float cubeHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.currentplayerHealth = health.currentplayerHealth + cubeHealth;
            }

            Destroy(gameObject);
        }
    }
}

