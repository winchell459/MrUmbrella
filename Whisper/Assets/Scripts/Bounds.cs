using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player bounded");
            FindObjectOfType<CameraFollow>().SetBounds(GetComponent<BoxCollider2D>());
        }
    }
}
