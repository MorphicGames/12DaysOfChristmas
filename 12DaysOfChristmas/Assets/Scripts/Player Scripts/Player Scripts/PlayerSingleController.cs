using UnityEngine;
using System.Collections;

public class PlayerSingleController : MonoBehaviour
{

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

    public float movementSpeed;
    private float translation;
    private float strafe;

    // Use this for initialization
    void Start()
    {
        //Locks Cursor to Center of Screen
        Cursor.lockState = CursorLockMode.Locked;

        toggleInventory = false;
        toggleMenu = false;

        currentWeaponSlot = WeaponSlot.SLOT_ONE;

        ToggleWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Movement Input
        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float strafe = Input.GetAxis("Horizontal") * movementSpeed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0.0f, translation);

        //Get Weapon Switch Input
        if (Input.GetButtonDown("Slot1"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_ONE;
            ToggleWeapon();
            Debug.Log("Switch to Slot 1");
        }
        if (Input.GetButtonDown("Slot2"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_TWO;
            ToggleWeapon();
            Debug.Log("Switch to Slot 2");
        }
        if (Input.GetButtonDown("Slot3"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_THREE;
            ToggleWeapon();
            Debug.Log("Switch to Slot 3");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
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

    void ToggleWeapon()
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

    void FireWeapon()
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    //playerInventory.playerWeapons[0].Fire();
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    //playerInventory.playerWeapons[1].Fire();
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    //playerInventory.playerWeapons[2].Fire();
                    break;
                }
        }
    }
}
