using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Range", menuName = "CustomObject/Ability/Range")]
public class AbilityRange : AbilityObject
{
    public enum RangeTypes
    {
        Bullet,
        Fireball,
        SmallBullet
    }
    public RangeTypes RangeType;
    public float speed = 1;

}
