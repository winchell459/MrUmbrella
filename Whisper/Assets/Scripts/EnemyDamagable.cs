using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagable : MonoBehaviour
{

    public GameObject Self;
    //public EnemyFire Fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Weapon"))
        {
            Destroy(FindObjectOfType<EnemyFire>().DestroyTheBullet);
            

            Destroy(Self);

            
            //Fire.enabled = false;

            Debug.Log("YES");
        }
    }
}
