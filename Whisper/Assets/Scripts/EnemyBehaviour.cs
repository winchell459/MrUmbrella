using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float IdleTurnSpeed = 50;
    public float ChaseTurnSpeed = 300;
    private Rigidbody2D rb;
    public Transform target;
    public bool Isidle = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (FindObjectOfType<EnemyFire>().isPlayerDead == false) target = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
    }

    private void FixedUpdate()
    {
        if (Isidle == true)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * IdleTurnSpeed);
        }
        if(Isidle == false && target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * ChaseTurnSpeed;

        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Isidle = false;
            
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Isidle = true;
            

        }
    }
}
