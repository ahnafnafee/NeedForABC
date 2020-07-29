using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitOnClick : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);
    }
    
    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}