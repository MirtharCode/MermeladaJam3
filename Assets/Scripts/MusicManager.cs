using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float initialClipDurationButNotAll;
    public AudioSource aS;
    public AudioClip[] audioClips;
    private int currentClipIndex = 0;
    private bool yaEntreEnBucle = false;
    public float secondsCounter = 0;


    // Chusmiflú
    void Start()
    {
        initialClipDurationButNotAll = audioClips[0].length - 0.25f;

        if (audioClips.Length > 0)
        {
            aS.clip = audioClips[currentClipIndex];
            aS.Play();
        }
    }

    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (/*!aS.isPlaying &&*/ currentClipIndex != 1 && secondsCounter >= initialClipDurationButNotAll)
        {
            PlayNextClip();
        }
        else if (currentClipIndex == 1 && !yaEntreEnBucle)
        {
            yaEntreEnBucle = true;
            aS.loop = true;
        }
    }

    void PlayNextClip()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
        aS.clip = audioClips[currentClipIndex];
        aS.Play();
    }
}
