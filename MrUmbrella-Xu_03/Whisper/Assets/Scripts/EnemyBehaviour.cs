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





    public enum EnemyTypes
    {
        eo1,
        eo3
    }
    public EnemyTypes enemyType;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        if(enemyType == EnemyTypes.eo1)
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
        else if(enemyType == EnemyTypes.eo3)
        {
            if(Isidle == false)
            {
                anim.SetBool("isAttack", true);
                
            }
            else
            {

                anim.SetBool("isAttack", false);
            }
        }
        

        
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

    }

    public void EnemyDIE()
    {
        DespawnObjects();

        Destroy(gameObject);
    }
}
