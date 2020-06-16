using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    public float Smooth;
    public float yValue;
    private Vector3 offset;

    public Vector3 SetOffset;

    public bool specialCase;

    private Vector3 AreaPosDifference;

    private void Start()
    {
        offset = SetOffset;
        AreaPosDifference = FindObjectOfType<AreaFollow>().MoveDistance;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    // Use this for initialization
   
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (!specialCase)
        {
            transform.position = new Vector3(player.transform.position.x * Smooth, yValue, 0) + offset;
        }
        if (specialCase)
        {
            transform.position = new Vector3(player.transform.position.x * Smooth, player.transform.position.y, -10) + new Vector3(AreaPosDifference.x, AreaPosDifference.y);
        }

    }
}