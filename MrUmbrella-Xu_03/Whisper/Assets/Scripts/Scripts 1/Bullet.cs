using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ProjectileProperty PP;
	public Rigidbody2D rb;
	public GameObject impactEffect;
    private Vector3 SMcurpos;
    private Vector3 SBcurpos;

    private Vector2 Click;

    public float SmallBulletMaxD = 7.5f;

    public GameObject Player;

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
            //rb.velocity = transform.right * PP.speed;

            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (target - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * PP.speed, direction.y * PP.speed);

            //float rotateAmount = Vector3.Cross(direction, transform.up).z;

            //rb.angularVelocity = -rotateAmount * 10000000;

            SBcurpos = transform.position;



        }
        else if(bulletFireType == BulletFireTypes.SmallBullet)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (target - transform.position).normalized;
            Click = direction;
            rb.velocity = new Vector2(direction.x * PP.speed, direction.y * PP.speed);

            SMcurpos = transform.position;
        }
        
	}
    private void FixedUpdate()
    {
        if(FindObjectOfType<PlayerDeadManager>().isPlayerDied == false) Player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if (bulletFireType == BulletFireTypes.SingBullet)
        {
            transform.right = rb.velocity;
            
            PP.damage = Mathf.Clamp(SBDamageLine(1.2f, Mathf.Abs(SBcurpos.x - transform.position.x)), 0, 7f) + Mathf.Clamp(SBDamageLine(0.5f, Mathf.Abs(SBcurpos.y - transform.position.y)), 0, 2);

            //Debug.Log(PP.damage);
        }
        if (bulletFireType == BulletFireTypes.SmallBullet)
        {
            if(Mathf.Abs(SMcurpos.x - transform.position.x) > SmallBulletMaxD || Mathf.Abs(SMcurpos.y - transform.position.y) > SmallBulletMaxD)
            {
                Destroy(gameObject);
            }

            PP.damage = Mathf.Clamp(SMDamageLine(1.1f, -Mathf.Abs(Player.transform.position.x - Click.x), 10), 0, 10);

            Debug.Log(-Mathf.Abs(Player.transform.position.x - Click.x));
        }
    }

    public float SMDamageLine(float m, float x, float b)
    {

        float y = m*x + b;

        return y;
    }

    public float SBDamageLine(float a, float x)
    {
        float y = Mathf.Pow(a,x * 1.2f);
        return y;
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
