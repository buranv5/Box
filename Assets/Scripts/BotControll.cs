using System;
using UniRx;
using UnityEngine;

public class BotControll : Boxer
{
    [SerializeField] private BoxerSettings data;
    
    private IDisposable punchDisposable;

    private void Awake()
    {
        damagePerPunch = data.DamagePerPunch;
        maxHealthPoints = data.MaxHealthPoint;
        healthPoints = maxHealthPoints;
        StartFight();
    }

    public void SetBoxerSettings(BoxerSettings settings)
    {
        data = settings;
        Awake();
    }

    private void StartFight()
    {
        currentState = BoxerState.Fight;
        TimeSpan delay = TimeSpan.FromSeconds(data.PunchDelay);
        punchDisposable = Observable.Interval(delay).TakeUntilDisable(gameObject).Subscribe(_ =>
        {
            if(currentState == BoxerState.Fight)
                Punch();
        });        
    }

    public override void Hitting(int damage)
    {
        if(currentState != BoxerState.Fight)
        {
            return;
        }

        if (UnityEngine.Random.value <= data.BlockChance && currentState == BoxerState.Fight)
        {
            BlockHitting();
            return;
        }

        base.Hitting(damage);
    }

    protected override void Punch()
    {
        if (target.CurrentState != BoxerState.Fight)
            return;

        base.Punch();

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            animator.SetTrigger("RightPunch");
        }
        else
        {
            animator.SetTrigger("LeftPunch");
        }
    }

    protected override void Death()
    {
        base.Death();
        punchDisposable?.Dispose();
        if (UnityEngine.Random.value <= data.ReviveChance)        
            Observable.Timer(TimeSpan.FromSeconds(UnityEngine.Random.Range(0f, 10f))).TakeUntilDisable(gameObject).Subscribe(_ =>
            {
                Revive();
            });
        else        
            currentState = BoxerState.Dead;        
    }

    private void Revive()
    {
        animator.SetTrigger("Getup");
        StartFight();
        healthPoints = (int)Math.Round(data.MaxHealthPoint * 0.75f);
        OnDamageTaken?.Invoke((float)healthPoints / (float)maxHealthPoints);
        Referee.Instance.TryStopCountdown();
    }
}
