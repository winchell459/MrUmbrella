using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagable : MonoBehaviour
{
    public bool isEnemyDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isEnemyDamage = true;
        }
        
    }
}
