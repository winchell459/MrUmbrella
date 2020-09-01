using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    //public bool isHeal;
    public string Inheritance;

    public GameObject particle;

    public bool isPlayerDead;

    public GameObject DamageShow;




    

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

        GameObject Instance = Instantiate(DamageShow, new Vector3(transform.position.x + Random.Range(-1,1), transform.position.y + Random.Range(-1, 1)), Quaternion.identity);

        Instance.transform.GetChild(0).gameObject.GetComponent<Text>().text = damage.ToString();

        Destroy(Instance, 0.5f);

        if (health <= 0)
        {
            Die(Inheritance);
        }


    }
    public void Heal(float healAmount)
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
        if(who == "CloseRangeEnemy")
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            transform.parent.GetChild(1).GetComponent<HealthBar>().SetBarStateOff(true);
        }
        if(who == "Destroyables")
        {
            Destroy(gameObject);
        }

        
    }
    private void Update()
    {
        
        if(health <= 0)
        {
            
        }
        
    }


}
