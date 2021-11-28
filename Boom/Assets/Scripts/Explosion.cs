using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                var Damage = GetComponent<Damage>();

                health.TakeDamage(Damage.damage);
                
            }
        }
    }
}
