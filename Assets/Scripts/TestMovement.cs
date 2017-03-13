using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

	public CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		controller.SimpleMove(Vector3.forward);
	}
}
