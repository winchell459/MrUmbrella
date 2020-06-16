using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagable : MonoBehaviour
{
    public float OwnHealth;

    private float MaxHealth;

    public GameObject Self;

    private void Start()
    {
        OwnHealth = GetComponent<Health>().health;

        MaxHealth = OwnHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemyWeapon"))
        {
            if (collision.TryGetComponent(out WeaponProperty wp))
            {
                OwnHealth = OwnHealth - wp.damage;
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("plz attach damage to enemy weapon");
            }
        }
    }

    private void death()
    {
        if(OwnHealth <= 0)
        {
            Debug.Log("You ded");

            Destroy(Self);

            FindObjectOfType<EnemyBehavior>().isPlayerDead = true;

            OwnHealth = MaxHealth;

        }
    }

    private void Update()
    {
        death();
    }
}
