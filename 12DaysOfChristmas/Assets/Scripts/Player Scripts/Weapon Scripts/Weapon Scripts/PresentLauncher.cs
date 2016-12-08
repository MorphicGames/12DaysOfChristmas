using UnityEngine;
using System.Collections;

public class PresentLauncher : Weapon {

    public float projectileSpeed;

    public Rigidbody presentPrefab;
    public Transform projectileSpawn;

    private float elapsedTime;
    private float timeBetweenShots = 0.5f;

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
        elapsedTime += deltaTime;
        if (elapsedTime >= timeBetweenShots)
        {
            if (playerInv.presentCount - 1 >= 0)
            {
                Rigidbody proj = (Rigidbody)Instantiate(presentPrefab, projectileSpawn.position, projectileSpawn.rotation);
                proj.AddForce(projectileSpawn.transform.forward * projectileSpeed, ForceMode.Impulse);
                Destroy(proj.gameObject, 2);
                playerInv.presentCount -= 1;
            }
            elapsedTime = 0.0f;
        }
    }

}
