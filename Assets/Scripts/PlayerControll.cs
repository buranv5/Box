using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private int damagePerPunch;
    [SerializeField] private int healthPoints;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BotControll target;
    [SerializeField] private Button leftHandPunchButton; 
    [SerializeField] private Button rightHandPunchButton;
    [SerializeField] private Animator animator;

    private bool block;

    private void Awake()
    {
        leftHandPunchButton.onClick.AddListener(LeftHandPunch); 
        rightHandPunchButton.onClick.AddListener(RightHandPunch); 
    }

    public void Hitting(int damage)
    {
        if (block)
            return;

        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Death();
        }
    }

    public void ChangeBlockState(bool state)
    {
        block = state;
        animator.SetBool("Block", block);
    }

    private void LeftHandPunch()
    {
        animator.SetTrigger("RightPunch");
        target.Hitting(damagePerPunch);
    }

    private void RightHandPunch()
    {
        animator.SetTrigger("LeftPunch");
        target.Hitting(damagePerPunch);
    }

    private void Death()
    {

    }
}
