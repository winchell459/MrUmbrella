using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool attacking;
    

    void Start()
    {

    }
    

    void isAttack()
    {
        if (Input.GetKey(KeyCode.J))
        {
            attacking = true;
            animator.SetBool("isAttacking", attacking);
            Debug.Log(attacking);
            
        }
        if (!Input.GetKey(KeyCode.J))
        {
            attacking = false;
            animator.SetBool("isAttacking", attacking);
        }
        if (Input.GetKey(KeyCode.K))
        {
            animator.SetBool("isProtection", true);

        }
        if (!Input.GetKey(KeyCode.K))
        {
            animator.SetBool("isProtection", false);
        }
        

    }

   public void ActiveWaterRay()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    

    void Update()
    {
        isAttack();
        

    }
}
