using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	void Start(){

		offset = transform.position - player.transform.position;
	}

	void Update() {

		player = GameObject.FindWithTag("Player");

		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);

	}
}
