using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
		other.GetComponent<Rigidbody2D>().drag += 1000.0f;
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Salió");
	}

}
