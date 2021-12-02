using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<float> levelTimes = new List<float>();

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        // levelTimes.Add(30.64f);
        // levelTimes.Add(100.23f);
        // levelTimes.Add(15.41f);
        // levelTimes.Add(70.49f);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Win") {
            string totalStr = "Times:\n";
            int level = 0;
            string levelStr = "";
            float sumTime = 0;
            foreach(float levelTime in levelTimes) {
                if(level == 0) {
                    levelStr = "Tutorial: ";
                } else {
                    levelStr = "Level " + level + ": ";
                }
                sumTime += levelTime;
                string levelTimeStr = ((int) levelTime / 60).ToString("d2") +":"+ ((int) levelTime % 60).ToString("d2");
                totalStr += levelStr + levelTimeStr + "\n";
                level++;
            }
            totalStr += "Total Time: " + ((int) sumTime / 60).ToString("d2") +":"+ ((int) sumTime % 60).ToString("d2");
            GameObject.Find("finaltimes").GetComponent<TMP_Text>().text = totalStr;
        }
    }

    public void appendTime(float time) {
        levelTimes.Add(time);
    }
}
