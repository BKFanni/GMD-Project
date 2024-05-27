using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Build.Content;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_NextScene : MonoBehaviour
{
    public string sceneName;
    public string colliderTag;
    public float delay = 3.0f; // Delay in seconds before loading the win scene
    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == colliderTag)
        {
            if (sceneName == "Win")
            {
                StartCoroutine(LoadSceneWithDelay());
            }
            else
            {
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
        playerHealth.currentHealth = playerHealth.maxHealth;
        playerHealth.currentLives = playerHealth.maxLives;
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delay);
        LoadScene();
    }
}
