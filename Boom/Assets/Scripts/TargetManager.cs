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

        targetsLeft = listOfTargets.Count;
    }

    // Update is called once per frame
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

    void updateTargetUI() {
        targetUI.GetComponent<TMP_Text>().text = (listOfTargets.Count-targetsLeft) + "/" + listOfTargets.Count;
    }

    void setFinishable() {
        nextLevel.GetComponent<NextLevel>().setCanFinish(true);
    }
}
