﻿using UnityEngine;
using System.Collections;

public class LapCounter : MonoBehaviour {


	void OnTriggerExit2D(Collider2D other) {
		GamePlayController.instance.Lap ();
	}
}
