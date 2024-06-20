using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool started;
    public bool gameOver;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

    }
    private void Start()
    {
        gameOver = false;
    }
    public void GameStart()
    {
        UIManager.instance.StartUI(); 
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StartSpawning();
    }

    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StopSpawning();
        ScoreManager.instance.StopScoring();
        UIManager.instance.GameOver();
    }
}
