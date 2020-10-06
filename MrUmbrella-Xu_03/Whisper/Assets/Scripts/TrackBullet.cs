using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBullet : MonoBehaviour
{
    public Transform target;

    private ProjectileProperty PP;
    public bool isDamageOnce;

    public float speed = 5f;
    public float rotateSpeed = 200;

    private Rigidbody2D rb;

    public GameObject Explosion;


    public enum bulletTypes
    {
        e01,
        e07
    }
    public bulletTypes bulletType;

    private AudioSource TAS;
    public AudioClip clip;

    //public Transform GroundOffset;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TAS = GetComponent<AudioSource>();
        PP = GetComponent<ProjectileProperty>();

        if (!TAS.clip) TAS.clip = clip;
        if (!TAS.isPlaying) TAS.Play();
    }


    private void Update()
    {
        //if(rb.gameObject) GroundOffset.position = rb.transform.position;
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
        {
            if(FindObjectOfType<SwitchManager>().isSwitch == false)
            {
                target = GameObject.FindGameObjectWithTag("TC").transform;
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
            }

           
        }
        //Debug.Log(Mathf.Log(1.25f, 2));
            
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Weapon"))
        {
            //FindObjectOfType<ParticleDisapear>().isStartCD = true;
            FindObjectOfType<EnemyFire>().animator.SetBool("isAttack", false);

            Destroy(rb.gameObject);

            Instantiate(Explosion, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z), Quaternion.identity);
        }
        if (collision.transform.CompareTag("Ground"))
        {
            //FindObjectOfType<ParticleDisapear>().isStartCD = true;
            //FindObjectOfType<ParticleDisapear>().isGround = true;
            FindObjectOfType<EnemyFire>().animator.SetBool("isAttack", false);

            Destroy(rb.gameObject);

            Instantiate(Explosion, new Vector3(rb.gameObject.transform.GetChild(0).transform.position.x, rb.gameObject.transform.GetChild(0).transform.position.y, rb.gameObject.transform.GetChild(0).transform.position.z), Quaternion.identity);
            
        }

        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("TC"))
        {
            if(isDamageOnce == false)
            {
                Health PlayerHealth = collision.GetComponent<Health>();
                if (PlayerHealth != null)
                {
                    PlayerHealth.TakeDamage(PP.damage * FindObjectOfType<PlayerAttack>().ProtectionPower);


                    Debug.Log(PlayerHealth.health);
                }

                isDamageOnce = true;

                Instantiate(Explosion, collision.transform.position, Quaternion.identity);

                if(collision.GetComponent<LinkTC>() != null)
                {
                    collision.GetComponent<LinkTC>().LinkDamage(PP.damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
                }
                
                if(bulletType == bulletTypes.e07)
                {
                    if (FindObjectOfType<PlayerController>() != null)
                    {
                        FindObjectOfType<EffectApplier>().ReturnSpeedCall();
                        
                    }
                }
            }

            FindObjectOfType<EnemyFire>().animator.SetBool("isAttack", false);

            Destroy(rb.gameObject);

        }
    }

    
    
}
