using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] Targets;
    public GameObject Barriers;
    public bool roomLocked;
    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            target.GetComponent<Target>().raised = true;
            
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
    }

}
