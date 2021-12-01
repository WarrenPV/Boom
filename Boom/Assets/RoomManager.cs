using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] Targets;
    public GameObject Barriers;
    public bool roomLocked;
    bool stop = false;
    public bool targetsDown;

    // Start is called before the first frame update
    void Start()
    {
        targetsDown = false;
        Barriers.SetActive(false);
        roomLocked = false;
    }

    public void OnPlayerEntry()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (roomLocked)
        {
            Barriers.SetActive(true);
            OnPlayerEntry();
        }

        foreach (GameObject target in Targets)
        {
            if (target.GetComponent<Target>().IsRaised())
            {
                targetsDown = false;
                goto DONE;
            }
        }
        RoomCleared();
        targetsDown = true;
        DONE:
        return;
        
    }

    void RoomCleared()
    {
        Barriers.SetActive(false);
        roomLocked = false;
    }

}
