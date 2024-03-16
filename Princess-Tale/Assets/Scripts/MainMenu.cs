
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitApp()
    {
        Application.Quit();
    }

}
