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

    void Start()
    {

    }
    
    

    public void MeleeAb(bool isLeftClick)
	{
		if (isLeftClick)
		{
			animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
		
        
		
	}
    public void ProjectileAb(bool isRightClick, bool isPressC)
    {
        if (isRightClick == true)
        {
            animator.SetBool("isProtection", true);
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



    void Update()
    {
        

        

    }
}
