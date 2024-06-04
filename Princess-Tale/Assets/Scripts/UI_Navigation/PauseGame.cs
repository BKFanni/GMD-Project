using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Reference to the pause menu canvas
    public PauseMenuNavigation pauseMenuNavigation; // Reference to the PauseMenuNavigation script
    public string joystickButton = "Pause"; // Assign the joystick button for pausing the game

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown(joystickButton))
        {
            if (!isPaused)
            {
                Pause();
                
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        pauseMenuCanvas.SetActive(true); // Show the pause menu canvas
        pauseMenuNavigation.SetMenuActive(true); // Activate the pause menu navigation
        Time.timeScale = 0; // Pause the game
    }

}
