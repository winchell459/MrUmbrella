using System.Collections;
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
    private float nextAttackTime;

    AbilityRange ar;

    void Start()
    {
        MP = GetComponent<MeleeProperty>();
        
        UpdateMeleeAbilities();
    }
    
    

    public void MeleeAb(bool isLeftClick)
	{
        if(Time.time >= nextAttackTime)
        {
            if (isLeftClick)
            {
                UpdateMeleeAbilities();
                animator.SetBool("isAttacking", true);
                Attack();
                nextAttackTime = Time.time + 1 / AttackRate;

            }
            
        }
        else
        {
            animator.SetBool("isAttacking", false);

        }




    }
    public void ProjectileAb()
    {
        
        ar = (AbilityRange)FindObjectOfType<PlayerHandler>().Range;
        if(ar.RangeType == AbilityRange.RangeTypes.Bullet)
        {
            Bullet bullet = Instantiate(bulletPrefab, BulletFirepoint.position, BulletFirepoint.rotation).GetComponent<Bullet>();
            animator.SetBool("isProtection", true);
            bullet.PP.damage = ar.Power;
            bullet.PP.speed = ar.speed;
<<<<<<< HEAD
            bullet.Setup();
=======

>>>>>>> parent of 84896c54... 7.29.20
        }
        else if(ar.RangeType == AbilityRange.RangeTypes.Fireball)
        {
            animator.SetBool("isFireBall", true);
        }
        else if(ar.RangeType == AbilityRange.RangeTypes.SmallBullet)
        {

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
        fireball.Setup();
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
    }

    void Update()
    {
        


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
}
