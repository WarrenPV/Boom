using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTargets : MonoBehaviour
{
    public GameObject destroyTarget;
    
    
    private void OnTriggerEnter(Collider other)
    {
        
            if (other.tag == "Player")
            {
                
                destroyTarget.SetActive(true);
                StartCoroutine("Delay");
            }
        

    }
    IEnumerator delay()
    {

        yield return new WaitForSeconds(3);
        destroyTarget.SetActive(false);
    }
}
