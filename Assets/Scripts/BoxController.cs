using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : RaycastController {

	float gravity;


	[HideInInspector]
	public Vector3 velocity;
	float velocityXSmoothing;

	public Player player;
	public LayerMask pushMask;

	Controller2D controller;

	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;


	public override void Start() {
		base.Start ();

		controller = GetComponent<Controller2D> ();

		velocity.x = 0;
	}

	void Update() {
		gravity = player.gravity;
		CalculateVelocity ();
		Vector2 placeholderInput = new Vector2 (0, 0);

		controller.Move (velocity * Time.deltaTime, placeholderInput);

		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}
	}

	void CalculateVelocity() {
		
		float targetVelocityX = 0;
		//horizontal check left
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;

		for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = raycastOrigins.bottomLeft;
			Vector2 rayOriginRight = raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, rayLength, pushMask);


			if (hit && hit.distance != 0) {
				targetVelocityX = hit.transform.GetComponent<Player>().velocity.x;
			}
		}

		//horizontal check right
		for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLength, pushMask);

			if (hit && hit.distance != 0) {
				if (targetVelocityX != 0) {
					targetVelocityX = hit.transform.GetComponent<Player> ().velocity.x;
				}
			}
		}



		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
	}
}
