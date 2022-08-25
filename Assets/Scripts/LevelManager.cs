using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BotControll opponent;

    public void Awake()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void SetOpponentSettings(BoxerSettings settings)
    {
        opponent.SetBoxerSettings(settings);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
