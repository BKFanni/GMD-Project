using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOverMenuNavigation : MonoBehaviour
{
    public Button retryButton;
    public Button quitButton;
    private Button[] buttons; // Array of buttons in the game over menu
    private int currentButtonIndex = 0;

    // Input axis name for navigation
    public string horizontalAxis = "Horizontal";

    // Configuration for input sensitivity
    public float inputThreshold = 0.5f; // Threshold for detecting input direction
    public float inputCooldown = 0.2f; // Cooldown period between consecutive inputs
    private float lastInputTime = 0f; // Time of the last input

    void Start()
    {
        buttons = new Button[] { retryButton, quitButton };

        if (buttons.Length > 0)
        {
            SetButtonNavigation();
            HighlightButton(buttons[currentButtonIndex]);
            EventSystem.current.SetSelectedGameObject(buttons[currentButtonIndex].gameObject);
        }
    }

    void Update()
    {
        // Check for horizontal input and cooldown period
        if (Time.unscaledTime - lastInputTime > inputCooldown)
        {
            float horizontalInput = Input.GetAxisRaw(horizontalAxis);

            if (horizontalInput > inputThreshold)
            {
                Navigate(1); // Navigate right
                lastInputTime = Time.unscaledTime; // Update last input time
            }
            else if (horizontalInput < -inputThreshold)
            {
                Navigate(-1); // Navigate left
                lastInputTime = Time.unscaledTime; // Update last input time
            }
        }

        // Process button clicks
        if (Input.GetButtonDown("Submit"))
        {
            buttons[currentButtonIndex].onClick.Invoke(); // Simulate button click
        }
    }

    void Navigate(int direction)
    {
        // Remove highlight from the current button
        HighlightButton(buttons[currentButtonIndex], false);

        // Update the current button index
        currentButtonIndex = (currentButtonIndex + direction + buttons.Length) % buttons.Length;

        // Highlight the new button
        HighlightButton(buttons[currentButtonIndex]);

        // Set the new selected button in the Event System
        EventSystem.current.SetSelectedGameObject(buttons[currentButtonIndex].gameObject);
    }

    void HighlightButton(Button button, bool highlight = true)
    {
        // Change color to highlight or normal
        ColorBlock colors = button.colors;
        colors.normalColor = highlight ? Color.yellow : Color.white;
        colors.selectedColor = highlight ? Color.yellow : Color.white;
        colors.highlightedColor = highlight ? Color.yellow : Color.white;
        button.colors = colors;
    }

    // Method to set up button navigation
    void SetButtonNavigation()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Navigation nav = buttons[i].navigation;
            nav.mode = Navigation.Mode.Explicit;

            // Set up navigation to the next button
            int nextIndex = (i + 1) % buttons.Length;
            nav.selectOnRight = buttons[nextIndex];

            // Set up navigation to the previous button
            int prevIndex = (i - 1 + buttons.Length) % buttons.Length;
            nav.selectOnLeft = buttons[prevIndex];

            // Apply navigation settings to the button
            buttons[i].navigation = nav;
        }
    }
}
