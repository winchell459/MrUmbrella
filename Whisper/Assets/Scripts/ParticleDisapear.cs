using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleDisapear : MonoBehaviour
{
    public bool isStartCD;
    public bool isGround;
    public float CDTime;
    public GameObject[] Particles;
    public float SetCDTime;

    public GameObject PS;

    public GameObject UpGround;

    private void Start()
    {
        SetCDTime = CDTime;
    }
    private void Update()
    {
        Particles = GameObject.FindGameObjectsWithTag("particle");

        CDCountDown(Particles);
    }

    private void CDCountDown(GameObject[] TheParticles)
    {
        
        if (isStartCD)
        {
            CDTime = CDTime - Time.deltaTime;

            //Debug.Log(isStartCD);

            if (CDTime <= 0)
            {
                /*
                if (isGround)
                {
                    if (UpGround.transform.childCount >= 1) Destroy(UpGround.transform.GetChild(0).gameObject);

                    isGround = false;
                }
                */

                GameObject.FindGameObjectWithTag("particle");

                if (TheParticles.Length >= 1) {
                    for(int i = 0; i < TheParticles.Length; i = i + 1)
                    {
                        Destroy(TheParticles[i]);
                    }
                   
                } 

                CDTime = SetCDTime;
                isStartCD = false;
                //Debug.Log(isStartCD);
            }
        }



    }
}