using UnityEngine;
using System.Collections;

public class HealthPresentBox : PresentBox {

    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision Registered");

        GameObject hit = col.gameObject;
        if (hit.name != "RobPlayerPrefab(Clone)")
            return;

        PlayerHealth pHealth = hit.GetComponent<PlayerHealth>();
        if (pHealth)
        {
            //Debug.Log("Player Healed");
            pHealth.Heal(OpenBox());
            Destroy(this.gameObject);
        }
    }

    public override int OpenBox()
    {
        int healingAmount = Random.Range(10, 50);
        return healingAmount;
    }

}
