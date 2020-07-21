using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTC : MonoBehaviour
{

    public WeaponFollow WP;


    void Start()
    {
        WP = GetComponent<WeaponFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinkDamage(float damage)
    {
        if(WP.Player != null)
        {
            WP.Player.GetComponent<Health>().TakeDamage(damage);
        }
        
    }
}
