using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetMessage : MonoBehaviour
{
    private TextMeshProUGUI _message;

    public void InitStart()
    {
        _message = GetComponent<TextMeshProUGUI>();
        Debug.Log(_message.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string s)
    {
        _message.SetText(s);
    }
}
