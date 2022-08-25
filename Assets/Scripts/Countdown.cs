using UniRx;
using DG.Tweening;
using System;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text countdownText;

    private IDisposable countdown;

    public void StartCountdown(Action Callback)
    {
        int num = 11;
        countdown = Observable.Interval(TimeSpan.FromSeconds(1)).TakeUntilDisable(gameObject).Subscribe(_ =>
        {
            num--;
            countdownText.text = num.ToString();
            countdownText.transform.DOScale(Vector3.one, 0);
            countdownText.transform.DOScale(Vector3.zero, 1);

            if (num == 0)
            {
                countdownText.transform.DOKill();
                countdownText.text = "";
                Callback?.Invoke();
                StopCountdown();
            }
        });
    }

    public void StopCountdown()
    {
        countdownText.transform.DOKill();
        countdownText.text = "";
        countdown?.Dispose();
    }
}
