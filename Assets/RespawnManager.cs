//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class RespawnManager : MonoBehaviour {
//
//	public GameObject currentCheckpoint;
//	private PlayerControl player;
//
//	// Use this for initialization
//	void Start () {
//		player = FindObjectOfType<PlayerControl>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (player.transform.position.y < -100f) {
//			respawnPlayer ();
//		}
//	}
//
//	public void respawnPlayer() {
//		player.transform.position = currentCheckpoint.transform.position;
//	}
//}
