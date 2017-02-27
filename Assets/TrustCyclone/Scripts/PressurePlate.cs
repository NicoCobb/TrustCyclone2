using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    Animator anim;
    bool isPressed = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //For when the box touches the button
    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Crate" || coll.gameObject.tag == "UnbreakableCrate") && !isPressed)
        {
            print("colliding");
            anim.SetBool("boxOn", true);
            isPressed = true;
            ExitCheck.isOpen = true;
        }
    }

    //For when the box comes off the button
    void OnCollisionExit2D(Collision2D coll)
    {
        if((coll.gameObject.tag == "Crate" || coll.gameObject.tag == "UnbreakableCrate") && isPressed)
        {
            print("not colliding");
            anim.SetBool("boxOn", false);
            isPressed = false;
            ExitCheck.isOpen = false;
        }
    } 
}
