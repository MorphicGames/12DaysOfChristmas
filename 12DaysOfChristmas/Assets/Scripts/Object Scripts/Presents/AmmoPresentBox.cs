using UnityEngine;
using System.Collections;

public class AmmoPresentBox : PresentBox {

    public override Item OpenBox()
    {
        int ammoAmount = Random.Range(5, 20);
        Ammo.AmmoType tmpAmmoType = (Ammo.AmmoType)Random.Range(0, 3);
        return new Ammo(ammoAmount, tmpAmmoType);
    }


}
