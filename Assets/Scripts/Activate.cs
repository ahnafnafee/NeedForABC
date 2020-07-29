using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{

    public GameObject activateObject;
    public GameObject deactivateObject;
    
    void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeCanvas);
    }
    
    void ChangeCanvas()
    {
        activateObject.SetActive(true);
        deactivateObject.SetActive(false);
    }
}
