using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    [SerializeField] Text bigScore;

    public void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            bigScore.text = "Best Score : "+MainUIManager.Instance.highScoreHolder+" : "+MainUIManager.Instance.currentHighScore;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            inputName.text = MainUIManager.Instance.highScoreHolder;
        }
    }

    public void onStart()
    {
        MainUIManager.Instance.playerName = (inputName.text != "Enter Name") ? inputName.text : "Player";
        SceneManager.LoadScene(1);
    }

    public void onEnd()
    {
        bigScore.text = "Best Score : " + MainUIManager.Instance.highScoreHolder + " : " + MainUIManager.Instance.currentHighScore;
    }
}
