using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}