using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxer : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected Boxer target;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected AudioPlayer audioPlayer;

    protected BoxerState currentState;

    protected bool block;

    protected int maxHealthPoints;
    protected int healthPoints;
    protected int damagePerPunch;

    public BoxerState CurrentState => currentState;

    protected virtual void Punch()
    {
        audioPlayer.PlaySound(Clips.Punch);
        target.Hitting(damagePerPunch);
    }

    public virtual void Hitting(int damage)
    {

        healthPoints -= damage;

        UpdateUI();

        audioPlayer.PlaySound(Clips.Punch);

        if (healthPoints <= 0)
        {
            Death();
            return;
        }
        animator.SetTrigger("TakeHit");
    }

    protected void BlockHitting()
    {
        animator.SetBool("Block", true);
        animator.SetTrigger("TakeHit");
        animator.SetBool("Block", false);
        audioPlayer.PlaySound(Clips.Block);
    }

    protected void UpdateUI()
    {
        healthBar.SetFillingAmount((float)healthPoints / (float)maxHealthPoints);
    }

    protected virtual void Death()
    {
        currentState = BoxerState.Knockdown;
        animator.SetTrigger("Knockdown");
    }
}
