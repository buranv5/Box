using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    private readonly string WIN_TEXT = "You win!";
    private readonly string LOSE_TEXT = "You lose...";

    [SerializeField] private TMPro.TMP_Text infoText;
    [SerializeField] private Countdown countdown;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private PlayerControll player;

    private List<Boxer> boxers = new List<Boxer>();

    public static Referee Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddBoxer(Boxer newBoxer)
    {
        foreach (Boxer boxer in boxers)
        {
            if (boxer == newBoxer)
                return;
        }
        boxers.Add(newBoxer);
    }

    public void TryStartCountdown()
    {
        int boxersInFight = 0;
        foreach(Boxer boxer in boxers)
        {
            if (boxer.CurrentState == BoxerState.Fight)
                boxersInFight++;
        }

        if (boxersInFight > 1)
            return;

        countdown.StartCountdown(() => WinDetection(player.CurrentState == BoxerState.Fight));
    }
    
    public void TryStopCountdown()
    {
        int boxersInFight = 0;
        foreach (Boxer boxer in boxers)
        {
            if (boxer.CurrentState == BoxerState.Fight)
                boxersInFight++;
        }

        if (boxersInFight > 1)
            countdown.StopCountdown();   
    }

    public void WinDetection(bool isPlayerWin)
    {
        if (isPlayerWin)
        {
            infoText.text = WIN_TEXT;
            audioPlayer.PlaySound(Clips.Win);
        }
        else
        {
            infoText.text = LOSE_TEXT;
            audioPlayer.PlaySound(Clips.Lose);
        }
    }
}
