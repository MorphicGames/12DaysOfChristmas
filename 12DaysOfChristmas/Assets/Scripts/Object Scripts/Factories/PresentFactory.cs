using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PresentFactory : NetworkBehaviour
{
    public List<GameObject> presentBoxPrefabs;

    private enum PresentType
    {
        COAL,
        CAKE,
        AMMO
    }

    [Command]
    public void CmdMakePresent(GameObject gObject)
    {
        PresentType pBType = (PresentType)UnityEngine.Random.Range(0, 3);
        int pBoxModel = UnityEngine.Random.Range(0, presentBoxPrefabs.Count);

        GameObject Box = (GameObject)Instantiate(presentBoxPrefabs[pBoxModel], gObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f), gObject.transform.rotation);

        switch (pBType)
        {
            case (PresentType.AMMO):
                {
                    //Create Ammo Box
                    AmmoPresentBox aBox = Box.AddComponent<AmmoPresentBox>();
                    aBox.amount = 1;
                    aBox.name = aBox.itemName = "Ammo Box";
                    break;
                }
            case (PresentType.CAKE):
                {
                    //Create Cake Box
                    HealthPresentBox hBox = Box.AddComponent<HealthPresentBox>();
                    hBox.amount = 1;
                    hBox.name = hBox.itemName = "Cake Box";
                    break;
                }
            case (PresentType.COAL):
                {
                    //Create Coal Box
                    CoalPresentBox cBox = Box.AddComponent<CoalPresentBox>();
                    cBox.amount = 1;
                    cBox.name = cBox.itemName = "Coal Box";
                    break;
                }
            default:
                {
                    Debug.Log("Please Check Factory, Something went Wrong.");
                    break;
                }
        }
    }

}
