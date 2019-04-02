using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgTheme;
    public AudioSource efxSource1;
    public AudioSource efxSource2;
    public AudioSource efxSource3;
    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgTheme.Play();
    }

    public void EfxOut1(AudioClip clip)
    {
        if (efxSource1.isPlaying == false)
        {
            efxSource1.clip = clip;
            efxSource1.PlayOneShot(clip);
        }
    }

    public void EfxOut2(AudioClip clip)
    {
        if (efxSource1.isPlaying == false)
        {
            efxSource1.clip = clip;
            efxSource1.PlayOneShot(clip);
        }
    }

    public void EfxOut3(AudioClip clip)
    {
        if (efxSource2.isPlaying == false)
        {
            efxSource2.clip = clip;
            efxSource2.PlayOneShot(clip);
        }
    }

    public void EfxOut4(AudioClip clip)
    {
        if (efxSource3.isPlaying == false)
        {
            efxSource3.clip = clip;
            efxSource3.PlayOneShot(clip);
        }
    }
}
