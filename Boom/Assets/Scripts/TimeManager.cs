using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<float> levelTimes = new List<float>();
    string totalStr;
    bool setString = false;

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Win" && !setString) {
            setString = true;
            int level = 0;
            string levelStr = "";
            totalStr = "~ Times ~\n";
            float sumTime = 0;
            foreach(float levelTime in levelTimes) {
                if(level == 0) {
                    levelStr = "Tutorial - ";
                } else {
                    levelStr = "Level " + level + " - ";
                }
                sumTime += levelTime;
                string levelTimeStr = ((int) levelTime / 60).ToString("d2") +":"+ ((int) levelTime % 60).ToString("d2");
                totalStr += levelStr + levelTimeStr + "\n";
                level++;
            }
            totalStr += "Total Time - " + ((int) sumTime / 60).ToString("d2") +":"+ ((int) sumTime % 60).ToString("d2");
        }
        if (GameObject.Find("finaltimes") != null) {
            GameObject.Find("finaltimes").GetComponent<TMP_Text>().text = totalStr;
        }
    }

    public void appendTime(float time) {
        levelTimes.Add(time);
    }
}
