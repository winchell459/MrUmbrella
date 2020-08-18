using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : SpawnObjects
{
    public float healAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            DespawnObjects();


            playerHealth.Heal(healAmount);

            Destroy(gameObject);

            //Debug.Log(Mathf.RoundToInt(playerHealth.maxHealth));
                
        }
    }
}
