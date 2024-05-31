using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneNavigation : MonoBehaviour
{
    public Button quitButton;
    public Button otherButton;

    // Joystick axis and button mapping
    public string verticalAxis = "Vertical";
    public string activateButton = "Submit"; // Enter or space equivalent

    private bool isVerticalPressed;
    private int currentButtonIndex = 0;
    private Button[] buttons;

    void Start()
    {
        buttons = new Button[] { otherButton, quitButton };

        if (buttons.Length > 0)
        {
            HighlightButton(buttons[currentButtonIndex]);
        }
    }

    void Update()
    {
        float verticalInput = Input.GetAxis(verticalAxis);
        bool activatePressed = Input.GetButtonDown(activateButton);

        if (verticalInput > 0 && !isVerticalPressed)
        {
            Navigate(-1); // Navigate up
            isVerticalPressed = true;
        }
        else if (verticalInput < 0 && !isVerticalPressed)
        {
            Navigate(1); // Navigate down
            isVerticalPressed = true;
        }
        else if (verticalInput == 0)
        {
            isVerticalPressed = false;
        }

        if (activatePressed)
        {
            if (buttons.Length > 0)
            {
                buttons[currentButtonIndex].onClick.Invoke(); // Simulate button click
            }
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
    }

    void HighlightButton(Button button, bool highlight = true)
    {
        // Change color to highlight or normal
        ColorBlock colors = button.colors;
        colors.normalColor = highlight ? Color.yellow : Color.white;
        button.colors = colors;
    }
}
