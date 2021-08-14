using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_panel : MonoBehaviour
{
	#region Singlton:Shop
	public static Menu_panel Instance;
	#endregion
	[SerializeField] GameObject OptionPanel;
	public GameObject SoundPanel;
	//public GameObject StartGameCanvans;



	public void StartGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void resume()
    {
		OptionPanel.SetActive(false);
		Time.timeScale = 1;
    }

	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void quit(int sceneANumber)

	{
		sceneANumber = 1;
		SceneManager.LoadScene(sceneANumber);

	}
	public void OpenShop()
	{
		OptionPanel.SetActive(true);
	}

	public void CloseShop()
	{
		OptionPanel.SetActive(false);
	}

	public void OpenOptons()
	{
		SoundPanel.SetActive(true);
	}

	public void CloseOptions()
	{
		SoundPanel.SetActive(false);
	}

}
