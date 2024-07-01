using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{

    [SerializeField] Image star;
    [SerializeField] Sprite[] stars;
    [SerializeField] GameObject button;
    [SerializeField] Text text;
    private int level;


    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level", 0);
        int score = PlayerPrefs.GetInt("score", 0);
        int current = PlayerPrefs.GetInt("current", 0);
        score -= level * 30;
        score /= 10;
        if (score>0)
        { 
            print(score);
            star.sprite = stars[Mathf.Min(3, score)];
            text.text = "LEVEL " + (level + 1) + "\nCOMPLETE";
            current = Mathf.Max(current, level + 1);
            current = Mathf.Min(19, current);
            PlayerPrefs.SetInt("current", current);
            score = Mathf.Max(score, PlayerPrefs.GetInt("score" + level, -1));
            PlayerPrefs.SetInt("score" + level, score);
            PlayerPrefs.Save();
        } else
        {
            button.SetActive(current>level);
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene(2);
    }
    public void again() {
        SceneManager.LoadScene(7);
    }
    public void next()
    {
        PlayerPrefs.SetInt("level", level + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(7);
    }

}
