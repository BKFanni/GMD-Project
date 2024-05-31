using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pauseMenuCanvas; // Reference to the pause menu canvas
    public Button[] pauseMenuButtons; // Array of buttons in the pause menu

    // Input button mapping
    public KeyCode pauseKeyCode = KeyCode.Escape; // Assign the button for pausing the game (e.g., KeyCode.Escape)
    public string joystickButton = "Pause"; // Assign the joystick button for pausing the game

    private int currentButtonIndex = 0;
    private bool isPaused = false;

    void Update()
    {
        if (!isPaused && (Input.GetKeyDown(pauseKeyCode) || Input.GetButtonDown(joystickButton)))
        {
            Pause(); // Pause the game
        }
        else if (isPaused)
        {
            // Navigate within pause menu if the game is paused
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                Navigate(verticalInput > 0 ? -1 : 1); // Navigate up for positive input, down for negative input
            }

            if (Input.GetButtonDown("Submit"))
            {
                pauseMenuButtons[currentButtonIndex].onClick.Invoke(); // Simulate button click
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        pauseMenuCanvas.SetActive(true); // Show the pause menu canvas
        HighlightButton(pauseMenuButtons[currentButtonIndex]); // Highlight the initial button
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
    }

    void Navigate(int direction)
    {
        // Remove highlight from the current button
        HighlightButton(pauseMenuButtons[currentButtonIndex], false);

        // Update the current button index
        currentButtonIndex = (currentButtonIndex + direction + pauseMenuButtons.Length) % pauseMenuButtons.Length;

        // Highlight the new button
        HighlightButton(pauseMenuButtons[currentButtonIndex]);
    }

    void HighlightButton(Button button, bool highlight = true)
    {
        // Change color to highlight or normal
        ColorBlock colors = button.colors;
        colors.normalColor = highlight ? Color.yellow : Color.white;
        button.colors = colors;
    }
}
