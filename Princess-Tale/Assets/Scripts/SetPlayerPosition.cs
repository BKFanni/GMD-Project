using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerPosition : MonoBehaviour
{
    
    [SerializeField] private Vector3 startPos;
 
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = startPos;
    }
}
