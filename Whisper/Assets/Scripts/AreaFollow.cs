using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFollow : MonoBehaviour
{
    public Vector2 MoveDistance;
    public Transform Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(MoveDistance.x, MoveDistance.y);
            FindObjectOfType<Follow>().specialCase = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Camera.transform.position = Camera.transform.position + new Vector3(-MoveDistance.x, -MoveDistance.y);
            FindObjectOfType<Follow>().specialCase = false;
        }
    }
}
    