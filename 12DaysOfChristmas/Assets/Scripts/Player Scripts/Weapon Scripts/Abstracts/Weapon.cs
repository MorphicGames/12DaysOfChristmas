using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Weapon : NetworkBehaviour {

    public virtual void Hide(bool toggle)
    {
        Debug.Log("Unimplimented");
    }

    public virtual void Fire(PlayerInventory playerInv)
    {
        Debug.Log("Unimplimented");
    }

}
