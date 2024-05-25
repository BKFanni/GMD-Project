using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimator : MonoBehaviour
{
    private Animator animator;
    MainMenu mainMenuScript;

    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mainMenuScript = FindAnyObjectByType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = !mainMenuScript.isPaused;
    }
}
