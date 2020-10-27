using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E03Behavior : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<EnemyBehaviour>().MyOnTriggerExit2D(collision);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<EnemyBehaviour>().MyOnTriggerEnter2D(collision);
    }
}
