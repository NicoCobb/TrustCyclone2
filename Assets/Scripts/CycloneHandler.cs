using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloneHandler : RaycastController {

	public LayerMask passengerMask;
	public LayerMask visibilityMask;
	public LayerMask boxMask;
	ParticleSystem ps;

	public float timeToJumpApex = .4f;
	public float maxJumpHeight = 4f;
	public float visibilityCircleSize = 2f;

	public bool controlX = false;
    public bool up = true;
	public float xVelocity = 1f;

	float gravity;
	float maxJumpVelocity;

	// Use this for initialization
	public override void Start () {
		base.Start ();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

		ps = gameObject.GetComponentInParent<ParticleSystem> ();
		var em = ps.emission;
		em.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateRaycastOrigins ();

		CheckCarried ();

		CheckVisibility ();

	}

	void CheckCarried() {
		float rayLength = skinWidth;

		for (int i = 0; i < verticalRayCount; i ++) {
			Vector2 rayOrigin = raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i);

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);
			RaycastHit2D boxes = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, boxMask);

			if (hit) {
                if (up) hit.transform.GetComponent<Player>().velocity.y = maxJumpVelocity;
                else if (!up) hit.transform.GetComponent<Player>().velocity.y = maxJumpVelocity * -1;

				if (controlX) {
					hit.transform.GetComponent<Player> ().velocity.x = xVelocity;
				}
			}

			if (boxes) {
				if (up) boxes.transform.GetComponent<BoxHandler>().velocity.y = maxJumpVelocity;
				else if (!up) boxes.transform.GetComponent<BoxHandler>().velocity.y = maxJumpVelocity * -1;

				if (controlX) {
					boxes.transform.GetComponent<BoxHandler> ().velocity.x = xVelocity;
				}
			}

			Debug.DrawRay(rayOrigin, Vector2.up ,Color.red);
		}
	}

	void CheckVisibility() {
		Vector2 rayOrigin = raycastOrigins.center;
		Collider2D collider = Physics2D.OverlapCircle(rayOrigin, visibilityCircleSize, visibilityMask);

		if (collider) {
			var em = ps.emission;
			em.enabled = true;
		}
		if (!collider) {
			var em = ps.emission;
			em.enabled = false;
		}
	}

	void OnDrawGizmos() {
		Vector2 rayOrigin = raycastOrigins.center;

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (rayOrigin, visibilityCircleSize);
	}
}
