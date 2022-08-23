using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image bar;

    private void Awake()
    {
        bar = GetComponent<Image>();
        bar.type = Image.Type.Filled;
    }

    private void SetFillingAmount(float value)
    {
        bar.fillAmount = value;
    }
}
