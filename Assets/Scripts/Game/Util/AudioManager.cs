using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource EffectsSource;

    public static AudioManager Instance { get; private set; }

    public AudioSource backgroundMusic { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ReplaceTrack(AudioClip clip)
    {
        if (MusicSource.clip == clip)
            return;

        MusicSource.Stop();
        MusicSource.clip = clip;
        MusicSource.pitch = 1;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }

    public void FadeOutMusic(float fadeTime)
    {
        StartCoroutine(_FadeOutMusic(MusicSource, fadeTime));
    }

    public void FadeInMusic(float fadeTime)
    {
        StartCoroutine(_FadeInMusic(MusicSource, fadeTime));
    }

    public void SlowDownMusic(float slowTime)
    {
        StartCoroutine(_SlowDownMusic(MusicSource, slowTime));
        MusicSource.pitch = 1;
    }

    static IEnumerator _FadeOutMusic(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Pause();
        audioSource.volume = startVolume;
    }

    static IEnumerator _FadeInMusic(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

    static IEnumerator _SlowDownMusic(AudioSource audioSource, float time)
    {
        audioSource.pitch = 1;

        while (audioSource.pitch > 0)
        {
            audioSource.pitch -= Time.deltaTime / time;
            yield return null;
        }

        audioSource.Pause();
        audioSource.pitch = 0;
    }
}
