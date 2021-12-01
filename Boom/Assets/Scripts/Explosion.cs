using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime;

    private void OnEnable()
    {
        StartCoroutine("DisableMe");
    }
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
        if (other.tag == "Target")
        {
            Debug.Log("I hit a target");
            var Target = other.GetComponent<Target>();
            if (Target != null)
            {
                Target.raised = false;
                Debug.Log("targetdown");
            }
        }
    }

    IEnumerator DisableMe()
    {

        yield return new WaitForSeconds(lifeTime);
        this.gameObject.SetActive(false);
    }
}
