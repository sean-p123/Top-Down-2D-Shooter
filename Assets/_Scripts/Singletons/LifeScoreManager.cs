using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScoreManager : MonoBehaviour
{
    private int currentKills = 0;
    private int currentDeaths = 0;

    public int level = 0;

    public static LifeScoreManager instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void updateLevel()
    {
        level++;

    }

    public int GetLevel()
    {
        return level;
    }

    public void updateKills()
    {
        currentKills++;
    }
    public void updateDeaths()
    {
        currentDeaths++;
    }

    public int getKills()
    {
        return currentKills;
    }
    public int getDeaths()
    {
        return currentDeaths;
    }
}
