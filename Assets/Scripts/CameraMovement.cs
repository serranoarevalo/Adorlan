﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private GameObject player;

	void Awake(){

		GetPlayer ();
	}

	void Update() {

		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
		} else {
			GetPlayer ();
		}

	}

	void GetPlayer() {
		player = GameObject.FindWithTag ("Player");
	}
}
