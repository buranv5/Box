using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clips;

    public void PlaySound(Clips clip)
    {
        audioSource.PlayOneShot(clips[(int)clip]);
    }

}

public enum Clips
{
    Background,
    Block,
    Punch,
    Win,
    Lose,
}
