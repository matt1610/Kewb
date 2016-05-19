using UnityEngine;
using System.Collections;

public class TestAnimations : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("r")) {
			animator.SetBool ("Running", true);
			Debug.Log(animator.GetBool("Running"));
		} else {
			animator.SetBool("Running", false);
		}
	}
}
