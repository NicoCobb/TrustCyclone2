using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : RaycastController {

    Animator anim;

    public Vector2 plateBoxSize;
    public LayerMask plateMask;

    // Use this for initialization
    public override void Start () {
        base.Start();
        anim = GetComponent<Animator>();
        anim.SetBool("isPressed", false);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRaycastOrigins();
        CheckPlateCondition();
	}

    void CheckPlateCondition()
    {
        Vector2 rayOrigin = raycastOrigins.center;
        Collider2D collider = Physics2D.OverlapBox(rayOrigin, plateBoxSize, 0f, plateMask);

        if (collider)
        {
            anim.SetBool("isPressed", true);

			if (tag == "DoorPlate") {
				DoorControl.open = true;
			}
        }

        if(!collider)
        {
			anim.SetBool("isPressed", false);

			if (tag == "DoorPlate") {
				DoorControl.open = false;
			}
        }
    }

    void OnDrawGizmos()
    {
        Vector2 rayOrigin = raycastOrigins.center;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rayOrigin, new Vector3(plateBoxSize.x, plateBoxSize.y, 0f));
    }


}
