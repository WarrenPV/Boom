using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    //written by lars
    public float fireRate = 2f;
    private bool canShoot = true;
    private float lastShot = 0f;
    public GameObject rocket;
    public GameObject mouth;
    

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsGamePaused)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
            {
                fire();
                lastShot = Time.time;
                canShoot = false;
            }
            else
            {
                if (Time.time - lastShot > fireRate)
                {
                    canShoot = true;
                }
            }
        }
    }

    private void fire() {
        Quaternion shotDirection = transform.rotation;
        Instantiate(rocket, mouth.transform.position, shotDirection);
    }
}
