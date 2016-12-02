using UnityEngine;
using System.Collections;

public class CoalPresentBox : PresentBox {

    public override Item OpenBox()
    {
        return new Coal();
    }

}
