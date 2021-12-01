using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private List<GameObject> listOfTargets;
    public GameObject targets;
    private bool allTargetsDown = false;
    // Start is called before the first frame update
    void Start()
    {
        listOfTargets = new List<GameObject>();
        foreach (Transform child in targets.transform) {
            if (child == null)
                continue;
            listOfTargets.Add(child.gameObject);
        }

        foreach (GameObject target in listOfTargets) {
            target.GetComponent<Target>().RaiseTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (allTargetsDown) {
            Debug.Log("Got all targets down...");
        }
        foreach (GameObject target in listOfTargets) {
            if (target.GetComponent<Target>().IsRaised()) {
                allTargetsDown = false;
                goto DONE;
            }
        }
        allTargetsDown = true;
        DONE:
        return;
    }
}
