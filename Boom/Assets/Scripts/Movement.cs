using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float Speed;
    public float speedAerial;
    private Rigidbody RB;
    public GroundCheck groundCheck;
    public bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    private void Update()
    {
        Grounded = groundCheck.Grounded;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        RB.rotation = Quaternion.Euler(0f, this.transform.rotation.y, 0f);
        if (Grounded)
        {
            float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");
            RB.velocity = new Vector3(mH * Speed, RB.velocity.y, mV * Speed);
            
        }
        else
        {
            float mH = Input.GetAxis("Horizontal");
            float mV = Input.GetAxis("Vertical");
            RB.velocity = new Vector3(mH * speedAerial, RB.velocity.y, mV * speedAerial);
          
        }
        
        

    }

}
