using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public PauseMenu menu;
    private bool canFinish = false;
    public bool tutorial = false;
    public GameObject timer;

    private void FixedUpdate()
    {
        this.transform.Rotate(0,1f,0);
    }

    // Change the Scene to the next scene given some finish characteristics
    private void OnTriggerEnter(Collider other)
    {
        if (!tutorial)
        {
            if (other.tag == "Player" && canFinish)
            {
                GameObject.Find("TimeManager").GetComponent<TimeManager>().appendTime(timer.GetComponent<Timer>().getCurrentTime());
                menu.NextScene();
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                GameObject.Find("TimeManager").GetComponent<TimeManager>().appendTime(timer.GetComponent<Timer>().getCurrentTime());
                menu.NextScene();
            }
        }
        
    }

    // Set the player able to finish
    public void setCanFinish(bool finish) 
    {
        canFinish = finish;
    }
}
