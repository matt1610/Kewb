using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		RaycastHit floorHit;
		if (Physics.Raycast (transform.position, Vector3.down, out floorHit, 0.3f)) 
		{
			if (floorHit.transform.gameObject.tag == "Button") {
				Button button = floorHit.transform.gameObject.GetComponent<Button> ();
				if (!button.Pressed) {
					button.Pressed = true;
					GameManager.Instance.pressedButtons++;
				}
			}
		}
	}
}
