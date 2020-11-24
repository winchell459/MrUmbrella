using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

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
    float x, y;


    //public float drag;


    //public bool isSwitch;

    public bool isMove = true;

    public Transform Eyes;

    public AudioClip walk;
    
    public AudioSource PlayerAS;

    public bool isPoke;

    void Start()
    {
        extraJump = extraJumpValue;

        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isMove == true)
        {

            moveInput = Mathf.Clamp(xValue, -1, 1); //Input.GetAxis("Horizontal");


            if (!isPoke)
            {
                
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(transform.right.x * 10, rb.velocity.y);
            }
            

            if (facingRight == false && moveInput > 0)
            {
                Flip(0);
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip(1);
            }
        }

        
           

        //rb.drag = drag;
    }

    bool isPressed;
    private void Update()
    {
        //Debug.Log(isGrounded);

        InputHandler();
        if (EButtonDown)
        {
            isPressed = !isPressed;
            FindObjectOfType<AbPanelActive>().AbPanel.SetActive(isPressed);
        }
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
            animator.SetBool("isJumping", false);
        }

        
        if (jumpButtonDown && extraJump > 0)
        {

            rb.velocity = Vector2.up * jumpForce;
            extraJump--;



        }
        else if (jumpButton && extraJump == 0 && isGrounded == true)
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
        if(Mathf.Abs(rb.velocity.x) > 0)
        {
            PlayerAS.clip = walk;
            if (!PlayerAS.isPlaying) PlayerAS.Play();
        }
        else
        {
            PlayerAS.Stop();
        }


        
        

        Checkfall();

        if(FindObjectOfType<PlayerAttack>())
        {

            if (attack1ButtonDown && !FindObjectOfType<AbPanelActive>().OnHold)
            {
                FindObjectOfType<PlayerAttack>().MeleeAb(true);
                //rb.drag = drag;
            }
            else
            {
                FindObjectOfType<PlayerAttack>().MeleeAb(false);
                //rb.drag = 0;
            }
            if (attack2Button && !FindObjectOfType<AbPanelActive>().OnHold)
            {
                FindObjectOfType<PlayerAttack>().ProjectileAb();
            }
            else
            {
                FindObjectOfType<PlayerAttack>().animator.SetBool("isProtection", false);
                FindObjectOfType<PlayerAttack>().animator.SetBool("isFireBall", false);
            }
            if (attack3Button)
            {
                FindObjectOfType<PlayerAttack>().ProtectionAb(true);
            }
            else
            {
                FindObjectOfType<PlayerAttack>().ProtectionAb(false);
                //FindObjectOfType<PlayerAttack>().ProtectionPower = 1;
            }
            /*
            if (Input.GetKey(KeyCode.C))
            {
                FindObjectOfType<PlayerAttack>().ProjectileAb(false, true);
            }
            else
            {
                FindObjectOfType<PlayerAttack>().ProjectileAb(false, false);
            }
            */
            //FindObjectOfType<AbPanelActive>().OpenInventory();

        }

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


    bool xButton;
    bool xButtonDown;
    bool xButtonUp;
    float xValue;

    bool jumpButton;
    bool jumpButtonDown;
    bool jumpButtonUp;

    bool attack1Button;
    bool attack1ButtonDown;
    bool attack1ButtonUp;

    bool attack2Button;
    bool attack2ButtonDown;
    bool attack2ButtonUp;

    bool attack3Button;
    bool attack3ButtonDown;
    bool attack3ButtonUp;

    public bool EButton;
    public bool EButtonDown;
    public bool EButtonUp;

    public bool QButton;
    public bool QButtonDown;
    public bool QButtonUp;

    //on touchdown up do 1 (using bool) bullet at direction calculated using vector2.angle 

    void InputHandler()
    {
        xValue = TCKInput.GetAxis("Joystick").x;
        GetInput(Mathf.Abs(xValue) > 0, ref xButton, ref xButtonDown, ref xButtonUp);
        GetInput(Input.GetKey(KeyCode.Space) || TCKInput.GetAction("jumpBtn", EActionEvent.Down), ref jumpButton, ref jumpButtonDown, ref jumpButtonUp);
        GetInput(/*Input.GetMouseButton(0) || */TCKInput.GetAction("atc1btn", EActionEvent.Down), ref attack1Button, ref attack1ButtonDown, ref attack1ButtonUp);
        GetInput(TCKInput.GetAction("atc2btn", EActionEvent.Down), ref attack2Button, ref attack2ButtonDown, ref attack2ButtonUp);
        GetInput(TCKInput.GetAction("atc3btn", EActionEvent.Down), ref attack3Button, ref attack3ButtonDown, ref attack3ButtonUp);
        GetInput(TCKInput.GetAction("Ebtn", EActionEvent.Down), ref EButton, ref EButtonDown, ref EButtonUp);
        GetInput(TCKInput.GetAction("Qbtn", EActionEvent.Down), ref QButton, ref QButtonDown, ref QButtonUp);
    }

    void GetInput(bool input, ref bool button, ref bool buttonDown, ref bool buttonUp)
    {
        if (input)
        {
            if (!button)
            {
                buttonDown = true;
            }
            else
            {
               buttonDown = false;
            }
            button = true;
            buttonUp = false;
        }
        else
        {
            if (button)
            {
                buttonUp = true;
            }
            else
            {
                buttonUp = false;
            }
            button = false;
            buttonDown = false;
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
