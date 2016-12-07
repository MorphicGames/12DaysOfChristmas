using UnityEngine;
using System.Collections;

public class PresentLauncher : Weapon {

    public float projectileSpeed;

    public Rigidbody presentPrefab;
    public Transform projectileSpawn;

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

    public override void Fire()
    {
        Rigidbody proj = (Rigidbody)Instantiate(presentPrefab, projectileSpawn.position, projectileSpawn.rotation);
        proj.AddForce(projectileSpawn.transform.forward * projectileSpeed, ForceMode.Impulse);
        Destroy(proj.gameObject, 2);
    }

}
