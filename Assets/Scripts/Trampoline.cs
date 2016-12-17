using UnityEngine;
using System.Collections;
using Kewb;

public class Trampoline : MonoBehaviour, ICollideable {

	[SerializeField]
	private int Force;

	void OnCollisionEnter(Collision coll) {
		coll.rigidbody.AddForce (Vector3.up * Force * 100);
	}

	public void CollidedWithCharacter(GameObject character) {
		NewPlayerMovement player = character.GetComponent<NewPlayerMovement>();
		player.TrampolineBoost = Force;
		player.TrampolineJump = true;
	}


}
