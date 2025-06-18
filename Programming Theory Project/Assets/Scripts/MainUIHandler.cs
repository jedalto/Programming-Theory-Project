using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    public GameObject GameOverDisplay;
    public List<string> fruits;
    public List<TextMeshProUGUI> activeIngredients;
    private List<string> currentIngredients;

    private SpawnManager spawnManager;
    private PlayerController playerController;

    void Start()
    {
        currentIngredients = new List<string>();
        ChooseThreeRandomFruits();
        spawnManager = FindObjectOfType<SpawnManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //CheckGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ChooseThreeRandomFruits()
    {
        for (int i = 0; i < activeIngredients.Count; i++)
        {
            int randomIndex = Random.Range(0, fruits.Count);
            activeIngredients[i].text = fruits[randomIndex];
            currentIngredients.Add(fruits[randomIndex]);
            AddIngredient(fruits[randomIndex]);
        }
    }

    void GameOver()
    {
        GameOverDisplay.SetActive(true);
        spawnManager.GameOver();
        playerController.GameOver();
    }

    public bool CheckGameOver(string ingredient)
    {
        int totalChangesAllowed = 1;
        bool isNeeded = false;
        for (int i = 0; i < currentIngredients.Count; i++)
        {
            if (currentIngredients[i] == ingredient && totalChangesAllowed > 0)
            {
                currentIngredients.RemoveAt(i);
                isNeeded = true;

                foreach (TextMeshProUGUI j in activeIngredients)
                {
                    if (j.text == ingredient && totalChangesAllowed > 0 && j.color != Color.green)
                    {
                        j.color = Color.green;
                        totalChangesAllowed--;
                    }
                        
                }
            }
        }

        if (currentIngredients.Count <= 0)
        {
            GameOver();
        }

        return isNeeded;
    }

    public void AddIngredient(string ingredient)
    {
        
        foreach (TextMeshProUGUI j in activeIngredients)
        {
            //int totalChangesAllowed = 1;
            if (j.text == ingredient && j.color == Color.green)
            {
                currentIngredients.Add(ingredient);
                j.color = Color.red;
                //totalChangesAllowed--;
                break;
            }
        }
    }
}
