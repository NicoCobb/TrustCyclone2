using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCheck : RaycastController {

    static public bool isOpen = false;
    public Vector2 exitBoxSize;
    public LayerMask exitMask;

    Animator anim;
    
	// Use this for initialization
	public override void Start () {
        anim = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRaycastOrigins();

		if(isOpen)
        {
            CheckExitCondition();
            anim.SetBool("isOpen", true);
        }

        if(!isOpen)
        {
            anim.SetBool("isOpen", false);
        }
	}

    void CheckExitCondition()
    {
        Vector2 rayOrigin = raycastOrigins.center;
        Collider2D collider = Physics2D.OverlapBox(rayOrigin, exitBoxSize, exitMask);

        if (collider)
        { 
            SceneManager.LoadScene(this.gameObject.scene.buildIndex + 1);
        }
    }

    void OnDrawGizmos()
    {
        Vector2 rayOrigin = raycastOrigins.center;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rayOrigin, new Vector3(exitBoxSize.x, exitBoxSize.y, 0f));
    }
}
