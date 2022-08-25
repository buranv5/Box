using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoxerSettings :  ScriptableObject
{
    public int MaxHealthPoint;
    public int DamagePerPunch;
    public double PunchDelay;
    [SerializeField] public float ReviveChance; // tak nado)
    [Range(0f, 1f)] public float BlockChance;
}
