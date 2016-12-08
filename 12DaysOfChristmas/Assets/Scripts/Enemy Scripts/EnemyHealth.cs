using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class EnemyHealth : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar]
    public int currentHealth = 0;

    GameProgression gp;

    void Start()
    {
        gp = GameObject.FindGameObjectWithTag("GameProgression").GetComponent<GameProgression>();
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Snowball")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            //Destroy Object on Server, Update Clients


            PresentFactory pf = FindObjectOfType<PresentFactory>();
            pf.CmdMakePresent(this.gameObject);

            NetworkServer.Destroy(gameObject);
            gp.numEnemiesLeft--;
        }
    }
}
