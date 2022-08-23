using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoxerSettings :  ScriptableObject
{
    public int MaxHealthPoint;
    public int DamagePerPunch;
    [Range(0f, 1f)] public float BlockChance;
    [Range(0f, 1f)] public float ReviveChance;
}
