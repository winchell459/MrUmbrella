using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;
    public float jumpForce = 350.0f;
    private float moveInput;

    private Rigidbody2D rb;


    public Animator animator;

    
    public GameObject Umbrella;

    public int jumpTimes;

    public bool isStopAdd;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool facingRight = true;


    public int extraJumpValue;
    public int extraJump;

    //private bool isMove;
    private bool isJump;

    public Transform DJPoint;


    //public bool isSwitch;

    void Start()
    {
        extraJump = extraJumpValue;

        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip(0);
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip(1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, checkRadius);
    }

    private void Update()
    {
        //Debug.Log(isGrounded);

        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {

            rb.velocity = Vector2.up * jumpForce;
            extraJump--;



        }
        else if (Input.GetKey(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;



            //animator.SetBool("takeOff", true);

        }

        /*
        if (rb.velocity.y > 0 && extraJump > 0)
        {
            animator.SetBool("isJumping", true);
        }
        else if (transform.position.y > DJPoint.position.y)
        {
            animator.SetBool("isDoubleJump", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", false);
        }

        */
        if (rb.velocity.y >= jumpForce)
        {

            if (isStopAdd == false)
            {
                jumpTimes = jumpTimes + 1;

                if (jumpTimes >= 2)
                {
                    isStopAdd = true;
                }
            }

            if (jumpTimes == 1)
            {
                animator.SetBool("isJumping", true);
            }
            if (jumpTimes == 2)
            {
                animator.SetBool("isDoubleJump", true);
            }
        }


        
        

        Checkfall();

        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<PlayerAttack>().MeleeAb(true);
        }
        else
        {
            FindObjectOfType<PlayerAttack>().MeleeAb(false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(true, false);
        }
        else
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(false, false);
        }
        if (Input.GetKey(KeyCode.C))
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(false, true);
        }
        else
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(false, false);
        }

        FindObjectOfType<AbPanelActive>().OpenInventory();

        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            animator.SetBool("isWalk", true);
        }
        if (Mathf.Round(Mathf.Abs(rb.velocity.x)) <= 0)
        {
            animator.SetBool("isWalk", false);
        }

        

    }

    void Flip(int right)
    {
        facingRight = !facingRight;

        transform.eulerAngles = new Vector3(0, right * 180);
        
    }

    void Checkfall()
    {
        if(isGrounded == false)
        {
            animator.SetBool("isJumping", false);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            jumpTimes = 0;

            isStopAdd = false;

            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", false);
        }
    }






    /*

    private void Update()
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

        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<PlayerAttack>().MeleeAb(true);
        }
        else
        {
            FindObjectOfType<PlayerAttack>().MeleeAb(false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(true);
        }
        else
        {
            FindObjectOfType<PlayerAttack>().ProjectileAb(false);
        }

        FindObjectOfType<AbPanelActive>().OpenInventory();


    }

    

    private void Move()
    {
        float velocity = Input.GetAxis("Horizontal") * speed;

        body.velocity = new Vector2(velocity, body.velocity.y);

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

        !!!
        if(Mathf.RoundToInt(body.velocity.x) == 0)
        {
            Self.Rotate(0f,0f,currentDegreeZ);
        }
        !!!
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
            //Debug.Log("no");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.transform.CompareTag("Ground"))
        {
            Grounded = true;
            //Debug.Log("Yes");
        }
    }

*/

}
