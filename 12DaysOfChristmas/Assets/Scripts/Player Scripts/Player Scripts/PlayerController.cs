using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

	// Use this for initialization
	void Start ()
    {
        //Locks Cursor to Center of Screen
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Simple Movement Controls - Will Impliment Jumping Later

        float translation   = Input.GetAxis("Vertical") * movementSpeed;
        float strafe        = Input.GetAxis("Horizontal") * movementSpeed;

        translation *= Time.deltaTime;
        strafe      *= Time.deltaTime;

        transform.Translate(strafe, 0.0f, translation);

        //Return Cursor Input
        if (Input.GetButton("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
