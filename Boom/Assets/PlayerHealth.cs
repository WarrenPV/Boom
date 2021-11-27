using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int maxPlayerHealth;
    public bool Recover;

    public void Update()
    {
        if (Recover)
        {
            AddHealth();
        }
    }
    public void AddHealth()
    {
        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = playerHealth + 1;
        }
        
    }

    IEnumerator HealthDelay()
    {
        yield return new WaitForSeconds(2);
        Recover = true;
    }
}
