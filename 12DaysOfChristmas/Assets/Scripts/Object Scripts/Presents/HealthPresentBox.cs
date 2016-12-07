using UnityEngine;
using System.Collections;

public class HealthPresentBox : PresentBox {

    public override Item OpenBox()
    {
        int healingAmount = Random.Range(10, 50);
        return new Fruitcake(healingAmount);
    }

}
