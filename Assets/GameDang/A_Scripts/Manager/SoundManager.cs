using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Steampunk = 0,
    Korea = 1,
    Fantasy = 2,
    Punk = 3
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> bgms;
    [SerializeField] private AudioSource audioSource; // AudioSource 컴포넌트

    public static SoundManager Instance
    {
        get => instance;
        set => instance = value;
    }
    private static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Play(TowerManager.EnumySelectTowerIndex);
    }
    private void OnDisable()
    {
        Stop();
    }

    public void Play(SoundType type) => Play((int) type);
    public void Play(int index)
    {
        Debug.Log(index);
        audioSource.clip = bgms[index];
        audioSource.loop = true;
        audioSource.Play();
    }
    public void Stop()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
