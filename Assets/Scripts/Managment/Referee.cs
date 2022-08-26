using UniRx;
using UnityEngine;

public class Referee : MonoBehaviour
{
    private readonly string WIN_TEXT = "You win!";
    private readonly string LOSE_TEXT = "You lose...";

    [SerializeField] private TMPro.TMP_Text infoText;
    [SerializeField] private Countdown countdown;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private PlayerControll player;
    [SerializeField] private BotControll opponent;

    public static Referee Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TryStartCountdown()
    {
        if(opponent.CurrentState != player.CurrentState)
            countdown.StartCountdown(() => WinDetection(player.CurrentState == BoxerState.Fight));
    }
    
    public void TryStopCountdown()
    {
        if(opponent.CurrentState == BoxerState.Fight)
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
        Observable.Timer(System.TimeSpan.FromSeconds(0.5)).TakeUntilDisable(gameObject).Subscribe(_ => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
    }
}
