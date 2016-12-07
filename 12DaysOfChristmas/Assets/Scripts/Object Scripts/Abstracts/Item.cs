using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Item : NetworkBehaviour {

    public string itemName;
    public Texture2D itemIcon;
    public int amount;

}
