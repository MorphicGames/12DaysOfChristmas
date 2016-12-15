using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : NetworkBehaviour {

    public Canvas inventoryCanvas;

    public Text snowballAmount;
    public Text presentAmount;
    public Text fuelAmount;

    public Weapon[] playerWeapons = new Weapon[3];

    [SyncVar(hook = "UpdateSnowballs")]
    public int snowballCount;

    [SyncVar(hook = "UpdatePresents")]
    public int presentCount;

    [SyncVar(hook = "UpdateFuel")]
    public int fuelCount;

    // Use this for initialization
    public override void OnStartServer() {
        inventoryCanvas.enabled = false;

        snowballCount = 1000;
        presentCount = 25;
        fuelCount = 500;

        SetInventoryText();
	}

    public void SetInventoryText()
    {
        snowballAmount.text = snowballCount.ToString();
        presentAmount.text = presentCount.ToString();
        fuelAmount.text = fuelCount.ToString();
    }

    public void UpdateSnowballs(int snowballCount)
    {
        snowballAmount.text = snowballCount.ToString();
    }

    public void UpdatePresents(int presentCount)
    {
        presentAmount.text = presentCount.ToString();
    }

    public void UpdateFuel(int fuelCount)
    {
        fuelAmount.text = fuelCount.ToString();
    }

    public void ToggleInventory(bool toggle)
    {
        inventoryCanvas.enabled = toggle;
    }
}
