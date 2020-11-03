﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public AbilityObject Ability;
    private bool unlocked;

    public void Select()
    {
        FindObjectOfType<AbilityUI>().SetSlot(Ability);
    }
    private void Awake()
    {
        if (PlayerHandler.PH.AbilityUnlocked(Ability))
        {
            Unlock();

        }
        else
        {
            GetComponent<Image>().sprite = Ability.LockedSprite;
            GetComponent<Button>().interactable = false;
        }

        transform.GetChild(1).GetComponent<Text>().text = Ability.Detail;
    }
    public void Unlock()
    {
        GetComponent<Image>().sprite = Ability.AbilitySprite;
        unlocked = true;
        GetComponent<Button>().interactable = true;
    }
    bool isToggle;
    public void Discription(GameObject info)
    {
        isToggle = !isToggle;
        if (isToggle)
        {
            info.SetActive(true);
        }
        else
        {
            info.SetActive(false);
        }
    }
}
