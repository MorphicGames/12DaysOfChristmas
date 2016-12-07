using UnityEngine;
using System.Collections;

public class HealthPresentBox : PresentBox {

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision Registered");

        GameObject hit = col.gameObject;
        PlayerHealth pHealth = hit.GetComponent<PlayerHealth>();
        if (pHealth)
        {
            pHealth.Heal(OpenBox());
        }
    }

    public override int OpenBox()
    {
        int healingAmount = Random.Range(10, 50);
        return healingAmount;
    }

}
