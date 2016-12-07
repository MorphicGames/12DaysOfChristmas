using UnityEngine;
using System.Collections;

public class CoalPresentBox : PresentBox {

    public override Item OpenBox()
    {
        int amount = Random.Range(1, 100);
        return new Coal(amount);
    }

}
