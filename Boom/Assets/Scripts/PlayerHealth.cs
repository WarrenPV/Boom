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
    private AudioSource audiosource;
    public AudioClip healthup;

    private void Start()
    {
        HealthBar.maxValue = maxPlayerHealth;
        currentplayerHealth = maxPlayerHealth;
        audiosource = GetComponent<AudioSource>();
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
        StopCoroutine("HealthRecoverDelay");
        Recover = false;
        if (currentplayerHealth <= 0)
        {
            PauseMenu.Died = true;
            //player died so this should send you to the lose screen or send you back to the beginning
        }

        StartCoroutine("HealthRecoverDelay");
    }

    public IEnumerator HealthRecoverDelay()
    {
        yield return new WaitForSeconds(recoverhealthDelay);
        Recover = true;
    }
}
