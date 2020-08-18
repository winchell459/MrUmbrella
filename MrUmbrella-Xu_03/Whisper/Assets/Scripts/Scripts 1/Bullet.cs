using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ProjectileProperty PP;
	public Rigidbody2D rb;
	public GameObject impactEffect;

    public enum BulletFireTypes
    {
        SingBullet,
        Fireball,
        SmallBullet
    }
    public BulletFireTypes bulletFireType;

    // Use this for initialization
    public void Setup () {

        PP = GetComponent<ProjectileProperty>();
		

        if (bulletFireType == BulletFireTypes.Fireball)
        {
            rb.velocity = transform.TransformDirection(Vector3.right * PP.speed);
        }
        else if(bulletFireType == BulletFireTypes.SingBullet)
        {
            rb.velocity = transform.right * PP.speed;
        }
        else if(bulletFireType == BulletFireTypes.SmallBullet)
        {
            rb.velocity = transform.right * PP.speed;

            if (Mathf.RoundToInt(transform.eulerAngles.z) == 90)
            {
                rb.velocity = Vector2.right * PP.speed;
            }
            Debug.Log(Mathf.Abs(transform.eulerAngles.z));
        }
        
	}



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        
        //FindObjectOfType<ParticleDisapear>().isStartPlayerCD = true;


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
