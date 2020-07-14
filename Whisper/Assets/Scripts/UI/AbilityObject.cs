using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "CustomObject/Ability")]
public class AbilityObject : ScriptableObject
{
    public enum AbilityTypes
    {
        Melee,
        Protection,
        Range
    }
    public AbilityTypes AbilityType;
    public string Detail = "YES";
    public Sprite AbilitySprite;

    
}
