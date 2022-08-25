using UniRx;
using DG.Tweening;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Text countdownText;
    private int num;
        public void StartCountdown()
    {
        num = 11;
        CountdownAnimation();
    }

    public void StopCountdown()
    {
        countdownText.transform.DOKill();
        countdownText.text = "";
    }

    private void CountdownAnimation()
    {
        num--;
        countdownText.text = num.ToString();
        countdownText.transform.DOScale(Vector3.one, 0);
        countdownText.transform.DOScale(Vector3.zero, 1).OnComplete(() =>
        {
            CountdownAnimation();
        });

        if(num == 0)
        {
            countdownText.transform.DOKill();
            countdownText.text = "";
        }


    }

}
