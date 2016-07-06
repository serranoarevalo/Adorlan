using UnityEngine;
using System.Collections;

public class SoundFX : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (gameObject.name == "SoundEnter") {
			MusicController.instance.PlayCrowd ();
			MusicController.instance.setBeginToPlay (true);
		} else {
			MusicController.instance.setBeginToPlay (false);		
		}
	}


}
