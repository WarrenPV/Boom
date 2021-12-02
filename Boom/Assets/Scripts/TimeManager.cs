using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<float> levelTimes = new List<float>();

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        foreach(float levelTime in levelTimes) {
            string levelTimeStr = ((int) levelTime / 60).ToString("d2") +":"+ ((int) levelTime % 60).ToString("d2");
        }
    }

    public void appendTime(float time) {
        levelTimes.Add(time);
    }
}
