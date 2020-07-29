using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeOnClick : MonoBehaviour
{
    public GameObject PauseMenuUI;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ResumeGame);
    }
    
    public void ResumeGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
