using System;
using UniRx;
using UnityEngine;

public class BotControll : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BoxerSettings data;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControll target;
    
    private int healthPoints;

    private IDisposable punchDisposable;
    private BoxerState currentState;

    private void Awake()
    {
        healthPoints = data.MaxHealthPoint;
        StartFight();
    }

    private void StartFight()
    {
        currentState = BoxerState.Fight;
        TimeSpan delay = TimeSpan.FromSeconds(data.PunchDelay);
        punchDisposable = Observable.Interval(delay).TakeUntilDisable(gameObject).Subscribe(_ =>
        {
            Punching();
        });        
    }

    public void Hitting(int damage)
    {
        if (UnityEngine.Random.value <= data.BlockChance || currentState != BoxerState.Fight)
            return;

        UpdateUI();

        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Death();
        }
    }

    private void UpdateUI()
    {
        healthBar.SetFillingAmount((float)healthPoints / (float)data.MaxHealthPoint);
    }

    private void Punching()
    {
        target.Hitting(data.DamagePerPunch);

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            animator.SetTrigger("RightPunch");
        }
        else
        {
            animator.SetTrigger("LeftPunch");
        }
    }

    private void Death()
    {
        currentState = BoxerState.Knockdown;
        UpdateUI();
        punchDisposable?.Dispose();
        animator.SetTrigger("Knockdown");
            Countdown.Instance.StartCountdown();
        if (UnityEngine.Random.value <= data.ReviveChance)        
            Observable.Timer(TimeSpan.FromSeconds(UnityEngine.Random.Range(0f, 10f))).TakeUntilDisable(gameObject).Subscribe(_ =>
            {
                Revive();
                Countdown.Instance.StopCountdown();
            });
        else        
            currentState = BoxerState.Dead;        
    }

    private void Revive()
    {
        animator.SetTrigger("Getup");
        StartFight();
        healthPoints = (int)Math.Round(data.MaxHealthPoint * 0.75f);
        UpdateUI();
    }
}
