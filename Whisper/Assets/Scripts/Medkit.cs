using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();



            playerHealth.Heal(healAmount, gameObject);

            
            
        }
    }
}
