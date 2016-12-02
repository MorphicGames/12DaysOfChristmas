using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentFactory : MonoBehaviour
{
    public static List<GameObject> presentBoxPrefabs;

    private enum PresentType
    {
        COAL,
        CAKE,
        AMMO
    }

    public static void MakePresent(GameObject gObject)
    {
        PresentType pBType = (PresentType)UnityEngine.Random.Range(0, 3);
        int pBoxModel = UnityEngine.Random.Range(0, presentBoxPrefabs.Count);

        GameObject Box = (GameObject)Instantiate(presentBoxPrefabs[pBoxModel], gObject.transform.position, gObject.transform.rotation);

        switch (pBType)
        {
            case (PresentType.AMMO):
                {
                    //Create Ammo Box
                    AmmoPresentBox aBox = Box.AddComponent<AmmoPresentBox>();
                    //Add Contents
                    aBox.ammoType = (AmmoType)UnityEngine.Random.Range(0, 4);
                    aBox.amount = UnityEngine.Random.Range(5, 20);
                    break;
                }
            case (PresentType.CAKE):
                {
                    //Create Cake Box
                    HealthPresentBox hBox = Box.AddComponent<HealthPresentBox>();
                    //Add Contents
                    hBox.healingAmount = UnityEngine.Random.Range(10, 50);
                    break;
                }
            case (PresentType.COAL):
                {
                    //Create Coal Box
                    CoalPresentBox cBox = Box.AddComponent<CoalPresentBox>();
                    //Add Contents
                    cBox.amount = UnityEngine.Random.Range(25, 100);
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
