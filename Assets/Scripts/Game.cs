using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private bool left;
    private bool right;
    [SerializeField] Player playerScript;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject bombPrefab;
    // Start is called before the first frame update
    //float time = 90;
    public int count = 0;
    float timerSpawn = 0;
    private bool inval = true;
    private float speed = 0.15f;
    public int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("level", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(inval)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(2);
            }
            if (Time.timeSinceLevelLoad > timerSpawn)
            {
                timerSpawn += Random.Range(0.3f, 1.2f);
                int random = Random.Range(-10, 25);
                GameObject heart = Instantiate(random >= 0 ? heartPrefab : bombPrefab, transform, true);
                heart.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), 6, 0);
            }
            scoreText.text = "SCORE: " + count + "/" + (level * 30+30);
            if (left)
            {
                playerScript.Pos -= speed;
            }
            else if (right)
            {
                playerScript.Pos += speed;
            }
        }
    }

    public void levelDown()
    {
        left = true;
    }
    public void levelUp()
    {
        left = false;
    }

    public void rightDown()
    {
        right = true;
    }
    public void rightUp() { 
        right = false;
    }


    public void end()
    {
        inval = false;
        goEnd();
    }

    private void goEnd()
    {
        PlayerPrefs.SetInt("score", count);
        PlayerPrefs.Save();
        SceneManager.LoadScene(8);
    }


    public void goBack()
    {
        SceneManager.LoadScene(6);
    }

    public void goSettings()
    {
        PlayerPrefs.SetInt("last", 7);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }
}
