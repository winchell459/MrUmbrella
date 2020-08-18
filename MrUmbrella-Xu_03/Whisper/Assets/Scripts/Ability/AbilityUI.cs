using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public AbilityMelee Melee;
    public AbilityRange Range;
    public AbilityProtection Protection;

    public Transform MeleeSlot;
    public Transform ProtectionSlot;
    public Transform RangeSlot;

    public AbilityButton[] MeleeAbilityButtons, RangeAbilityButtons, ProtectionAbilityButtons;

    private void Start()
    {
        loadAbilities();
    }
    private void loadAbilities()
    {
        Melee = PlayerHandler.PH.Melee;
        Protection = PlayerHandler.PH.Protection;
        Range = PlayerHandler.PH.Range;
    }
    public void SetSlot(AbilityObject ability)
    {
        if(ability.AbilityType == AbilityObject.AbilityTypes.Melee)
        {
            Melee = (AbilityMelee)ability;

            PlayerHandler.PH.Melee = Melee;
            

            assignSlot(ability, MeleeSlot);

        }
        else if(ability.AbilityType == AbilityObject.AbilityTypes.Protection)
        {
            Protection = (AbilityProtection)ability;

            PlayerHandler.PH.Protection = Protection;

            assignSlot(ability, ProtectionSlot);

        }
        else if (ability.AbilityType == AbilityObject.AbilityTypes.Range)
        {
            Range = (AbilityRange)ability;

            PlayerHandler.PH.Range = Range;

            assignSlot(ability, RangeSlot);
        }
    }
    private void assignSlot(AbilityObject ability, Transform slot)
    {
        slot.GetComponent<Image>().sprite = ability.AbilitySprite;
        slot.GetChild(1).GetComponent<Text>().text = ability.Detail;
    }

    public void DisplayAbilities()
    {
        if (Melee) assignSlot(Melee, MeleeSlot);
        if (Range) assignSlot(Range, RangeSlot);
        if (Protection) assignSlot(Protection, ProtectionSlot);
    }
}
