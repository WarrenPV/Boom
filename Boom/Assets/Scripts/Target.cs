using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Written by Ethan
public class Target : MonoBehaviour {
    public bool raised;
    public GameObject popup;
    public AudioSource audio;

    Vector3 popupGoal = Vector3.zero;

    private void Start()
    {
       
    }
    public bool IsRaised() {
        return raised;
    }

    public void RaiseTarget() {
        audio.Play();
        popupGoal = Vector3.up;
        raised = true;
    }

    public void LowerTarget() {

        audio.Play();
        popupGoal = Vector3.zero;
        raised = false;
    }

    private void Update() {
        popup.transform.localPosition = Vector3.Lerp(popup.transform.localPosition, popupGoal, .3f);
    }
}
