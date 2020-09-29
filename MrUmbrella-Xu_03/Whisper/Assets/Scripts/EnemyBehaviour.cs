using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : SpawnObjects
{
    public float IdleTurnSpeed = 50;
    public float ChaseTurnSpeed = 300;
    private Rigidbody2D rb;
    public Transform target;
    public bool Isidle = true;

    public bool MovingRight;

    public Animator anim;

    public float damage;

    public GameObject Player;

    public Vector2 smooth;

    public float fallInterval;

    public float speed;
    
    Vector2 startpos;


    float x;
    float y;





    public enum EnemyTypes
    {
        eo1,
        eo3,
        eo4,
        eo5,
        eo6,
        eo7
    }
    public EnemyTypes enemyType;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = transform.position;
    }
    private void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
        {
            target = FindObjectOfType<PlayerDeadManager>().playerGO.transform;



        }
        if(transform.GetChild(0).CompareTag("Enemy") == false)
        {
            gameObject.SetActive(false);
        }

    }



    private void FixedUpdate()
    {
        if (enemyType == EnemyTypes.eo1)
        {
            if (Isidle == true)
            {
                transform.Rotate(Vector3.forward, Time.deltaTime * IdleTurnSpeed);
            }
            if (Isidle == false && target != null)
            {
                Vector2 direction = (Vector2)target.position - rb.position;

                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateAmount * ChaseTurnSpeed;

            }
        }
        else if (enemyType == EnemyTypes.eo3)
        {
            if (Isidle == false)
            {
                anim.SetBool("isAttack", true);

            }
            else
            {

                anim.SetBool("isAttack", false);
            }
        }
        else if (enemyType == EnemyTypes.eo4)
        {
            if (Isidle == false)
            {
                anim.SetBool("isAttack", true);
            }
            else
            {
                if (target != null)
                {
                    x = Mathf.Lerp(x, target.transform.position.x, smooth.x * Time.deltaTime);
                    y = Mathf.Lerp(y, target.transform.position.y, smooth.y * Time.deltaTime);

                    transform.position = new Vector3(x, y, transform.position.z);

                    anim.SetBool("isAttack", false);
                }

            }
        }
        else if (enemyType == EnemyTypes.eo5)
        {


            if (Isidle == false)
            {
                Invoke("E05Fall", fallInterval);
            }
            else
            {
                rb.velocity = new Vector2(0, speed) * transform.up;
                anim.SetBool("isAttack", true);

            }


            

        }
        else if (enemyType == EnemyTypes.eo6)
        {
            if (Isidle == false)
            {
                anim.SetBool("isAttack", true);

            }
            else
            {

                anim.SetBool("isAttack", false);

            }

            

            
        }
        else if (enemyType == EnemyTypes.eo7)
        {
            if (Isidle == false)
            {
                anim.SetBool("isAttack", true);

            }
            else
            {

                anim.SetBool("isAttack", false);

            }
        }



    }
    public void E05Fall()
    {

        anim.SetBool("isAttack", false);
        rb.velocity = new Vector2(0, 0);
        transform.position = startpos;
        Isidle = true;
    }



    
    public void Attack()
    {
        Player.gameObject.GetComponent<Health>().TakeDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemyType == EnemyTypes.eo1)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;
                

            }
        }else if(enemyType == EnemyTypes.eo3)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;

                Player = collision.gameObject;

                
            }
        }
        else if (enemyType == EnemyTypes.eo4)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;
            }
        }
        else if (enemyType == EnemyTypes.eo5)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;
                collision.gameObject.GetComponent<Health>().TakeDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
            }
            if (collision.transform.CompareTag("Ground"))
            {
                Isidle = false;
            }
            
        }
        else if (enemyType == EnemyTypes.eo6)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;
                
            }
        }
        else if (enemyType == EnemyTypes.eo7)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = false;

            }
        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemyType == EnemyTypes.eo1)
        {
            if(collision.transform.CompareTag("Player"))
            {
                Isidle = true;

            }
        }
        else if (enemyType == EnemyTypes.eo3)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = true;

            }
        }
        else if (enemyType == EnemyTypes.eo4)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = true;
            }
        }
        else if (enemyType == EnemyTypes.eo5)
        {
            if (collision.transform.CompareTag("Player"))
            {
                
            }
            
        }
        else if (enemyType == EnemyTypes.eo6)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = true;
                
            }
        }
        else if (enemyType == EnemyTypes.eo7)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Isidle = true;

            }
        }

    }

    public void EnemyDIE()
    {
        DespawnObjects();

        Destroy(gameObject);
    }
}
