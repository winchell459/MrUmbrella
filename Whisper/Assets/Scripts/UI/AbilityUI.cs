using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public AbilityObject Melee;
    public AbilityObject Protection;
    public AbilityObject Range;

    public Transform MeleeSlot;
    public Transform ProtectionSlot;
    public Transform RangeSlot;

    private void Start()
    {
        loadAbilities();
    }
    public void SetSlot(AbilityObject ability)
    {
        if(ability.AbilityType == AbilityObject.AbilityTypes.Melee) {
            Melee = ability;
            PlayerHandler.PH.Melee = Melee;
            assignSlot(ability, MeleeSlot);
        }else if(ability.AbilityType == AbilityObject.AbilityTypes.Protection)
        {
            Protection = ability;
            PlayerHandler.PH.Protection = Protection;
            assignSlot(ability, ProtectionSlot);
        }
        else if (ability.AbilityType == AbilityObject.AbilityTypes.Range)
        {
            Range = ability;
            PlayerHandler.PH.Range = Range;
            assignSlot(ability, RangeSlot);
        }
    }

    private void assignSlot(AbilityObject ability, Transform slot)
    {
        slot.GetComponent<Image>().sprite = ability.AbilitySprite;
        slot.GetChild(0).GetComponent<Text>().text = ability.Detail;
    }

    private void loadAbilities()
    {
        Melee = PlayerHandler.PH.Melee;
        Protection = PlayerHandler.PH.Protection;
        Range = PlayerHandler.PH.Range;
    }
}
