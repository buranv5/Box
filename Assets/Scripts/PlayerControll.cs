using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private int damagePerPunch;
    [SerializeField] private int maxHealthPoints;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BotControll target;
    [SerializeField] private Button leftHandPunchButton; 
    [SerializeField] private Button rightHandPunchButton;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioPlayer audioPlayer;

    private BoxerState currentState;
    private bool block;
    private int healthPoints;

    private void Awake()
    {
        currentState = BoxerState.Fight;
        healthPoints = maxHealthPoints;
        leftHandPunchButton.onClick.AddListener(LeftHandPunch); 
        rightHandPunchButton.onClick.AddListener(RightHandPunch); 
    }

    public void Hitting(int damage)
    {
        animator.SetTrigger("TakeHit");

        if (block || currentState != BoxerState.Fight)
        {
            audioPlayer.PlaySound(Clips.Block);
            return;
        }

        healthPoints -= damage;

        UpdateUI();

        audioPlayer.PlaySound(Clips.Punch);

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
        Punch();
    }

    private void RightHandPunch()
    {
        animator.SetTrigger("LeftPunch");
        Punch();
    }

    private void UpdateUI()
    {
        healthBar.SetFillingAmount((float)healthPoints / (float)maxHealthPoints);
    }

    private void Punch()
    {
        audioPlayer.PlaySound(Clips.Punch);
        target.Hitting(damagePerPunch);
    }

    private void Death()
    {
        animator.SetTrigger("Knockdown");
        currentState = BoxerState.Knockdown;
    }
}
