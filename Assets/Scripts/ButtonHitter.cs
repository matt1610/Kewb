using UnityEngine;
using System.Collections;

public class ButtonHitter : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Button") {
			Button button = collision.gameObject.GetComponent<Button>();
			if (!button.Pressed) {
				button.Pressed = true;
				GameManager.Instance.PressedButtons++;
			}
		}
	}
	
}
