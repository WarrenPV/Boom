using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float distanceGround;

    public bool Grounded;

    private void Start()
    {
        distanceGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Check underneath player for ground
    private void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + .1f))
        {
            Grounded = false;
            //Debug.Log("I'm in the air");
        }
        else
        {
            Grounded = true;
            //Debug.Log("Grounded");
        }
    }
}
