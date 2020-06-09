using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    public Vector2 Smooth;
    public Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 0.92f, -10);
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    // Use this for initialization
   
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(player.transform.position.x * Smooth.x, -0.62f, 0) + offset;

        Debug.Log(new Vector3(player.transform.position.x * Smooth.x, 0, 0) + offset);

    }
}