using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTester : MonoBehaviour {
    Target[] targets;

    private void Awake() {
        targets = FindObjectsOfType<Target>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            StartCoroutine(RaiseAll());
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            StartCoroutine(LowerAll());
        }
    }

    IEnumerator RaiseAll() {
        foreach(Target t in targets) {
            yield return new WaitForSeconds(.2f);
            t.RaiseTarget();
        }
    }

    IEnumerator LowerAll() {
        foreach(Target t in targets) {
            yield return new WaitForSeconds(.2f);
            t.LowerTarget();
        }
    }
}
