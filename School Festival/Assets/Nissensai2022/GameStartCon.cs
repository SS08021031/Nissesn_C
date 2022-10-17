using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Nissensai2022.Runtime;


public class GameStartCon : MonoBehaviour
{


    public void OnGameStart()
    {
        SceneManager.LoadScene("Ingame");
        Debug.Log("Log");


    }

    public void OnGameStop()
    {
        SceneManager.LoadScene("Title");
        //ResultRank result = ResultRank.A;
        //Nissensai.SendResult(result);
        Debug.Log("result");
    }

}
