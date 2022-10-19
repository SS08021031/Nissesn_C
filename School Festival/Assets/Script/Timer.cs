using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    

    public static int score;
    public float limittime = 20.0f;
    public Text timerText;
    public Text scoreText;
    public bool isTimeUp;

    

    public static int getscore()
    {
        return score;
    }
    void Start()
    {
        score = 0;
        isTimeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "    " + score;
        //§ŒÀŽžŠÔ‚Æ‚Ì·‚ðŽæ“¾‚µ‘±‚¯‚é
        limittime -= Time.deltaTime;
        //•¶Žš—ñ‚É•ÏŠ·‚µ‚Ä•\Ž¦
        timerText.text = "Time: " + limittime.ToString("F1");

        if (0 >= limittime)
        {
            timerText.text = "0";
        }
        if (-1 >= limittime)
        {
            SceneManager.LoadScene("result");
        }

        if (Input.GetMouseButtonDown(1))
        {
            score += 100;
        }
    }
}
