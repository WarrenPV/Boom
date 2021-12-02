using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rocketjumponboarding : MonoBehaviour
{

    public GameObject rocketjump;
    public TMP_Text shootme;
    bool leftTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (!leftTrigger)
        {
            if (other.tag == "Player")
            {
                shootme.enabled = true;
                rocketjump.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            leftTrigger = true;
            shootme.enabled = false;
            rocketjump.SetActive(false);
            //StartCoroutine("GoAway");
        }

    }

    IEnumerator GoAway()
    {
        leftTrigger = true;
        yield return new WaitForSeconds(1);
        rocketjump.SetActive(false);
    }
}
