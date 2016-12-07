using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PresentBox : NetworkBehaviour {

    public virtual int OpenBox()
    {
        Debug.Log("Unimplimented");
        return 0;
    }

}
