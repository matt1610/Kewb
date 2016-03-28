using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteractions : MonoBehaviour {

	public bool inDialogue = false;
	private GameObject dialoguePartner;

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



		if (Input.GetKeyDown("i")) {
			Interact();
		}
	}


	void Interact()
	{
		inDialogue = true;
		RaycastHit hit;
		List<Ray> rayList = new List<Ray> ();
		rayList.Add (new Ray (transform.position, Vector3.forward));
		rayList.Add (new Ray (transform.position, Vector3.back));
		rayList.Add (new Ray (transform.position, Vector3.right));
		rayList.Add (new Ray (transform.position, Vector3.left));
		rayList.Add (new Ray (transform.position, Vector3.up));
		rayList.Add (new Ray (transform.position, Vector3.down));
		
		foreach (var ray in rayList) {
			if (Physics.Raycast(ray, out hit, 2f)) {
				if (hit.collider.gameObject.tag == "Talker") {
					dialoguePartner = hit.collider.gameObject;
					hit.collider.gameObject.SendMessage("StartDialogue");
					return;
				}
			}
		}
		
		
	}
}
