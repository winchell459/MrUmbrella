using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200;

    private Rigidbody2D rb;

    public GameObject Explosion;

    public bool isPlayerDead;

    //public Transform GroundOffset;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }


    private void Update()
    {
        //if(rb.gameObject) GroundOffset.position = rb.transform.position;
        if(!isPlayerDead) target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (target.gameObject != null)
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
            FindObjectOfType<ParticleDisapear>().isStartCD = true;
            
            Destroy(rb.gameObject);

            Instantiate(Explosion, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z), Quaternion.identity);
        }
        if (collision.transform.CompareTag("Ground"))
        {
            FindObjectOfType<ParticleDisapear>().isStartCD = true;
            FindObjectOfType<ParticleDisapear>().isGround = true;

            Destroy(rb.gameObject);

            Instantiate(Explosion, new Vector3(rb.gameObject.transform.GetChild(0).transform.position.x, rb.gameObject.transform.GetChild(0).transform.position.y, rb.gameObject.transform.GetChild(0).transform.position.z), Quaternion.identity);
            
        }
    }
    
}
