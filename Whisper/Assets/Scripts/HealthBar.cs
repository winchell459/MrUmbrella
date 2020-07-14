using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Health selfHealth;


    public GameObject Parent;


    private void Start()
    {
        slider.maxValue = selfHealth.health;

    }


    void SetBar()
    {
        slider.value = selfHealth.health;
    }

    void SetBarStateOff(bool isClose)
    {
        if (isClose)
        {
           
            slider.gameObject.SetActive(false);

            //Debug.Log("set");
        }
        else
        {
            slider.gameObject.SetActive(true);

        }
        
    }

    private void Update()
    {
        SetBar();

        if(Parent != null)
        {
            if (selfHealth.gameObject.transform.parent.gameObject.GetComponent<EnemyDamagable>().isEnemyDamage == false)
            {
                SetBarStateOff(true);

            }
            else
            {
                SetBarStateOff(false);
            }
        }

    }

}
