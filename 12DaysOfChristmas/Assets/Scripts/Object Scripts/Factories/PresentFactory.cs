using UnityEngine;
using System.Collections;

public class PresentFactory
{

    private enum PresentType
    {
        COAL,
        CAKE,
        AMMO,
        WEAPON
    }

    public static void MakePresent(GameObject gObject)
    {
        PresentType pBType = (PresentType)UnityEngine.Random.Range(0, 4);

        switch (pBType)
        {
            case (PresentType.AMMO):
                {
                    //Create Ammo Box
                    break;
                }
            case (PresentType.CAKE):
                {
                    //Create Cake Box
                    break;
                }
            case (PresentType.COAL):
                {
                    //Create Coal Box
                    break;
                }
            case (PresentType.WEAPON):
                {
                    // Create Weapon Box
                    break;
                }
            default:
                {
                    //Something went wrong
                    break;
                }
        }
    }

}
