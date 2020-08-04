using UnityEngine;
using System.Collections;

public class WeaponFollow : MonoBehaviour
{
    //public GameObject Guy;

    //Child of Player
    public GameObject target;        //Public variable to store a reference to the player game object

    public Transform Player;

    public Vector3 offset;            //Private variable to store the offset distance between the player and camera

    //public Animator anim;

    public Vector2 smooth;

    private Vector2 OrPosition;

    public Vector3 OrTargetPos;

    float x;
    float y;


    // Use this for initialization
    void Start()
    {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        OrPosition = transform.position;


        x = transform.position.x;
        y = transform.position.y;

    }
    private void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false || target != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.GetChild(7).gameObject;
            Player = GameObject.FindGameObjectWithTag("Player").transform;

            if (Player.transform.rotation == Quaternion.identity)
            {
                OrTargetPos = target.transform.position;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Player.transform.rotation != Quaternion.identity && transform.position.x >= x)
            {
                OrTargetPos = target.transform.position;

                transform.rotation = new Quaternion(0, 180, 0, 0);

            }
        }
        
        
    }

    // LateUpdate is called after Update each frame

    void LateUpdate()
    {

        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false || Player != null)
        {
            

            x = Mathf.Lerp(x, OrTargetPos.x, smooth.x * Time.deltaTime);
            y = Mathf.Lerp(y, target.transform.position.y, smooth.y * Time.deltaTime);


            //x = Mathf.Clamp(x, OrPosition.x, );

            transform.position = new Vector3(x, y, transform.position.z);

            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position + offset, step);

            //Debug.Log(step);
        }
            

    }

    public void ShowSwitchWeapon()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void UnShowSwitchWeapon()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}