using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerPrefs
{
    private static readonly string aduioEnableKey = "audio_enable";
    private static readonly string musicEnableKey = "music_enable";

    public static bool AduioEnable
    {
        get => PlayerPrefs.GetInt(aduioEnableKey, 1) == 1;
        set
        {
            var input = value ? 1 : 0;
            PlayerPrefs.SetInt(aduioEnableKey,input);
        }
    }
    public static bool MusicEnable
    {
        get => PlayerPrefs.GetInt(musicEnableKey, 1) == 1;
        set
        {
            var input = value ? 1 : 0;
            PlayerPrefs.SetInt(musicEnableKey,input);
        }
    }
}
