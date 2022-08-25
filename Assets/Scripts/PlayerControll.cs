using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : Boxer
{
    [SerializeField] private int damage;
    [SerializeField] private new int maxHealthPoints;
    [SerializeField] private Button leftHandPunchButton; 
    [SerializeField] private Button rightHandPunchButton;

    private void Awake()
    {
        damagePerPunch = damage;
        base.maxHealthPoints = this.maxHealthPoints;
        currentState = BoxerState.Fight;
        healthPoints = maxHealthPoints;
        leftHandPunchButton.onClick.AddListener(LeftHandPunch); 
        rightHandPunchButton.onClick.AddListener(RightHandPunch);
        Referee.Instance.AddBoxer(this);
    }

    public void ChangeBlockState(bool state)
    {
        block = state;
        animator.SetBool("Block", block);
    }

    public override void Hitting(int damage)
    {
        if (block || currentState != BoxerState.Fight)
        {
            BlockHitting();
            return;
        }

        base.Hitting(damage);
    }

    private void LeftHandPunch()
    {
        if (currentState != BoxerState.Fight)
            return;
        animator.SetTrigger("RightPunch");
        Punch();
    }

    private void RightHandPunch()
    {
        if (currentState != BoxerState.Fight)
            return;
        animator.SetTrigger("LeftPunch");
        Punch();
    }
}
