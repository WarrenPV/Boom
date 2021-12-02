using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumponboarding : MonoBehaviour
{
    
        public GameObject jump;
        bool leftTrigger;
        private void OnTriggerEnter(Collider other)
        {
            if (!leftTrigger)
            {
                if (other.tag == "Player")
                {
                    jump.SetActive(true);
                }
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                leftTrigger = true;
            
                jump.SetActive(false);
                //StartCoroutine("GoAway");
        }

        }

        IEnumerator GoAway()
        {
            leftTrigger = true;
            yield return new WaitForSeconds(1);
            jump.SetActive(false);
        }

}
