﻿using System.Collections;
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

    public bool isBossDead;

    bool isCallAnim = false;

    public AudioSource HurtAS;
    public AudioClip HurtAC;
    public AudioClip DeathAC;

    public GameObject DeathParticle;

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
        HurtAS.clip = HurtAC;
        if(!HurtAS.isPlaying) HurtAS.Play();

        if(Inheritance == "Player")
        {
            FindObjectOfType<PlayerHealthBar>().transform.parent.gameObject.GetComponent<Animator>().SetTrigger("isHurt");
        }



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
            if (FindObjectOfType<RespawnAltar>())
            {
                if(!FindObjectOfType<RespawnAltar>().RAS.clip) FindObjectOfType<RespawnAltar>().RAS.clip = FindObjectOfType<RespawnAltar>().death;
                if (!FindObjectOfType<RespawnAltar>().RAS.isPlaying) FindObjectOfType<RespawnAltar>().RAS.Play();
            }
            else if (FindObjectOfType<RespawnNoAltar>())
            {
                if (!FindObjectOfType<RespawnNoAltar>().RAS.clip) FindObjectOfType<RespawnNoAltar>().RAS.clip = FindObjectOfType<RespawnNoAltar>().death;
                if (!FindObjectOfType<RespawnNoAltar>().RAS.isPlaying) FindObjectOfType<RespawnNoAltar>().RAS.Play();
            }
            else
            {
                Debug.Log("y u no have altar bro");
            }
            GameObject Instance = Instantiate(DeathParticle, transform.position, Quaternion.identity);
            Destroy(Instance, 3);
            Destroy(gameObject);
        }
        if(who == "FarRangeEnemy")
        {
            FindObjectOfType<EnemyFire>().enabled = false;
            Destroy(FindObjectOfType<EnemyFire>().DestroyTheBullet);
            Camera.main.gameObject.GetComponent<Follow>().ShakeCamera();
            GameObject Instance = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(Instance, 3);
            transform.parent.GetComponent<EnemyBehaviour>().EnemyDIE();
        }
        if(who == "CloseRangeEnemy")
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            transform.parent.GetChild(1).GetComponent<HealthBar>().SetBarStateOff(true);
            Camera.main.gameObject.GetComponent<Follow>().ShakeCamera();
            transform.parent.GetComponent<EnemyBehaviour>().EnemyDIE();
            GameObject Instance = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(Instance, 3);
        }
        if(who == "Destroyables")
        {
            Destroy(gameObject);
        }
        if(who == "Boss")
        {
            

            if (!isCallAnim)
            {
                gameObject.GetComponent<BossBehaviour>().anim.SetTrigger("isDead");
                isCallAnim = true;
            }
                
            isBossDead = true;
            HurtAS.clip = DeathAC;
            HurtAS.Play();
            Invoke("BossDie", 4.25f);
        }
        
    }
    private void Update()
    {
        
        if(health <= 0)
        {
            
        }
        
    }

    void BossDie()
    {
        transform.GetChild(10).parent = null;

        Destroy(gameObject);
    }


}
