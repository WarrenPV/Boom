using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject player;

    // On level start, move player to spawn point
    void Start()
    {
        Vector3 spawnpt = transform.position;
        spawnpt.y += 1;
        player.transform.position = spawnpt;
    }
}
