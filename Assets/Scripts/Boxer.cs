using System;
using UnityEngine;

public class Boxer : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected Boxer target;
    [SerializeField] protected AudioPlayer audioPlayer;

    protected BoxerState currentState;

    protected bool block;

    protected int maxHealthPoints;
    protected int healthPoints;
    protected int damagePerPunch;

    public Action<float> OnDamageTaken;

    public BoxerState CurrentState => currentState;

    protected virtual void Punch()
    {
        audioPlayer.PlaySound(Clips.Punch);
        target.Hitting(damagePerPunch);
    }

    public virtual void Hitting(int damage)
    {
        healthPoints -= damage;

        audioPlayer.PlaySound(Clips.Punch);

        OnDamageTaken?.Invoke((float)healthPoints / (float)maxHealthPoints);

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
        animator.SetBool("Block", false);
        audioPlayer.PlaySound(Clips.Block);
    }

    protected virtual void Death()
    {
        currentState = BoxerState.Knockdown;
        animator.SetTrigger("Knockdown");
        Referee.Instance.TryStartCountdown();
    }
}
