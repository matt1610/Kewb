using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[SerializeField]
	private float lifeTime;

	void Start () {
		Destroy (gameObject, lifeTime);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.SendMessage("TakeHit");
		}
	}
}
