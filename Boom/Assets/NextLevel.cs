using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public PauseMenu menu;

    private void FixedUpdate()
    {
        this.transform.Rotate(0,1f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            menu.NextScene();
        }
    }
}
