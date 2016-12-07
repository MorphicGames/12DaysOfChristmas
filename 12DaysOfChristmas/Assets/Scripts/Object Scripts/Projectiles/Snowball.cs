using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour {

    //Snowball Collision Script
    void OnCollisionEnter(Collision collision)
    {
        //Get Collison GameObject
        GameObject hit = collision.gameObject;

        //Try to get Enemy Health Component from GameObject
        EnemyHealth eHealth = hit.GetComponent<EnemyHealth>();
        if (eHealth != null)
        {
            //If it exists, Enemy Takes Damage and Destroy Snowball, then get out of Method
            eHealth.TakeDamage(5);
            Destroy(this.gameObject);
            return;
        }

        //Try to get Player Health Component from GameObject
        PlayerHealth pHealth = hit.GetComponent<PlayerHealth>();
        if (pHealth != null)
        {
            //If it exists, Player Takes Damage and Destroy Snowball, then get out of Method
            pHealth.TakeDamage(1);
            Destroy(this.gameObject);
            return;
        }
        //If Collision is with any other Object, destory self
        Destroy(this.gameObject);
    }

}
