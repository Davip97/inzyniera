using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
	public GameObject PauseUI;
	private bool paused = true;

	void Start()
	{

		PauseUI.SetActive(true);

	}

	void Update()
	{
		if(paused)
		{
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		if(!paused)
		{
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		paused = false;
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);

	}
	public void StartLevel()
	{
		Application.LoadLevel(1);
	}

	public void Quit()
	{
		Application.Quit();

	}
 
    
}