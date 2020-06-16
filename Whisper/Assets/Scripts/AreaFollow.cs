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
            FindObjectOfType<Follow>().SetBounds(GetComponent<BoxCollider2D>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
        }
    }
}
    