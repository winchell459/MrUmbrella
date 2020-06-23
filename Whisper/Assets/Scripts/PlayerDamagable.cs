using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : MonoBehaviour
{
    public float OwnHealth;

    private float MaxHealth;

    public GameObject Self;

    public bool isDamagedOnce;

    public bool isDamagePlayer;

    private void Start()
    {
        OwnHealth = GetComponent<Health>().health;

        MaxHealth = OwnHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemyWeapon"))
        {
            if (collision.TryGetComponent(out WeaponProperty wp))
            {
                if (isDamagedOnce == false)
                {
                    OwnHealth = OwnHealth - wp.damage;
                    FindObjectOfType<TimeManager>().SlowDown();
                    
                    isDamagedOnce = true;
                    
                }
                
                FindObjectOfType<EnemyFire>().animator.SetBool("isAttack", false);
                Destroy(collision.gameObject);

            }
            else
            {
                Debug.Log("plz attach damage to enemy weapon");
            }
        }
    }

    private void Checkdeath()
    {
        if(OwnHealth <= 0)
        {
            if(FindObjectOfType<EnemyFire>().isPlayerDead == false)
            {
                Debug.Log("You ded");
                FindObjectOfType<EnemyFire>().isPlayerDead = true;
                OwnHealth = MaxHealth;


                Destroy(Self);
            }
            

            
        }
    }

    private void Update()
    {
        Checkdeath();
    }
}
