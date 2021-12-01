using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTrigger : MonoBehaviour
{
    public RoomManager roomManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            roomManager.roomLocked = true;
        }
    }
}
