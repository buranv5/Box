using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInput : MonoBehaviour
{
    [SerializeField] private Button leftHandPunchButton;
    [SerializeField] private Button rightHandPunchButton;
    [SerializeField] private BlockButton blockButton;

    public Action OnLeftHandPunchButtonClicked;
    public Action OnRightHandPunchButtonClicked;
    public Action<bool> OnBlockButtonChangeState;

    private void Awake()
    {
        leftHandPunchButton.onClick.AddListener(() => OnLeftHandPunchButtonClicked?.Invoke());
        rightHandPunchButton.onClick.AddListener(() => OnRightHandPunchButtonClicked?.Invoke());
        blockButton.OnBlockStateChange += ChangeBlockState;
    }

    private void ChangeBlockState(bool state)
    {
        OnBlockButtonChangeState.Invoke(state);
    }
}
