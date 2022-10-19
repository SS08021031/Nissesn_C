using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Nissensai2022.Runtime;


public class TotalScore : MonoBehaviour
{
    public Text scoreText;
    public static ResultRank rank = ResultRank.E;

    int score;
    // Start is called before the first frame update
    void Start()
    {
        rank = ResultRank.E;
        score = Timer.getscore();
        Debug.Log(score);
        if (score > 800)

            rank = ResultRank.A;
        else if (score > 600)
            rank = ResultRank.B;
        else if (score > 400)
            rank = ResultRank.C;
        else if (score > 200)
            rank = ResultRank.D;
        else if (score > 0)
            rank = ResultRank.E;
        scoreText.text = "Result" + rank;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Nissensai.SendResult(rank);
        }


    }





}



