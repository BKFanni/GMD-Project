using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class MainMenuNavigation : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public TMP_InputField nicknameInputField;
    public Button settingsButton;

    private List<Selectable> uiElements;
    private int currentElementIndex = 0;

    // Joystick axis and button mapping
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string activateButton = "Submit"; // Enter or space equivalent

    private float verticalInput;
    private bool isVerticalPressed;

    void Start()
    {
        // Initialize the list of UI elements in the desired navigation order
        uiElements = new List<Selectable> { nicknameInputField, settingsButton, playButton, quitButton };

        // Optionally, highlight the first element
        if (uiElements.Count > 0)
        {
            HighlightElement(uiElements[currentElementIndex]);
        }
    }

    void Update()
    {
        verticalInput = Input.GetAxis(verticalAxis);
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
            // Simulate button click or focus input field
            if (uiElements.Count > 0)
            {
                var currentElement = uiElements[currentElementIndex];

                if (currentElement is Button button && button.interactable)
                {
                    ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
                else if (currentElement is TMP_InputField inputField)
                {
                    inputField.ActivateInputField();
                }
            }
        }
    }

    void Navigate(int direction)
    {
        // Remove highlight from the current element
        HighlightElement(uiElements[currentElementIndex], false);

        // Update the current element index
        currentElementIndex = (currentElementIndex + direction + uiElements.Count) % uiElements.Count;

        // Highlight the new element
        HighlightElement(uiElements[currentElementIndex]);
    }

    void HighlightElement(Selectable element, bool highlight = true)
    {
        // Add logic to highlight the element (e.g., change color, scale, etc.)
        if (element is Button button)
        {
            Color color = highlight ? Color.yellow : Color.white;
            button.GetComponent<Image>().color = color;
        }
        else if (element is TMP_InputField inputField)
        {
            Color color = highlight ? Color.yellow : Color.white;
            inputField.textComponent.color = color;
        }
    }
}
