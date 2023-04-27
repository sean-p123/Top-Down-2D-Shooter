using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    int currentSceneIndex;

    public TMP_Text killsText;
    public TMP_Text deathsText;

    private int kills;
    private int deaths;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (killsText != null || deathsText != null)
        {
            kills = LifeScoreManager.instance.getKills();
            deaths = LifeScoreManager.instance.getDeaths();
            if (killsText != null || deathsText != null)
            {
                killsText.text = "Kills : " + kills;
                deathsText.text = "Deaths : " + deaths;
            }
            if (LifeScoreManager.instance.GetLevel() == 3)
            {
                Debug.Log("level: " + LifeScoreManager.instance.GetLevel());
                WinGame();
            }
        }

        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }

    public void NextWave()
    {
        if(currentSceneIndex == 2)
        {
            Debug.Log("Game Won");
        }
        currentSceneIndex++;
        
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }

    public void WinGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
