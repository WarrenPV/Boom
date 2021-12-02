using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public PauseMenu menu;
    private bool canFinish = false;

    private void FixedUpdate()
    {
        this.transform.Rotate(0,1f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canFinish)
        {
            menu.NextScene();
        }
    }

    public void setCanFinish(bool finish) 
    {
        canFinish = finish;
    }
}
