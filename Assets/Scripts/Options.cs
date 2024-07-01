using System.Collections;
using System.Collections.Generic;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Image sounds;
    [SerializeField] Image music;
    [SerializeField] Color on;
    [SerializeField] Color off;
    
    // Start is called before the first frame update
    void Start()
    {
        int s = PlayerPrefs.GetInt("sounds", 1);
        sounds.color = s == 1 ? Color.white : Color.grey;
        int m = PlayerPrefs.GetInt("music", 1);
        music.color = m == 1 ? Color.white : Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMusic()
    {
        int m = PlayerPrefs.GetInt("music", 1);
        m++;
        m %= 2;
        music.color = m == 1 ? Color.white : Color.grey;
        PlayerPrefs.SetInt("music", m);
        PlayerPrefs.Save();
        SoundManager.MusicVolume = m;
    }

    public void toggleSounds()
    {
        int s = PlayerPrefs.GetInt("sounds", 1);
        s++;
        s %= 2;
        sounds.color = s == 1 ? Color.white : Color.grey;
        PlayerPrefs.SetInt("sounds", s);
        PlayerPrefs.Save();
        SoundManager.SoundVolume = s;

    }

    public void goBack()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("last", 2));
    }
}
