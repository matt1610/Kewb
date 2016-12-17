using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kewb;

public class Button : MonoBehaviour, ICollideable {

	public bool Pressed = false;
	private bool moving = false;
	private bool moved = false;

	// Use this for initialization
	void Start () {
		GameManager.Instance.Buttons.Add (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CollidedWithCharacter(GameObject character) {
		
		if(!Pressed) {
			GameManager.Instance.PressedButtons++;
		}

		Pressed = true;

		if (Pressed && !moved) {
			Renderer rend = GetComponent<Renderer>();
			rend.material.color = Color.red;

			StartCoroutine(MoveFromTo(transform.position, new Vector3(transform.position.x,transform.position.y - 0.1f,transform.position.z), 0.5f));
			moved = true;
		}
	}

	IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time){
		if (!moving){
			moving = true;
			float t = 0f;
			while (t < 1f){
				t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
				transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
				yield return 0; // leave the routine and return here in the next frame
			}
			moving = false; // finished moving
		}
	}
}
