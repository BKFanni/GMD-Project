using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_NextScene : MonoBehaviour
{
    public string sceneName;
    public string colliderTag;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == colliderTag)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
