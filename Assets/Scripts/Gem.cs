using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	public float Speed;

	void Start()
	{
		Speed = Speed * Random.Range (1, 1.5f);
	}
	void Update () {
		transform.Rotate(Vector3.right, Speed * Time.deltaTime);
		transform.Rotate(Vector3.up, Speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			GameManager.Instance.Gems++;
			Destroy(gameObject);
		}
	}
}
