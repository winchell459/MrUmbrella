using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider slider;

    public Health selfHealth;

    private bool isSetMax;

    void Start()
    {
        
        slider = GetComponent<Slider>();

        
    }


    void SetBar()
    {
        slider.value = selfHealth.health;
    }

    void Update()
    {
        if (selfHealth == null)
        {
            selfHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

            isSetMax = true;


        }
        if(isSetMax == true)
        {
            slider.maxValue = selfHealth.GetMaxHealth();
            isSetMax = false;
        }
        
        

        SetBar();
        
    }
}
