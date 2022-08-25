using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Boxer boxer;

    private Image bar;

    private void Awake()
    {
        boxer.OnDamageTaken += SetFillingAmount;
        bar = GetComponent<Image>();
    }

    public void SetFillingAmount(float value)
    {
        bar.fillAmount = value;
    }
}
