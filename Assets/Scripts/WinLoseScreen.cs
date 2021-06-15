using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public delegate void WinEnemyAction();

    public static WinLoseScreen Instance;

    [SerializeField]
    private int enemyCount;

    
    public GameObject winScreen;
    public GameObject loseScreen;

    private bool isGameEnd = false;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        Enemy.EnemyDead += OnEnemyDead;
    }

    private void OnDisable()
    {
        Enemy.EnemyDead -= OnEnemyDead;
    }

    private void OnEnemyDead()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            //win;
            Win();
        }
    }

    private void Win()
    {
        isGameEnd = true;
        Scope.instance.scopeOverlay.SetActive(false);
        winScreen.gameObject.SetActive(true);
        MenuManagerInGame.Instance.inGameScreen.SetActive(false);
        //Debug.Log("win");
    }

    public void Lose()
    {
        isGameEnd = true;
        Scope.instance.scopeOverlay.SetActive(false);
        loseScreen.gameObject.SetActive(true);
        MenuManagerInGame.Instance.inGameScreen.SetActive(false);
    }
    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));

    }

    public void SkipButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public bool GetisGameEnd()
    {
        return isGameEnd;
    }
}
