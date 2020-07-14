using UnityEngine;
using System.Collections;

public class WeaponFollow : MonoBehaviour
{
    //public GameObject Guy;

    public GameObject target;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera


    private float xvalue;
    //public Animator anim;

    // Use this for initialization
    void Start()
    {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - target.transform.position;

        

    }
    private void Update()
    {
        if (FindObjectOfType<EnemyFire>().isPlayerDead == false || target != null) target = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called after Update each frame

    void LateUpdate()
    {

        if (FindObjectOfType<EnemyFire>().isPlayerDead == false || target != null)
        {
            xvalue = target.transform.position.x;
            transform.position = new Vector3(xvalue, transform.position.y);
        }
            


       
        
        


        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        



    }
}