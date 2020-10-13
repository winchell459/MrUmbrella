using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    public float Speed1 = 2, Speed2 = 5;
    private float speed { get { return stageOne ? Speed1 : Speed2; } set {speed = value; } }
    public bool stageOne = true;
    private bool isTransition;
    public float AttackRadius = 5;
    public float Attack1Probability = 0.5f;
    public float AttackingCooldown = 2;
    private float lastAttack = Mathf.NegativeInfinity;
    public Animator anim;

    public Health selfHealth;

    public Transform P1_0, P1_1, P2_0, P2_1;
    public float Attack2Speed1 = 1, Attack2Speed2  = 2;
    public float Attack2Speed { get { return stageOne ? Attack2Speed1 : Attack2Speed2; } set {Attack2Speed2 = value; } }
    public float Attack2Length = 1;

    public GameObject BadFruitPrefab;

    public BadFruitBehavior[] bfb;

    public float Stage2PillarDamage = 2;
    public float Stage2Attack2Damage = 5;

    public AudioSource BossAs;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;

        
    }

    
    void Update()
    {
        if (!FindObjectOfType<PlayerDeadManager>().isPlayerDied)
        {
            if (xDistance(transform, player) < AttackRadius && AttackingCooldown + lastAttack < Time.fixedTime)
            {
                lastAttack = Time.fixedTime;
                bool attack1 = Random.Range(0, 1f) < Attack1Probability;
                if (attack1) Attack1Transition();
                else Attack2Transition();
            }

        }

        if(selfHealth.health <= selfHealth.maxHealth / 2 && stageOne)
        {
            stageOne = false;
            anim.SetBool("isStage2", true);
            Debug.Log("stagedos");
            foreach (BadFruitBehavior fruit in bfb)
            {
                fruit.damage = Stage2PillarDamage;
            }
        }


        //FindObjectOfType<BadFruitBehavior>().isFruitShouter = true;

    }
    private void FixedUpdate()
    {



        if (!isTransition)
        {
            if (player && rb)
            {


                if (xDistance(transform, player) > 0.5f) rb.velocity = new Vector2(Mathf.Sign(player.transform.position.x - transform.position.x) * speed, 0);
                else { rb.velocity = Vector2.zero; }
                //Debug.Log("ismoinvg");


            }
            else if (!FindObjectOfType<PlayerDeadManager>().isPlayerDied)
            {
                rb = GetComponent<Rigidbody2D>();
                player = FindObjectOfType<PlayerController>().transform;
            }

        }
        else
        {

        }
        

       
        
    }

    
    public void Attack1Transition()
    {
        anim.SetTrigger("isAttack1");
        Debug.Log("1");
        //call anim atak 1
    }
    public void Attack2Transition()
    {
        anim.SetTrigger("isAttack2");
        Debug.Log("2");
    }

    private float xDistance(Transform apple, Transform banana)
    {
        return Mathf.Abs(apple.position.x - banana.position.x);
    }

    public void BossShakeCamera()
    {
        Camera.main.gameObject.GetComponent<Follow>().ShakeCamera();
    }

    public void PlaySound(AudioClip ThisClip)
    {
        BossAs.clip = ThisClip;
        BossAs.Play();
    }

    


}
