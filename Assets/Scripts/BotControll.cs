using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControll : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BoxerSettings data;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControll target;
    
    private int healthPoints;
    private bool block;

    private void Awake()
    {
        healthPoints = data.MaxHealthPoint;
    }

    public void Hitting(int damage)
    {
        if (UnityEngine.Random.value <= data.BlockChance)
            return;

        healthPoints -= damage;
        healthBar.SetFillingAmount((float)healthPoints / (float)data.MaxHealthPoint);

        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaa");

        if (healthPoints <= 0)
        {
            Death();
        }
    }

    private void Punching()
    {
        target.Hitting(data.DamagePerPunch);
    }

    private void Death()
    {
        animator.SetTrigger("");
    }
}
