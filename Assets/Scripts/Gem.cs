using UnityEngine;
using System.Collections;
using Kewb;

public class Gem : MonoBehaviour, ICollideable {

	public float Speed;

	void Start()
	{
		Speed = Speed * Random.Range (1, 1.5f);
	}
	void Update () {
		transform.Rotate(Vector3.right, Speed * Time.deltaTime);
		transform.Rotate(Vector3.up, Speed * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit other) {
		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Player") {
			GameManager.Instance.Gems++;
			Destroy(gameObject);
		}
	}

	public void CollidedWithCharacter(GameObject go) {
		GameManager.Instance.Gems++;
		Destroy(gameObject);
	}
}
