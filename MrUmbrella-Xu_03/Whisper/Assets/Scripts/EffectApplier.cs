using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplier : MonoBehaviour
{


    public float slowSpeed;

    public float duration;



    public void ReturnSpeedCall()
    {
        FindObjectOfType<PlayerController>().speed = slowSpeed;
        Invoke("ReturnSpeed", duration);
    }


    public void ReturnSpeed()
    {
        FindObjectOfType<PlayerController>().speed = 7.5f;
        Debug.Log("Yappy");
    }
}
