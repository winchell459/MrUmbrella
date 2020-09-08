using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    public float Speed1 = 2, Speed2 = 5;
    private float speed { get { return stageOne ? Speed1 : Speed2; } set { speed = value; } }
    private bool stageOne = true;
    private bool isTransition;
    public float AttackRadius = 5;
    public float Attack1Probability = 0.5f; //Attack2Probability = 1 - Attack1Probability
    public float AttackingCooldown = 1;
    private float lastAttack = Mathf.NegativeInfinity;

    //attack 1 happens when close to player
    //attack 2 happens every 10 seconds
    //attack 2 will not happen if player is close enough for attack 1

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
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
                if (xDistance(transform, player) > 0.5f) rb.velocity = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x) * speed, 0);
                else { rb.velocity = Vector2.zero; }
            }
            else { rb = GetComponent<Rigidbody2D>(); player = FindObjectOfType<PlayerController>().transform; }

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
        Debug.Log("Attack1Transition! " + Time.fixedTime);
        //call animator attack1Transition
    }

    public void Attack2Transition()
    {
        Debug.Log("Attack2Transition! " + Time.fixedTime);
        //call animator attack2Transition
    }

    private float xDistance(Transform apple, Transform banana)
    {
        return Mathf.Abs(apple.position.x - banana.position.x);
    }
}
