using UnityEngine;
using System.Collections;

public class ExplodingPresent : MonoBehaviour {

    //Exploding Present Script
    void OnCollisionEnter(Collision collision)
    {
        //Get Collison GameObject
        GameObject hit = collision.gameObject;

        //Try to get Enemy Health Component from GameObject
        EnemyHealth eHealth = hit.GetComponent<EnemyHealth>();
        if (eHealth != null)
        {
            //If it exists, Enemy Takes Damage and Destroy Present, then get out of Method
            eHealth.TakeDamage(25);
            Destroy(this.gameObject);
            return;
        }

        //Try to get Player Health Component from GameObject
        PlayerHealth pHealth = hit.GetComponent<PlayerHealth>();
        if (pHealth != null)
        {
            //If it exists, Player Takes Damage and Destroy Present, then get out of Method
            pHealth.TakeDamage(10);
            Destroy(this.gameObject);
            return;
        }
    }
}
