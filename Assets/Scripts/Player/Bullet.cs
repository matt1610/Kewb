using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[SerializeField]
	private float lifeTime;

	void Start () {
		Destroy (gameObject, lifeTime);
	}
}
