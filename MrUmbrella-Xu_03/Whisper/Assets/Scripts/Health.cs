using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth ;
    //public bool isHeal;
    public string Inheritance;

    public GameObject particle;

    public bool isPlayerDead;




    

    private void Awake()
    {
        maxHealth = health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Die(Inheritance);
        }
    }
    public void Heal(float healAmount, GameObject medkit)
    {
        if(health < maxHealth)
        {
            health += healAmount;
            

            Instantiate(particle, transform.position, Quaternion.identity);

            //isHeal = true;

            
        }
        if(health + healAmount > 20)
        {
            health = maxHealth;
        }

        
        
    }
    
    public void RespawnPanel(GameObject Panel)
    {
        
        Panel.SetActive(true);
           

        
    }

    public void Die(string who)
    {

        if(who == "Player")
        {
            isPlayerDead = true;
            Destroy(gameObject);
        }
        if(who == "FarRangeEnemy")
        {
            FindObjectOfType<EnemyFire>().enabled = false;
            Destroy(FindObjectOfType<EnemyFire>().DestroyTheBullet);

            transform.parent.GetComponent<EnemyBehaviour>().EnemyDIE();
        }

        
    }
    private void Update()
    {
        
        if(health <= 0)
        {
            
        }
        
    }


}
