using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SelfPos;
    public float FireInterval;
    public int FireAmount;

    private bool isStartCD;
    private float MaxTime;
    private bool canSpanwNextBullet = true;

    private void SpawnBullet()
    {
        Instantiate(Bullet, SelfPos);
    }
    private void Start()
    {
        MaxTime = FireInterval;
    }

    private void Fire()
    {
        for(int i = 1; i < FireAmount; i = i + 1)
        {
            
            

            if (canSpanwNextBullet)
            {
                SpawnBullet();
                Debug.Log(i);

                canSpanwNextBullet = false;
            }
            else
            {
                isStartCD = true;
                CDCountDown();
            }
            
        }
        
    }

    private void Update()
    {
        Fire();
    }
    private void CDCountDown()
    {

        if (isStartCD)
        {
            FireInterval = FireInterval - Time.deltaTime;

            //Debug.Log(isStartCD);

            if (FireInterval <= 0)
            {
                canSpanwNextBullet = true;
                FireInterval = MaxTime;
                isStartCD = false;
            }
        }



    }

}
