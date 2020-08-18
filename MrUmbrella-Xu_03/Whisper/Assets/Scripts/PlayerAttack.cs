﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool attacking;

    public Transform fireBallfirePoint;
    public Transform BulletFirepoint;
    public GameObject bulletPrefab;
    public GameObject smallBulletPrefab;
    public GameObject FireBall;

    public float maxTurn;
    public float minTurn;
    public float ZAngle;

    public Transform attackPoint;
    public MeleeProperty MP;
    public float AttackRange;
    public LayerMask enemyLayers;

    public float Damage;

    public float AttackRate; //how many times per sec
    public float MeleeNextAttackTime;

    public float FireRate;
    private float RangeNextAttackTime;

    public float ProtectionRate;
    private float ProtectionNextAttackTime;

    public float Duration;
    //public float ProtectionCD;
    public float ProtectionPower = 1;

    AbilityRange ar;
    AbilityMelee am;
    AbilityProtection apr;

    PlayerHandler PH;

    //Bullet bullet;
    bool isFireSingBullet;

    public float healFactor = 10;

    public GameObject[] smallBulletFirePoints;


    public Bullet[] smallBullets;




    //public Animator CamAnim;

    void Start()
    {
        MP = GetComponent<MeleeProperty>();
        
        UpdateMeleeAbilities();

        //CamAnim = Camera.main.transform.parent.GetComponent<Animator>();
        
    }
    
    

    public void MeleeAb(bool isLeftClick)
	{
        if(Time.time >= MeleeNextAttackTime)
        {
            if (isLeftClick)
            {
                
                UpdateMeleeAbilities();
                if (!PH) PH = FindObjectOfType<PlayerHandler>();
                am = PH.Melee;
                if(am.MeleeType == AbilityMelee.MeleeTypes.Swing)
                {
                    animator.SetBool("isAttacking", true);
                   

                }
                else if(am.MeleeType == AbilityMelee.MeleeTypes.Poke)
                {
                    animator.SetBool("isPoke", true);
                    
                }
                else if (am.MeleeType == AbilityMelee.MeleeTypes.Smash)
                {
                    animator.SetBool("isSmash", true);
                  
                }



                //Attack();


                //CamAnim.SetBool("isShake", true);
                MeleeNextAttackTime = Time.time + AttackRate;

            }
            //set to false
            
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isPoke", false);
            animator.SetBool("isSmash", false);


        }




    }
    public void ProtectionAb(bool isPressC)
    {
        if(Time.time >= ProtectionNextAttackTime)
        {
            if (isPressC)
            {
                UpdateProtectionAbilities();
                if (!PH) PH = FindObjectOfType<PlayerHandler>();
                apr = PH.Protection;
                if(apr.ProtectionType == AbilityProtection.ProtectionTypes.Shield)
                {
                    animator.SetBool("isShield", true);
                    ProtectionPower = PH.Protection.Power;
                }
                else if (apr.ProtectionType == AbilityProtection.ProtectionTypes.Invinc)
                {
                    animator.SetTrigger("isInvinc");
                    

                }
                else if (apr.ProtectionType == AbilityProtection.ProtectionTypes.Healing && transform.parent.gameObject.GetComponent<Health>().health <= 20)
                {
                    ProtectionPower = PH.Protection.Power;
                    transform.parent.gameObject.GetComponent<Health>().Heal(ProtectionPower * healFactor);
                    //FindObjectOfType<LinkTC>().LinkDamage(-ProtectionPower);
                }
                ProtectionNextAttackTime = Time.time + ProtectionRate;
                
                Debug.Log(ProtectionPower);

            }
            else
            {
                animator.SetBool("isShield", false);
                //animator.SetBool("isInvinc", false);
                
                Debug.Log(ProtectionPower);

            }


        }
        
        

    }
    
    
    
    public void ProjectileAb()
    {
        if (Time.time >= RangeNextAttackTime)
        {
            if (!PH) PH = FindObjectOfType<PlayerHandler>();
            ar = PH.Range;
            if (ar.RangeType == AbilityRange.RangeTypes.Bullet)
            {
                //InstantiateSingularBullet();
                animator.SetBool("isProtection", true);
                Bullet bullet = Instantiate(bulletPrefab, BulletFirepoint.position, BulletFirepoint.rotation).GetComponent<Bullet>();
                bullet.PP.damage = ar.Power;
                bullet.PP.speed = ar.speed;
                FireRate = ar.CD;
                bullet.Setup();
                //isFireSingBullet = false;

            }
            else if (ar.RangeType == AbilityRange.RangeTypes.Fireball)
            {
                animator.SetBool("isFireBall", true);
            }
            else if (ar.RangeType == AbilityRange.RangeTypes.SmallBullet)
            {
                animator.SetTrigger("isSmallBullet");
                for(int i = 0; i < 3; i += 1)
                {
                    smallBullets[i] = Instantiate(smallBulletPrefab, smallBulletFirePoints[i].transform.position, smallBulletFirePoints[i].transform.rotation).GetComponent<Bullet>();
                    
                    smallBullets[i].PP.damage = ar.Power;
                    smallBullets[i].PP.speed = ar.speed;
                    FireRate = ar.CD;
                    smallBullets[i].Setup();
                }
               
                

            }
            RangeNextAttackTime = Time.time + FireRate;
        }
        
        
        
    }
    
    

    public void FireballInstantiate()
    {
        //AbilityRange ar = (AbilityRange)FindObjectOfType<AbilityUI>().Range;
        ZAngle = Random.Range(minTurn, maxTurn);
        Bullet fireball = Instantiate(FireBall, fireBallfirePoint.transform.position, Quaternion.Euler(new Vector3(0,0,ZAngle))).GetComponent<Bullet>();
        ProjectileProperty pp = fireball.GetComponent<ProjectileProperty>();
        pp.speed = ar.speed;
        pp.damage = ar.Power;
        FireRate = ar.CD;
        fireball.Setup();
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Health>().TakeDamage(Damage);
            
        }
    }

    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Invincibility") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Shield"))
        {
            ProtectionPower = 1;
        }
        else
        {
            ProtectionPower = PH.Protection.Power;
        }

        
    }
    private void UpdateMeleeAbilities()
    {
        PlayerHandler abUi = FindObjectOfType<PlayerHandler>();
        AttackRange = abUi.Melee.Radius;
        Damage = abUi.Melee.Power;
        AttackRate = abUi.Melee.CD;
    }
    private void UpdateRangeAbilities()
    {

    }

    public void InstantiateParticles(GameObject ptxs)
    {
        Instantiate(ptxs, attackPoint.position, Quaternion.identity);
    }
    private void UpdateProtectionAbilities()
    {
        PlayerHandler abUI = FindObjectOfType<PlayerHandler>();
        ProtectionRate = abUI.Protection.CD;
        
        
    }
}