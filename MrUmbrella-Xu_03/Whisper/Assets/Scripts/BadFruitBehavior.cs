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

    public GameObject BFShout;
    private AudioSource FruitAS;
    public AudioClip smashclip;



    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("FruitShouter")) BFShout = GameObject.FindGameObjectWithTag("FruitShouter");
        FruitAS = BFShout.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFruit)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                FruitAS.clip = smashclip;
                FruitAS.Play();
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
                Camera.main.gameObject.GetComponent<Follow>().ShakeCamera();






            }
        }
        
        if (collision.transform.CompareTag("Player"))
        {

            Health pHealth = collision.gameObject.GetComponent<Health>();
            if (pHealth)
            {
                pHealth.TakeDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
            }
            
            

            


        }
        if (collision.transform.CompareTag("TC"))
        {
            if (!FindObjectOfType<PlayerDeadManager>().isPlayerDied)
            {
                if (collision.GetComponent<LinkTC>() != null)
                {
                    collision.GetComponent<LinkTC>().LinkDamage(damage * FindObjectOfType<PlayerAttack>().ProtectionPower);
                }
            }
            
        }

       
    }
    

}
