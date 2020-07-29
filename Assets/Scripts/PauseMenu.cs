using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public SetTimer _timer;
	public GameObject PauseMenuUI;
	public static bool GameIsPaused = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		GameIsPaused = false;
	}

	private void Pause()
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}
}
