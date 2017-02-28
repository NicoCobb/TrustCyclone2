using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControl : RaycastController {

	Animator anim;

	static public bool open = false;
	public Vector2 doorBoxSize;
	public LayerMask doorMask;

	// Use this for initialization
	void Start () {
		base.Start ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateRaycastOrigins();
		CheckPlateCondition();
		if (open) {
			anim.SetBool ("isOpen", true);
		} else
			anim.SetBool ("isOpen", false);
	}

	void CheckPlateCondition()
	{
		Vector2 rayOrigin = raycastOrigins.center;
		Collider2D collider = Physics2D.OverlapBox(rayOrigin, doorBoxSize, 0f, doorMask);

		if (collider)
		{
			if (open) {
				SceneManager.LoadScene (this.gameObject.scene.buildIndex + 1);
			}
		}
			
	}

	void OnDrawGizmos()
	{
		Vector2 rayOrigin = raycastOrigins.center;

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(rayOrigin, new Vector3(doorBoxSize.x, doorBoxSize.y, 0f));
	}

}
