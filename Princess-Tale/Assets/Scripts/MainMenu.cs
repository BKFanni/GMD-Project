
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
     DontDestroy[] dontDestroys;
    // Start is called before the first frame update
    void Start()
    {
        dontDestroys = (DontDestroy[]) GameObject.FindObjectsOfType(typeof(DontDestroy));
        ClearLog();
    }
    public void ClearLog()
    {
    var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    var type = assembly.GetType("UnityEditor.LogEntries");
    var method = type.GetMethod("Clear");
    method.Invoke(new object(), null);
    }
    public void playGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0);
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
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
