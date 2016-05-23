using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	private float power = 300;
	private float maxspeed = 1000;
	private float turnpower = 2.5f;
	public float friction = 6;
	private Vector2 curspeed;
	private bool onGrass;
	private int lapNumber;
	Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}


	void FixedUpdate()
	{
		curspeed = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		if (curspeed.magnitude > maxspeed) {
			curspeed = curspeed.normalized;
			curspeed *= maxspeed;
		}

		if (Input.GetKey (KeyCode.W)) {
			rigidbody2D.AddForce (transform.up * power);

			if (onGrass) {
				rigidbody2D.drag = friction * 3;
			} else {
				rigidbody2D.drag = friction;
			}




				if (Input.GetKey (KeyCode.A)) {
					transform.Rotate (Vector3.forward * turnpower);
				}
				if (Input.GetKey (KeyCode.D)) {
					transform.Rotate (Vector3.forward * -turnpower);
				}



		}
			
		if (Input.GetKey (KeyCode.S)) {
			rigidbody2D.AddForce (-(transform.up) * (power / 2));

			if (onGrass) {
				rigidbody2D.drag = friction * 3;
			} else {
				rigidbody2D.drag = friction;
			}

			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (Vector3.forward * -turnpower);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (Vector3.forward * turnpower);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Grass") {
			onGrass = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Grass") {
			onGrass = false;
		}
	}



}
