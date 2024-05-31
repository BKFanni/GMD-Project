using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class SettingsMenuNavigation : MonoBehaviour
{
    public Button goBackButton;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public TMP_Dropdown graphicsDropdown;

    private List<Selectable> uiElements;
    private int currentElementIndex = 0;

    // Joystick axis and button mapping
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string activateButton = "Submit"; // Enter or space equivalent
    public string selectDropdownButton = "Start"; // Button to select the dropdown

    private float verticalInput;
    private float horizontalInput;
    private bool isVerticalPressed;
    private bool isDropdownSelected;

    void Start()
    {
        // Initialize the list of UI elements in the desired navigation order
        uiElements = new List<Selectable> { goBackButton, volumeSlider, brightnessSlider, graphicsDropdown };

        // Optionally, highlight the first element
        if (uiElements.Count > 0)
        {
            HighlightElement(uiElements[currentElementIndex]);
        }
    }

    void Update()
    {
        verticalInput = Input.GetAxis(verticalAxis);
        horizontalInput = Input.GetAxis(horizontalAxis);
        bool activatePressed = Input.GetButtonDown(activateButton);
        bool selectDropdownPressed = Input.GetButtonDown(selectDropdownButton);

        if (verticalInput > 0 && !isVerticalPressed)
        {
            if (isDropdownSelected)
            {
                AdjustDropdownValue(-1); // Navigate dropdown options up
            }
            else
            {
                Navigate(-1); // Navigate up
            }
            isVerticalPressed = true;
        }
        else if (verticalInput < 0 && !isVerticalPressed)
        {
            if (isDropdownSelected)
            {
                AdjustDropdownValue(1); // Navigate dropdown options down
            }
            else
            {
                Navigate(1); // Navigate down
            }
            isVerticalPressed = true;
        }
        else if (verticalInput == 0)
        {
            isVerticalPressed = false;
        }

        if (selectDropdownPressed)
        {
            isDropdownSelected = !isDropdownSelected; // Toggle dropdown selection state
        }

        // Adjust value if the current element is a Slider
        if (!isDropdownSelected)
        {
            AdjustValue(horizontalInput);
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
        // Deselect dropdown if navigating away from it
        if (isDropdownSelected && uiElements[currentElementIndex] != graphicsDropdown)
        {
            isDropdownSelected = false;
        }

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
        else if (element is Slider slider)
        {
            Color color = highlight ? Color.yellow : Color.white;
            slider.GetComponentInChildren<Image>().color = color;
        }
        else if (element is TMP_Dropdown dropdown)
        {
            Color color = highlight ? Color.yellow : Color.white;
            dropdown.captionText.color = color;
        }
    }

    void AdjustValue(float direction)
    {
        if (direction != 0)
        {
            if (uiElements[currentElementIndex] is Slider slider)
            {
                slider.value += direction * Time.deltaTime; // Adjust slider value
            }
        }
    }

    void AdjustDropdownValue(float direction)
    {
        if (direction != 0)
        {
            int newValue = graphicsDropdown.value + (direction > 0 ? 1 : -1);
            graphicsDropdown.value = Mathf.Clamp(newValue, 0, graphicsDropdown.options.Count - 1); // Adjust dropdown value
        }
    }
}
