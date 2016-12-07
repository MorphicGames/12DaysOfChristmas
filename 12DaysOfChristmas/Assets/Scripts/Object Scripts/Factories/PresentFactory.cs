using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PresentFactory : NetworkBehaviour
{
    public List<GameObject> presentBoxPrefabs;

    private enum PresentType
    {
        CAKE,
        AMMO
    }

    [Command]
    public void CmdMakePresent(GameObject gObject)
    {
        PresentType pBType = (PresentType)UnityEngine.Random.Range(0, 2);
        int pBoxModel = UnityEngine.Random.Range(0, presentBoxPrefabs.Count);

        GameObject Box = (GameObject)Instantiate(presentBoxPrefabs[pBoxModel], gObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f), gObject.transform.rotation);

        switch (pBType)
        {
            case (PresentType.AMMO):
                {
                    //Create Ammo Box
                    AmmoPresentBox aBox = Box.AddComponent<AmmoPresentBox>();
                    aBox.name = "Ammo Box";
                    aBox.GetComponent<NetworkIdentity>().serverOnly = true;
                    break;
                }
            case (PresentType.CAKE):
                {
                    //Create Cake Box
                    HealthPresentBox hBox = Box.AddComponent<HealthPresentBox>();
                    hBox.name = "Health Box";
                    hBox.GetComponent<NetworkIdentity>().serverOnly = true;
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
