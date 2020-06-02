using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;
    public float jumpForce = 350.0f;
    public float airDrag = 0.8f;

    private Rigidbody2D body;

    //Quaternion rotation;
    public Transform Self;

    public bool Grounded = true;

    public bool isJump = true;

    //public int Facing = 1;

    public bool isMove;

    public bool jump;


    public Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }



    private void FixedUpdate()
    {
        Move();

        Flip();

        if (isJump)
        {
            Jump();

            Fall();
        }
        MoveAnimation();

        JumpAnimation();

        //Debug.Log(Grounded);


    }

    private void Move()
    {
        float velocity = Input.GetAxis("Horizontal") * speed;

        //body.velocity = new Vector2(velocity, body.velocity.y);
        float F = (velocity - body.velocity.x) * body.mass / Time.deltaTime;
        body.AddForce(new Vector2(F, 0));

        if(Mathf.Abs(body.velocity.x) > 0)
        {
            isMove = true;
            //Debug.Log("yay");
        }
        if(Mathf.Abs(body.velocity.x) <= 0)
        {
            isMove = false;
        }
        //Debug.Log(isMove);
    }
    void MoveAnimation()
    {
        if(isMove)
        {
            animator.SetBool("isWalk", true);
        }
        if(!isMove)
        {
            animator.SetBool("isWalk", false);
        }
    }

    void Flip()
    {
        //Debug.Log(Mathf.RoundToInt(body.velocity.x));

        if (Input.GetAxis("Horizontal") > 0)
        {
            Self.eulerAngles = new Vector3(0, 0);


        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            Self.eulerAngles = new Vector3(0, 180);

        }

        /*
        if(Mathf.RoundToInt(body.velocity.x) == 0)
        {
            Self.Rotate(0f,0f,currentDegreeZ);
        }x
        */
    }
    void JumpAnimation()
    {
        if (jump)
        {
            animator.SetBool("isJumping", true);
        }
        if (!jump)
        {
            animator.SetBool("isJumping", false);
        }
        
    }
    void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);

            //Debug.Log("JOEEEe");
            jump = true;
        }
    }
    void Fall()
    {
        if (!Grounded)
        {
            jump = false;
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.transform.CompareTag("Ground"))
        {
            Grounded = false;
            Debug.Log("no");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.transform.CompareTag("Ground"))
        {
            Grounded = true;
            Debug.Log("Yes");
        }
    }

}
