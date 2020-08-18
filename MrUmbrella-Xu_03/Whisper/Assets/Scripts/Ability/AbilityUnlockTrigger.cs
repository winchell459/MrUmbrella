﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlockTrigger : MonoBehaviour
{
    public AbilityObject ao;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHandler>().AbilityUnlock(ao);
            Destroy(gameObject);
        }
        
    }
}
