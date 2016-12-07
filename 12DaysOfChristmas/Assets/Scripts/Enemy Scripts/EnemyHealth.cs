using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class EnemyHealth : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar]
    public int currentHealth = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Snowball")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //Destroy Object on Server, Update Clients
            PresentFactory pf = FindObjectOfType<PresentFactory>();
            pf.CmdMakePresent(this.gameObject);
        }
    }
}
