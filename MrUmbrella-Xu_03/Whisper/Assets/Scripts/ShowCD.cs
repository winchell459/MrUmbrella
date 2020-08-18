using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCD : MonoBehaviour
{
    public Text meleeCDtext;
    float difference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (difference <= 1 && difference >= 0)
        {
            difference = Mathf.Round((Time.time - FindObjectOfType<PlayerAttack>().MeleeNextAttackTime) * 10);
            difference = difference / 10;
        }
        else
        {
            difference = Mathf.Round(Time.time - FindObjectOfType<PlayerAttack>().MeleeNextAttackTime);
        }
        
        if(difference > 0)
        {
            difference = 0;
        }

        meleeCDtext.text = (-difference).ToString();

        
    }
}
