using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public float musicVolumeInitial;
    public float musicVolumeEnding;
    public bool fadeOutMusic;
    public bool fadeInMusic;
    public string nameOfSongToFade;
    public string nameOfSongToPlay;
    int section;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
        }        
    }


    void Update()
    {
        if (fadeOutMusic)
        {
            Sound s = Array.Find(sounds, sound => sound.name == nameOfSongToFade);

            s.source.volume -= 1.9f * Time.deltaTime;

            if (s.source.volume <= 0)
            {
                s.source.Stop();
                s.source.volume = musicVolumeEnding;
                fadeOutMusic = false;
            }
        }

        if (fadeInMusic)
        {
            Sound a = Array.Find(sounds, sound => sound.name == nameOfSongToPlay);

            a.source.Play();
            a.source.volume = musicVolumeInitial;
            fadeInMusic = false;


            //if (section == 0)
            //{
            //    Sound a = Array.Find(sounds, sound => sound.name == nameOfSongToPlay);
            //    a.source.volume = 0;
            //    a.source.Play();

            //    section += 1;
            //}

            //if (section == 1)
            //{
            //    Sound a = Array.Find(sounds, sound => sound.name == nameOfSongToPlay);

            //    a.source.volume = musicVolumeInitial;
            //    fadeInMusic = false;
            //    section = 0;


                //a.source.volume += 2f * Time.deltaTime;

                //if (a.source.volume >= musicVolumeInitial)
                //{
                //    a.source.volume = musicVolumeInitial;
                //    fadeInMusic = false;
                //    section = 0;
                //}
            //}
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaySound("Hit");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlaySound("Dying");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            PlaySound("TurnPage");
        }

    }


    public void AdjustMusicVolume(float value)
    {
        foreach (var sound in sounds)
        {
            if (sound.loop == true)
            {
                sound.source.volume = value;
                //musicVolumeInitial = sound.source.volume;
                //musicVolumeEnding = sound.source.volume;
            }
        }
    }

    public void AdjustSoundVolume(float value)
    {
        foreach (var sound in sounds)
        {
            if (sound.loop == false)
            {
                sound.source.volume = value;
            }
        }
    }

    public void PlayMusic (string name)
    {
        Sound a = Array.Find(sounds, sound => sound.name == name);
        musicVolumeInitial = a.source.volume;

        nameOfSongToPlay = name;
        fadeInMusic = true;

        //s.source.Play();
    }

    public void PlaySound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.PlayOneShot(s.clip);
    }

    public void StopMusicAndSound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        musicVolumeEnding = s.source.volume;

        nameOfSongToFade = name;
        fadeOutMusic = true;

        //Sound s = Array.Find(sounds, sound => sound.name == name);

        //s.source.Stop();
    }

    public void StopMusicCompletely(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();

        //Sound s = Array.Find(sounds, sound => sound.name == name);

        //s.source.Stop();
    }

}
