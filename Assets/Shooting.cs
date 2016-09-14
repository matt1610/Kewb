using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;

	[SerializeField]
	private float bulletSpeed;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			Debug.Log("Shooting");
			GameObject go = Instantiate(bullet, transform.position, new Quaternion(90,0,0,0)) as GameObject;
			Rigidbody clone = go.GetComponent<Rigidbody>();
			clone.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
		}
	}
}
