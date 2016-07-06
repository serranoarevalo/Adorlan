using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {

	public static CarMovement instance;

	private float power;
	private float maxspeed;
	private float turnpower = 1.8f;
	private float friction;
	private Vector2 curspeed;
	public bool onGrass, moveLeft, moveRight, moveUp;
	private int lapNumber;
	Rigidbody2D rigidbody2D;
	private int selectedPlayer;


	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		if (GameController.instance.selectedPlayer == 0) {
			
		}

		selectedPlayer = GameController.instance.selectedPlayer;

		switch (selectedPlayer) {
		case 0:
			power = 280;
			turnpower = 1.8f;
			friction = 8;

			break;
		case 1:
			power = 300;
			turnpower = 1.9f;
			friction = 7.5f;

			break;
		case 2:
			power = 310;
			turnpower = 2.0f;
			friction = 7.5f;

			break;
		case 3:
			power = 320;
			turnpower = 2.3f;
			friction = 7.0f;

			break;
		case 4:
			power = 340;
			turnpower = 2.6f;
			friction = 6.7f;

			break;
		case 5:
			power = 340;
			turnpower = 3.0f;
			friction = 6.7f;

			break;
		case 6:
			power = 340;
			turnpower = 2.8f;
			friction = 6.7f;

			break;
		case 7:
			power = 350;
			turnpower = 3.1f;
			friction = 6.7f;

			break;
		case 8:
			power = 350;
			turnpower = 3.1f;
			friction = 7.0f;

			break;
		case 9:
			power = 350;
			turnpower = 3.1f;
			friction = 7.3f;

			break;
		}
	}


	void FixedUpdate()
	{
		curspeed = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		if (curspeed.magnitude > maxspeed) {
			curspeed = curspeed.normalized;
			curspeed *= maxspeed;
		}

		if (moveUp) {

			MoveUp ();

			if (moveLeft) {
				MoveLeft ();
			}


			if (moveRight) {
				MoveRight ();
			}

		}

		if (Input.GetKey (KeyCode.W)) {
			MoveUp ();

			if (Input.GetKey (KeyCode.A)) {
				MoveLeft ();
			}

			if (Input.GetKey (KeyCode.D)) {
				MoveRight ();			
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

	public void SetMoveLeft(bool moveLeft) {
		this.moveLeft = moveLeft;
		this.moveRight = false;
	}

	public void SetMoveRight(bool moveRight){
		this.moveRight = moveRight;
		this.moveLeft = false;
	}

	public void SetMoveUp(bool moveUp) {
		this.moveUp = moveUp;
	}

	public void StopMoving() {
		moveLeft = moveRight = moveUp = false;
	}

	public void StopMovingLeft() {
		this.moveLeft = false;
	}

	public void StopMovingRight() {
		this.moveRight = false;
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

	void MoveLeft(){

		transform.Rotate (Vector3.forward * turnpower);
		
	}

	void MoveRight(){
		
		transform.Rotate (Vector3.forward * -turnpower);
	}

	void MoveUp() {

		rigidbody2D.AddForce (transform.up * power);

		if (onGrass) {
			rigidbody2D.drag = friction * 5;
		} else {
			rigidbody2D.drag = friction;
		}

	}



}
