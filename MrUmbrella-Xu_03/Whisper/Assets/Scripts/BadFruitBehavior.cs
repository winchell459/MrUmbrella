using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFruitBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float damage;

    public bool isFruit;

    public GameObject MK;

    public float MKProb;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFruit)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                
                Destroy(gameObject);
                bool isMK = Random.Range(0, 1f) < MKProb;
                if (isMK)
                {
                    Instantiate(MK, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }
                

            }
        }
        
        if (collision.transform.CompareTag("Player"))
        {
            Health pHealth = collision.gameObject.GetComponent<Health>();
            pHealth.TakeDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);

            


        }
        if (collision.transform.CompareTag("TC"))
        {
            if (collision.GetComponent<LinkTC>() != null)
            {
                collision.GetComponent<LinkTC>().LinkDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
            }
        }

       
    }
    

}
