using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject settingsPanel;

	public void StartGame() {
		Debug.Log("Starting Game...");
		SceneManager.LoadScene(1);
	}

	public void OpenSettings() {
		Debug.Log("Opening Settings...");
		settingsPanel.SetActive(true);
	}

	public void CloseSettings() {
		Debug.Log("Closing Settings...");
		settingsPanel.SetActive(false);
	}

	public void ExitGame() {
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
