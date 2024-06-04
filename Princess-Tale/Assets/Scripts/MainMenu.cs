
//using System.Reflection;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
     DontDestroy[] dontDestroys;
     public GameObject pauseCanvas;
     public GameObject gameOverCanvas;
     public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroys = (DontDestroy[]) GameObject.FindObjectsOfType(typeof(DontDestroy));
        isPaused = false;
    }

    public void playGame()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ReloadSceneMainMenu()
    {
            SceneManager.LoadSceneAsync(0);
            Time.timeScale = 1f;
            isPaused = false;
            gameOverCanvas.SetActive(false);
    }
    public void goToSettings()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitApp()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
            foreach (DontDestroy dontDestroy in dontDestroys)
            {
                Destroy(dontDestroy.gameObject);
            }
            SceneManager.LoadSceneAsync(2);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        isPaused = true;
    }

    public void ContinueCurrentGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        isPaused = false;
        
    }



}
