using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChecker : MonoBehaviour
{
    public GameObject target;



    private void Update()
    {
        if(target.activeInHierarchy == true)
        {
            

        }
        else
        {
            
        }
        if(FindObjectOfType<SwitchManager>().isSwitch == true)
        {
            target.transform.parent.GetComponent<Animator>().SetBool("isActive", true);
        }
        else
        {
            target.transform.parent.GetComponent<Animator>().SetBool("isActive", false);
        }
        
    }
}
