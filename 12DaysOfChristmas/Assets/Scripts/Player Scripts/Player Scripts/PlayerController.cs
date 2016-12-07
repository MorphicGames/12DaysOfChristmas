using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    private enum WeaponSlot
    {
        SLOT_ONE,
        SLOT_TWO,
        SLOT_THREE
    }

    private bool toggleInventory;
    private bool toggleMenu;

    private WeaponSlot currentWeaponSlot;

    public PlayerInventory playerInventory;

    public GameObject inventoryPrefab;
    public GameObject hudPrefab;

    public float movementSpeed;
    private float translation;
    private float strafe;

	// Use this for initialization
	void Start ()
    {
        //Locks Cursor to Center of Screen
        Cursor.lockState = CursorLockMode.Locked;

        //Creates Menus for Player
        GameObject pI = (GameObject)Instantiate(inventoryPrefab);
        GameObject hud = (GameObject)Instantiate(hudPrefab);

        //Setting values
        playerInventory.inventoryCanvas = pI.GetComponent<Canvas>();
        this.GetComponent<PlayerHealth>().healthBar = hud.GetComponentInChildren<Slider>();
        this.GetComponent<PlayerHealth>().healthBar.value = this.GetComponent<PlayerHealth>().health;

        //Sets Menu and Inventory Screens to be Off
        toggleInventory = false;
        toggleMenu = false;

        //Creates some Ammo for Player
        Ammo snowballs = new Ammo(100, Ammo.AmmoType.Snowball);
        Ammo fuel = new Ammo(60, Ammo.AmmoType.Fuel);
        Ammo presents = new Ammo(10, Ammo.AmmoType.Present);

        //Adds Starting Ammo to Player
        playerInventory.AddItem("Snowball", snowballs);
        playerInventory.AddItem("Coal", fuel);
        playerInventory.AddItem("PresentBoxes", presents);

        //Sets Weapon and Toggles Correct Weapon Slot
        currentWeaponSlot = WeaponSlot.SLOT_ONE;
        CmdToggleWeapon();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //Get Movement Input
        float translation   = Input.GetAxis("Vertical") * movementSpeed;
        float strafe        = Input.GetAxis("Horizontal") * movementSpeed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0.0f, translation);

        //Get Weapon Switch Input
        if (Input.GetButtonDown("Slot1"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_ONE;
            CmdToggleWeapon();
            Debug.Log("Switch to Slot 1");
        }
        if (Input.GetButtonDown("Slot2"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_TWO;
            CmdToggleWeapon();
            Debug.Log("Switch to Slot 2");
        }
        if (Input.GetButtonDown("Slot3"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_THREE;
            CmdToggleWeapon();
            Debug.Log("Switch to Slot 3");
        }
        if (Input.GetButtonDown("Slot4"))
        {
            PresentFactory pf = FindObjectOfType<PresentFactory>();
            pf.CmdMakePresent(this.gameObject);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CmdFireWeapon();
        }

        //Get Inventory Input
        if (Input.GetButtonDown("Inventory") && !toggleMenu)
        {
            if (!toggleInventory)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Opening Inventory");
                toggleInventory = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Closing Inventory");
                toggleInventory = false;
            }
            playerInventory.ToggleInventory(toggleInventory);
        }

        //Return Cursor Input
        if (Input.GetButtonDown("Cancel") && !toggleInventory)
        {
            if (!toggleMenu)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Opening Menu");
                toggleMenu = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Closing Menu");
                toggleMenu = false;
            }
        }
	}

    [Command]
    void CmdToggleWeapon()
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    playerInventory.playerWeapons[0].Hide(false);
                    playerInventory.playerWeapons[1].Hide(true);
                    playerInventory.playerWeapons[2].Hide(true);
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    playerInventory.playerWeapons[0].Hide(true);
                    playerInventory.playerWeapons[1].Hide(false);
                    playerInventory.playerWeapons[2].Hide(true);
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    playerInventory.playerWeapons[0].Hide(true);
                    playerInventory.playerWeapons[1].Hide(true);
                    playerInventory.playerWeapons[2].Hide(false);
                    break;
                }
        }
    }

    [Command]
    void CmdFireWeapon()
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    playerInventory.playerWeapons[0].Fire();
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    playerInventory.playerWeapons[1].Fire();
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    playerInventory.playerWeapons[2].Fire();
                    break;
                }
        }
    }
}
