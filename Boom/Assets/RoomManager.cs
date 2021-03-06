using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomManager : MonoBehaviour
{
    public GameObject[] Targets;
    public GameObject Barriers;
    public bool roomLocked;
    bool stop = false;
    public bool targetsDown;
    public TMP_Text targetsLeftText;
    public GameObject targetsLeftUI;

    // Initialize the tutorial room
    void Start()
    {
        targetsDown = false;
        Barriers.SetActive(false);
        roomLocked = false;
        targetsLeftText.text = "0/" +Targets.Length;
        targetsLeftUI.SetActive(false);
    }

    // When a player enters the room, raise targets and show count
    public void OnPlayerEntry()
    {
        targetsLeftUI.SetActive(true);
        targetsLeftText.color = Color.red;
        targetsLeftText.text = "0/" + Targets.Length;
        if (stop)
        {
            return;
        }
        foreach (GameObject target in Targets)
        {
            target.GetComponent<Target>().RaiseTarget();
            
        }
        stop = true;
        
    }

    // Update the room based on targets hit
    void Update()
    {
        if (roomLocked)
        {
            Barriers.SetActive(true);
            OnPlayerEntry();
        }

        int targetsLeft = 0;

        foreach (GameObject target in Targets)
        {
            if (target.GetComponent<Target>().IsRaised())
            {
                targetsLeft++;
                targetsDown = false;
            }
        }

        if (!targetsDown)
        {
            targetsLeftText.text = (Targets.Length - targetsLeft) + "/" + Targets.Length;


            if (targetsLeft == 0)
            {
                RoomCleared();
                targetsLeftText.color = Color.green;
                targetsDown = true;
            }
            return;
        }
        
    }

    // Allow player to exit room to finish
    void RoomCleared()
    {
        Barriers.SetActive(false);
        roomLocked = false;
    }

}
