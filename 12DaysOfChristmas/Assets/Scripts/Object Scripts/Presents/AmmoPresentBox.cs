using UnityEngine;
using System.Collections;

public class AmmoPresentBox : PresentBox {

    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision Registered");

        GameObject hit = col.gameObject;

        if (hit.name != "RobPlayerPrefab(Clone)")
            return;

        PlayerInventory pInv = hit.GetComponent<PlayerInventory>();
        if (pInv)
        {
            //Debug.Log("Player has Inventory!");
            int choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    {
                        pInv.snowballCount += OpenBox();
                        break;
                    }
                case 1:
                    {
                        pInv.presentCount += OpenBox();
                        break;
                    }
                case 2:
                    {
                        pInv.fuelCount += OpenBox();
                        break;
                    }
            }
            Destroy(this.gameObject);
        }
    }

    public override int OpenBox()
    {
        int ammoAmount = Random.Range(5, 20);
        return ammoAmount;
    }


}
