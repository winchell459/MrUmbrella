using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Protection", menuName = "CustomObject/Ability/Protection")]
public class AbilityProtection : AbilityObject
{
   public enum ProtectionTypes
    {
        Shield,
        Invinc,
        Healing
    }
    public ProtectionTypes ProtectionType;
    //public float Duration = 1;
}
