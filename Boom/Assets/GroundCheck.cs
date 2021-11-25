using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool Grounded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Grounded = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            Grounded = false;

        }
    }
}
