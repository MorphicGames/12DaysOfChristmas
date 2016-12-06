using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHUDController : MonoBehaviour {

    public Slider healthBar;

    public GameObject target;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = target.GetComponent<PlayerHealth>();

        healthBar.value = healthBar.maxValue = playerHealth.health;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = playerHealth.health;
	}
}
