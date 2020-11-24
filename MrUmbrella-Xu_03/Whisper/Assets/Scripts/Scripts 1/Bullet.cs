using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ProjectileProperty PP;
	public Rigidbody2D rb;
	public GameObject impactEffect;
    private Vector3 SMcurpos;
    private Vector3 SBcurpos;

    public float SmallBulletMaxDistance = 2.5f;

    public GameObject Player;

    public GameObject FirePrefab;

    /*
    public float ClosestEnemyX;

    public float[] distances;

    float thisDistance;

    float minDistance = float.MaxValue;
    */

    public GameObject AT2JoyS;

    public enum BulletFireTypes
    {
        SingBullet,
        Fireball,
        SmallBullet
    }

    
    public BulletFireTypes bulletFireType;

    public List<Transform> theEnemies;
    public int offset;
    public Vector2 rangeOfOffset;


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

            /*
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (target - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * PP.speed, direction.y * PP.speed);

            rb.velocity = new Vector2(FindObjectOfType<PlayerAttack>().pointpoint.x * PP.speed, FindObjectOfType<PlayerAttack>().pointpoint.y * PP.speed);

            SBcurpos = transform.position;

            */


            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    theEnemies.Add(e.transform);
                }
                rangeOfOffset.x = (float)SMDamageLine(1, Vector2.Distance(transform.position, GetClosestEnemy(theEnemies).position), 0);
                rangeOfOffset.x = (float)SMDamageLine(1, Vector2.Distance(transform.position, GetClosestEnemy(theEnemies).position), 0.5f);

                offset = (int)Random.Range(rangeOfOffset.x, rangeOfOffset.x);

                Vector2 direction = (GetClosestEnemy(theEnemies).position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * PP.speed + offset, direction.y * PP.speed);


                SBcurpos = transform.position;
            }
           
            

        }
        else if(bulletFireType == BulletFireTypes.SmallBullet)
        {
            //Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 direction = (target - transform.position).normalized;
            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    theEnemies.Add(e.transform);
                }
                Vector2 direction = (GetClosestEnemy(theEnemies).position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * PP.speed + offset, direction.y * PP.speed);




                SMcurpos = transform.position;
            }
            
        }
        
	}
    private void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false) Player = FindObjectOfType<PlayerDeadManager>().playerGO;

    }

    private void FixedUpdate()
    {

        if (bulletFireType == BulletFireTypes.SingBullet)
        {
            transform.right = rb.velocity;
            
            PP.damage = Mathf.Clamp(SBDamageLine(1.2f, Mathf.Abs(SBcurpos.x - transform.position.x)), 0, 7f) + Mathf.Clamp(SBDamageLine(0.5f, Mathf.Abs(SBcurpos.y - transform.position.y)), 0, 2);

            //Debug.Log(PP.damage);
        }
        
        if (bulletFireType == BulletFireTypes.SmallBullet)
        {
            
            if (Mathf.Abs(SMcurpos.x - transform.position.x) > SmallBulletMaxDistance || Mathf.Abs(SMcurpos.y - transform.position.y) > SmallBulletMaxDistance)
            {
                Destroy(gameObject);
            }
            /*
            if (FindObjectOfType<EnemyBehaviour>())
            {
                for (int i = 0; i < FindObjectsOfType<EnemyBehaviour>().Length; i = i + 1)
                {
                    if (Player) distances[i] = Player.transform.position.x - FindObjectsOfType<EnemyBehaviour>()[i].gameObject.transform.position.x;
                }

                for (int i = 0; i < distances.Length; i = i + 1)
                {
                    distances[i] = thisDistance;

                    if (thisDistance < minDistance)
                    {
                        minDistance = thisDistance;
                        ClosestEnemyX = distances[i];
                    }
                }
             
        }
        */


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
            if (bulletFireType == BulletFireTypes.Fireball)
            {
                GameObject instance;
                instance = Instantiate(FirePrefab, transform.position, Quaternion.Inverse(transform.rotation));
                instance.GetComponent<Bullet>().Setup();
            }
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
    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

}
