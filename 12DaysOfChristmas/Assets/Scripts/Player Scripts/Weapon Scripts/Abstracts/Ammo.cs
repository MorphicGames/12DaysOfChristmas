using UnityEngine;
using System.Collections;

public class Ammo : Item {

    public enum AmmoType
    {
        Snowball,
        Present,
        Fuel
    }

    private AmmoType m_Type;
    public AmmoType Type
    {
        get { return m_Type; }
    }


    public Ammo(int amount, AmmoType type)
    {
        this.amount = amount;
        m_Type = type;
    }

}
