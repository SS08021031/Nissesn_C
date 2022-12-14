using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource titleMusic, inGameMusic;
    public AudioSource[] SE;

    //BGMを止める処理
    public void StopMusic()
    {
        titleMusic.Stop();

        inGameMusic.Stop();
    }
    //MainMenuのBGM再生
    public void PlayTitleMusic()
    {
        StopMusic();
        titleMusic.Play();

    }

    //IngameのBGM再生
    public void PlayinGameMusic()
    {
        StopMusic();
        inGameMusic.Play();
    }
    //SEの再生
    public void PlaySE(int SEtoPlay)
    {
        SE[SEtoPlay].Stop();
        SE[SEtoPlay].Play();
    }
}
