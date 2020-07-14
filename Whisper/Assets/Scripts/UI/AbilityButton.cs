using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public AbilityObject Ability;

    public void Select()
    {
        FindObjectOfType<AbilityUI>().SetSlot(Ability);
    }
    private void Awake()
    {
        GetComponent<Image>().sprite = Ability.AbilitySprite;
        transform.GetChild(0).GetComponent<Text>().text = Ability.Detail;
    }
}
