using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    protected AudioSource audioSource;
    public AudioClip[] songs;
    public int curPlaying = 0;
    public bool isPlaying = false;


    protected override void Start()
    {
        base.Start();
        PlayClip();
       
    }

    public void PlayClip()
    {
        audioSource.clip = songs[curPlaying];
        audioSource.Play();

    }

    public override void OnUse()
    {
        base.OnUse();

        if (!isPlaying)
        {
            isPlaying = true;
            curPlaying = 0;
            PlayClip();
            return;
        }

        curPlaying++;

        if (curPlaying >= songs.Length)
        {
            isPlaying = false;
            audioSource.Stop();
        }

        else
        {
            PlayClip();
        }
    }
}
