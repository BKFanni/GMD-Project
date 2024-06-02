using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private GameObject instance;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "mainMenu"){
            Destroy(gameObject);
        }
    }
}
