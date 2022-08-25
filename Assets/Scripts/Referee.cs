using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    public static Referee Instance;

    public Boxer winner;

    private readonly string WIN_TEXT = "You win!";
    private readonly string LOSE_TEXT = "You lose...";

    [SerializeField] private TMPro.TMP_Text infoText;
    [SerializeField] private Countdown countdown;

    private void Awake()
    {
        Instance = this;
    }

    public void StartCountdown()
    {
        countdown.StartCountdown();
    }
    
    public void StopCountdown()
    {
        countdown.StopCountdown();   
    }

    public void WinDetection(bool isPlayerWin)
    {
        if (isPlayerWin)
            infoText.text = WIN_TEXT;
        else
            infoText.text = LOSE_TEXT;
    }
}
