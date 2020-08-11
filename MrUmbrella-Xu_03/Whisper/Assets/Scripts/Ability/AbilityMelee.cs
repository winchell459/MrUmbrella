using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee", menuName = "CustomObject/Ability/Melee")]
public class AbilityMelee : AbilityObject
{
    public enum MeleeTypes
    {
        Swing,
        Poke,
        Smash
    }
    public MeleeTypes MeleeType;
}
