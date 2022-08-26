using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : Boxer
{
    [SerializeField] private ButtonsInput buttonsInput;
    [SerializeField] private int damage;
    [SerializeField] private new int maxHealthPoints;

    private void Awake()
    {
        damagePerPunch = damage;
        base.maxHealthPoints = this.maxHealthPoints;
        currentState = BoxerState.Fight;
        healthPoints = maxHealthPoints;
        buttonsInput.OnBlockButtonChangeState += ChangeBlockState;
        buttonsInput.OnLeftHandPunchButtonClicked += LeftHandPunch;
        buttonsInput.OnRightHandPunchButtonClicked += RightHandPunch;
    }

    public void ChangeBlockState(bool state)
    {
        block = state;
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
        animator.LeftHandPunch();
        Punch();
    }

    private void RightHandPunch()
    {
        if (currentState != BoxerState.Fight)
            return;
        animator.RightHandPunch();
        Punch();
    }
}
