using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SetTimer _timer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        Time.timeScale = 1;
        _timer.ClickPlay();
    }
}
