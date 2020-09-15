using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFruitBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float damage;

    public bool isFruit;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFruit)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
        }
        
        if (collision.transform.CompareTag("Player"))
        {
            Health pHealth = collision.gameObject.GetComponent<Health>();
            pHealth.TakeDamage(damage);

            
        }
    }
    

}
