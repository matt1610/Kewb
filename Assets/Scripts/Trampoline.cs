using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	[SerializeField]
	private int Force;

	void OnCollisionEnter(Collision coll) {
		coll.rigidbody.AddForce (Vector3.up * Force * 100);
	}


}
