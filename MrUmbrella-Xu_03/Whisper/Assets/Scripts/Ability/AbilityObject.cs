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
    public Sprite LockedSprite;

    
    //Protection
    public float Duration = 1; //how long does ability last
    //Every
    public float Power = 3; //damage for melee and range or proteciton percent for protection
    public float CD = 1; //cool down
    //Melee
    public float Radius = 3; //ability radius


}
