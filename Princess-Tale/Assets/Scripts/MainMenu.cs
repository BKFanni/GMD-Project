
//using System.Reflection;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
     DontDestroy[] dontDestroys;
     public GameObject canvas;
     public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroys = (DontDestroy[]) GameObject.FindObjectsOfType(typeof(DontDestroy));
        isPaused = false;
        //ClearLog();
    }
    /*public void ClearLog()
    {
    var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    var type = assembly.GetType("UnityEditor.LogEntries");
    var method = type.GetMethod("Clear");
    method.Invoke(new object(), null);
    }*/
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
            foreach (DontDestroy dontDestroy in dontDestroys)
            {
                Destroy(dontDestroy.gameObject);
            }
            SceneManager.LoadSceneAsync(0);
            Time.timeScale = 1f;
            isPaused = false;
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
        canvas.SetActive(true);
        isPaused = true;
    }

    public void ContinueCurrentGame()
    {
        Time.timeScale = 1f;
        canvas.SetActive(false);
        isPaused = false;
        
    }



}
