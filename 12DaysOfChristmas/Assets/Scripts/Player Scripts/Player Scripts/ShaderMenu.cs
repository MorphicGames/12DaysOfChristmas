using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShaderMenu : MonoBehaviour {

    public Canvas shaderMenu;

    public GameObject targetBody;

    public Material glowShader;
    public Material cellShader;

	public Button shaderGlowButton;
	public Button shaderCellButton;

	// Use this for initialization
	void Start () {
        //shaderGlowButton.onClick.AddListener(ApplyGlowShader);
        //shaderCellButton.onClick.AddListener(ApplyCellShader);

        shaderMenu.enabled = false;
    }

    public void ApplyGlowShader()
    {
        targetBody.GetComponent<Renderer>().material = glowShader;
        ToggleVisibility(false);
    }

    public void ApplyCellShader()
    {
        targetBody.GetComponent<Renderer>().material = cellShader;
        ToggleVisibility(false);
    }

    public void ToggleVisibility(bool toggle)
    {
        if (toggle)
        {
            shaderMenu.enabled = true;
        }
        else
        {
            shaderMenu.enabled = false;
        }
    }
}
