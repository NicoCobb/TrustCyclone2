//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Checkpoint : MonoBehaviour {
//
//	public RespawnManager respawnManager;
//
//	// Use this for initialization
//	void Start () {
//		respawnManager = FindObjectOfType<RespawnManager> ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	void OnTriggerEnter2D(Collider2D other) {
//		if (other.tag == "player") {
//			respawnManager.currentCheckpoint = gameObject;
//		}
//	}
//}
