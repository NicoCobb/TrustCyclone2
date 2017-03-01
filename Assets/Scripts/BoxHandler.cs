using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Moveable2D))]
public class BoxHandler : MonoBehaviour {

	float gravity;

	[HideInInspector]
	public Vector3 velocity;
	float velocityXSmoothing;

	public Player player;
	public LayerMask pushMask;

	Moveable2D controller;

	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	Vector2 startPosition;


	void Start() {
		controller = GetComponent<Moveable2D> ();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gravity = player.gravity;

		CalculateVelocity ();

		controller.Move (velocity * Time.deltaTime);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.x = 0;
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}

		if (transform.position.y < -50f) {
			transform.position = startPosition;
		}
	}

	void CalculateVelocity() {
		velocity.y += gravity * Time.deltaTime;
	}
}
