using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    [SerializeField] private AudioClip featherSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip failiureSound;
    [SerializeField] private AudioClip[] NoiseSounds;

    public void PlayfailiureSound()
    {
        SoundManager.instance.EfxOut1(failiureSound);
    }

    public void PlayFeatherSound()
    {
        SoundManager.instance.EfxOut2(featherSound);
    }

    public void PlayjumpSound()
    {
        SoundManager.instance.EfxOut3(jumpSound);
    }

    public void PlayNoiseSounds()
    {
        SoundManager.instance.EfxOut4(NoiseSounds[Random.Range(0, NoiseSounds.Length)]);
    }
}
