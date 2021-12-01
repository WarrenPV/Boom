using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private string currentTime;
    private float startTime;
    private bool hasMoved = false;
    public GameObject player;
    public GameObject spawnPoint;
    private Vector3 spawnPos;

    // Update is called once per frame
    void Start() {
        spawnPos = spawnPoint.transform.position;
        spawnPos.y += 1f;
    }
    void Update()
    {
        if(Vector3.Distance(player.transform.position, spawnPos) > 0.1f) {
            if (!hasMoved) {
                startTime = Time.time;
            }
            hasMoved = true;
        }
        if (hasMoved) {
            currentTime = ((int) (Time.time - startTime) / 60).ToString("d2") +":"+ ((int) (Time.time - startTime) % 60).ToString("d2");
            gameObject.GetComponent<TMP_Text>().text = currentTime;
        }
    }
}
