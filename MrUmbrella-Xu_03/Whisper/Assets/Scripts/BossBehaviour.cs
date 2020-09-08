using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    public float Speed1 = 2, Speed2 = 5;
    private float speed { get { return stageOne ? Speed1 : Speed2; } set {speed = value; } }
    private bool stageOne = true;
    private bool isTransition;
    public float AttackRadius = 5;
    public float Attack1Probability = 0.5f;
    public float AttackingCooldown = 1;
    private float lastAttack = Mathf.NegativeInfinity; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        if(xDistance(transform, player) < AttackRadius && AttackingCooldown + lastAttack < Time.fixedTime)
        {
            lastAttack = Time.fixedTime;
            bool attack1 = Random.Range(0, 1f) < Attack1Probability;
            if (attack1) Attack1Transition();
            else Attack2Transition();
        }

        
    }
    private void FixedUpdate()
    {
        if (!isTransition)
        {
            if (player && rb)
            {
                if (xDistance(transform,  player) > 0.5f) rb.velocity = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x) * speed, 0);
                else { rb.velocity = Vector2.zero; }
            }
            else
            {
                rb = GetComponent<Rigidbody2D>(); player = FindObjectOfType<PlayerController>().transform;
            }
                
        } 
        else
        {
            
        }

       
        
    }

    public void Attack1()
    {
        
    }
    public void Attack2()
    {

    }
    public void Attack1Transition()
    {
        Debug.Log("1 transtion");
        //call anim atak 1
    }
    public void Attack2Transition()
    {
        Debug.Log("2 transtion");
        //call anim atak 2
    }

    private float xDistance(Transform apple, Transform banana)
    {
        return Mathf.Abs(apple.position.x - banana.position.x);
    }


}
