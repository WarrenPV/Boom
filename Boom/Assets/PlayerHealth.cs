using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //written by warren
    public float currentplayerHealth;
    public float maxPlayerHealth;
    public bool Recover;
    public Slider HealthBar;
    public int recoverhealthDelay;

    private void Start()
    {
        HealthBar.maxValue = maxPlayerHealth;
        currentplayerHealth = maxPlayerHealth;
    }
    public void Update()
    {
        HealthBar.value = currentplayerHealth;
        if (Recover)
        {
            AddHealth();
        }
    }
    public void AddHealth()
    {
        if (currentplayerHealth < maxPlayerHealth)
        {
            currentplayerHealth = currentplayerHealth + .05f;
        }
        else
        {
            Recover = false;
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentplayerHealth = currentplayerHealth - damage;

        StartCoroutine("HealthRecoverDelay");
    }

    public IEnumerator HealthRecoverDelay()
    {
        yield return new WaitForSeconds(recoverhealthDelay);
        Recover = true;
    }
}
