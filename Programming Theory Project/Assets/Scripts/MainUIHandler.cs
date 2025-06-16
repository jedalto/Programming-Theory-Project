using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    public GameObject GameOverDisplay;

    void Start()
    {
        DisplayGameOver();
    }

    public void DisplayGameOver()
    {
        GameOverDisplay.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
