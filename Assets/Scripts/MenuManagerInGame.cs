using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseMenu;

    public static MenuManagerInGame Instance;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    public void PauseButton()  
    {
        Time.timeScale = 0;      
        inGameScreen.SetActive(false);  
        pauseMenu.SetActive(true);
    }

    public void PlayButton() 
    {
        Time.timeScale = 1;
        Scope.instance.scopeOverlay.SetActive(false);
        Scope.instance.weaponCamera.SetActive(true);
        inGameScreen.SetActive(true); 
        pauseMenu.SetActive(false);
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;  
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name)); 
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
