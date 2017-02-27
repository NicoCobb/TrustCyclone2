using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {
	public float jumpForce = 1000f;	
	public bool visible = false;
	ParticleSystem ps;
    
	// Use this for initialization
	void Start () {
		ps = gameObject.GetComponentInParent<ParticleSystem> ();
		var em = ps.emission;
		em.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "UnbreakableCrate") {
			Rigidbody2D collided = coll.gameObject.GetComponent<Rigidbody2D>();
			collided.velocity = new Vector2 (collided.velocity.x, 0);
			collided.AddForce (new Vector2 (0, jumpForce));
		}

		if (coll.gameObject.tag == "Visibility") {
			var em = ps.emission;
			em.enabled = true;
		}

		if (coll.gameObject.tag == "Crate") {
			Destroy (coll.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.tag == "Visibility") {
			var em = ps.emission;
			em.enabled = false;
		}
	}
}
