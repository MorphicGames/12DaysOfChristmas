using UnityEngine;
using System.Collections;

public class Flamethrower : Weapon {

    public ParticleSystem Flame;

    public override void Hide(bool toggle)
    {
        if (toggle)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    public override void Fire(PlayerInventory playerInv, float deltaTime)
    {
        if (playerInv.fuelCount - 1 >= 0)
        {
            Flame.Play();
            playerInv.fuelCount -= 1;
        }
        else
        {
            Flame.Stop();
        }
    }

    public override void CeaseFire()
    {
        Flame.Stop();
    }
}
