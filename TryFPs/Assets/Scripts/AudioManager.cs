using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource m_Source;
    [SerializeField] AudioSource sfx_Source;

    [Header("----- Audio Clip -----")]
    public AudioClip backGround;
    public AudioClip jumpScare;
    public AudioClip intro;

    private void Start()
    {
        m_Source.clip = backGround;
        m_Source.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx_Source.PlayOneShot(clip);
    }
}
