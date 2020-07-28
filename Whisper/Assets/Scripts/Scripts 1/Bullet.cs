using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ProjectileProperty PP;
	public Rigidbody2D rb;
	public GameObject impactEffect;

    public bool isDirChange;

    // Use this for initialization
    public void Setup () {

        PP = GetComponent<ProjectileProperty>();
		

        if (isDirChange)
        {
            rb.velocity = transform.TransformDirection(Vector3.right * PP.speed);
        }
        else
        {
            rb.velocity = transform.right * PP.speed;
        }
        
	}



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        
        FindObjectOfType<ParticleDisapear>().isStartPlayerCD = true;


        if (hitInfo.transform.CompareTag("Ground") || hitInfo.transform.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (hitInfo.transform.CompareTag("Enemy"))
        {
            Health EnemyHealth = hitInfo.GetComponent<Health>();
            if (EnemyHealth != null)
            {
                EnemyHealth.TakeDamage(PP.damage);

            }
            
        }


    }
	
}
