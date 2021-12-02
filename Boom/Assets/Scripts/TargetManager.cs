using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    private List<GameObject> listOfTargets;
    public GameObject targets;
    public GameObject targetUI;
    public GameObject nextLevel;
    private int targetsLeft;
    
    // On start, add all the children targets to a list of targets
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

        targetsLeft = listOfTargets.Count;
    }

    // If the player has no more targets, can finish, also update the target UI
    void Update()
    {
        if (targetsLeft <= 0) {
            targetUI.GetComponent<TMP_Text>().color = Color.green;
            setFinishable();
        }
        targetsLeft = 0;
        foreach (GameObject target in listOfTargets) {
            if (target.GetComponent<Target>().IsRaised()) {
                targetsLeft++;
            } 
        }
        updateTargetUI();
    }
    
    // Update the UI displaying targets left
    void updateTargetUI() {
        targetUI.GetComponent<TMP_Text>().text = (listOfTargets.Count-targetsLeft) + "/" + listOfTargets.Count;
    }

    // Set the player able to finish
    void setFinishable() {
        nextLevel.GetComponent<NextLevel>().setCanFinish(true);
    }
}
