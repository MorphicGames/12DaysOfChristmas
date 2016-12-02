using UnityEngine;
using System.Collections;

public class HealthPresentBox : PresentBox {

    public int healingAmount;

    public override Item OpenBox()
    {
        return new Fruitcake();
    }

}
