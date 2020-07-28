using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool attacking;

    public Transform firepoint;
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

    void Start()
    {
        MP = GetComponent<MeleeProperty>();
        AttackRate = MP.CD;
    }
    
    

    public void MeleeAb(bool isLeftClick)
	{
        if(Time.time >= nextAttackTime)
        {
            if (isLeftClick)
            {
                animator.SetBool("isAttacking", true);
                Attack();
                nextAttackTime = Time.time + 1 / AttackRate;

            }
            else
            {
                animator.SetBool("isAttacking", false);

            }
        }
		
		
        
		
	}
    public void ProjectileAb(bool isRightClick, bool isPressC)
    {
        if (isRightClick == true)
        {
            animator.SetBool("isProtection", true);
<<<<<<< HEAD
            bullet.PP.damage = ar.Power;
            bullet.PP.speed = ar.speed;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            bullet.Setup();
=======

>>>>>>> parent of 84896c54... 7.29.20
=======
            Debug.Log(ar.Power);
=======
>>>>>>> parent of 84896c54... 7.29.20

>>>>>>> parent of d24a37cc... Merge branch 'Xu_02' into Xu_01
=======
>>>>>>> parent of 9a59568e... 7.28.20.afterclass
        }
        else if (isPressC)
        {
            animator.SetBool("isFireBall", true);
            animator.SetBool("isProtection", false);

        }
        else
        {
            animator.SetBool("isProtection", false);
            animator.SetBool("isFireBall", false);
        }
    }

    public void FireballInstantiate()
    {
        ZAngle = Random.Range(minTurn, maxTurn);
        Instantiate(FireBall, firepoint.transform.position, Quaternion.Euler(new Vector3(0,0,ZAngle)));
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

        AttackRange = MP.swingSize;
        Damage = MP.Damage;
        

}
}
