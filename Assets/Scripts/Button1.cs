using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{

    [SerializeField] int level;
    [SerializeField] Image[] stars;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = (level + 1).ToString();
        int score = PlayerPrefs.GetInt("score" + level, -1);
        int current = PlayerPrefs.GetInt("current", 0);
        Button button = GetComponent<Button>();
        button.interactable = (current>=level);
        for (int i = 0; i < stars.Length; i++) stars[i].sprite = off;
        for(int i = 0;i<score;i++)
        {
            stars[i].sprite = on;
        }
    }

    public void onClick()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene(7);
    }
}
