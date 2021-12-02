using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float cubeHealth;
    AudioSource audiosource;
    public AudioClip hpUp;
    public Collider collider;
    public MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        audiosource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                collider.enabled = false;
                mesh.enabled = false;
                health.currentplayerHealth = health.currentplayerHealth + cubeHealth;
                
                StartCoroutine("DeleteMe");
            }
            
        }
    }

    IEnumerator DeleteMe()
    {
        audiosource.PlayOneShot(hpUp, .45f);
        yield return new WaitForSeconds(audiosource.clip.length);
        Destroy(gameObject);
    }
}

