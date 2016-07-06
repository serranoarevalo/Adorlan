using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private CarMovement carMovement;

	void Start() {
		carMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarMovement>();
	}

	public void OnPointerDown(PointerEventData data) {

		if (gameObject.name == "Up") {
			carMovement.SetMoveUp (true);
			MusicController.instance.incrementPitch (true);
		}


		if (gameObject.name == "Left") {
			carMovement.SetMoveLeft (true);
		}
			

		if (gameObject.name == "Right") {
			carMovement.SetMoveRight (true);
		}

	}

	public void OnPointerUp(PointerEventData data) {
		if (gameObject.name == "Up") {
			carMovement.StopMoving ();
			MusicController.instance.incrementPitch (false);
		}

		if (gameObject.name == "Left") {
			carMovement.StopMovingLeft();
		}

		if (gameObject.name == "Right"){
			carMovement.StopMovingRight ();
		}
	}
}
