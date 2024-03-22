using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Scene scene;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync("Level2");
        }
    }
}
