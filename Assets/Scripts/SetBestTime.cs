using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetBestTime : MonoBehaviour
{

    private TextMeshProUGUI _textTime;
    
    void Start()
    {
        _textTime = GetComponent<TextMeshProUGUI>();
        Debug.Log(_textTime);
    }

    void Update()
    {
        _textTime.SetText(BestTime.LowStrTime);
    }
}
