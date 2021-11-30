using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{

    GameObject PlayerHealth;
    PlayerHealth healthScript;

    public float barrelDamage;
    public float breakForce;

    public GameObject Barrel, Explosion;
    public bool explodeBool = false;


    private AudioSource source;

    [SerializeField]
    private float range;

    private void Awake()
    {
        PlayerHealth = GameObject.Find("Player");
        healthScript = PlayerHealth.GetComponent<PlayerHealth>();

        Barrel.SetActive(true);
        Explosion.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        Barrel.SetActive(false);
        Explosion.SetActive(true);
        source.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider hit in colliders)
        {
            if(hit.tag == "Moveable" && hit.name == "Player")
            {
                healthScript.currentplayerHealth = healthScript.currentplayerHealth - barrelDamage;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
            explodeBool = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude >= breakForce)
        {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missile")
        {
            Explode();
        }
    }
}
