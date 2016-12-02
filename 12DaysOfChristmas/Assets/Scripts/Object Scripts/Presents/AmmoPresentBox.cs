using UnityEngine;
using System.Collections;

public enum AmmoType
{

}

public class AmmoPresentBox : PresentBox {

    public AmmoType ammoType;

    public override Item OpenBox()
    {
        return new Ammo();
    }


}
