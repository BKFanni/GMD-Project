
using UnityEngine;
using UnityEngine.SceneManagement;

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
