using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image bar;

    private void Awake()
    {
        bar = GetComponent<Image>();
    }

    public void SetFillingAmount(float value)
    {
        bar.fillAmount = value;
    }
}
