using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;

	public Button shaderButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		//shaderButton.onClick.AddListener(OpenShaderMenu);
		//quitButton.onClick.AddListener(QuitGame);

        pauseMenu.enabled = false;
    }

	public void OpenShaderMenu()
	{
        this.GetComponent<ShaderMenu>().ToggleVisibility(true);
        this.ToggleVisibility(false);
	}

	public void QuitGame()
	{
        Application.Quit();
	}
	
	public void ToggleVisibility(bool toggle)
	{
		if (toggle)
		{
			pauseMenu.enabled = true;
		}
		else
		{
			pauseMenu.enabled = false;
		}
	}	
}
