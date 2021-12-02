using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private string currentTime;
    private float startTime;
    private bool hasMoved = false;
    public GameObject player;
    public GameObject spawnPoint;
    private Vector3 spawnPos;

    // Set the initial positions of the spawn
    void Start() {
        spawnPos = spawnPoint.transform.position;
        spawnPos.y += 1f;
    }

    // If player has left the spawn, initialize timer
    void Update()
    {
        if(Vector3.Distance(player.transform.position, spawnPos) > 0.3f || Input.GetKeyDown(KeyCode.Mouse0)) {
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

    public float getCurrentTime() {
        return Time.time - startTime;
    }
}
