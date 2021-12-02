using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoarding : MonoBehaviour
{
    public GameObject WASD;
    bool leftTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (!leftTrigger)
        {
            if (other.tag == "Player")
            {
                WASD.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            leftTrigger = true;
            WASD.SetActive(false);
            //StartCoroutine("GoAway");
        }

    }

    IEnumerator GoAway()
    {
        leftTrigger = true;
        yield return new WaitForSeconds(1);
        
    }

}
