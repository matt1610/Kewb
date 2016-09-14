using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour {

	public GameObject GrenadeLauncherProjectile;
	public float BulletSpeed;
	public List<GameObject> GrenadeLaunchers;
	private int launcherIndex = 0;
	public float fireRate = 0.2f;
	private float nextFire;

	void Start () {
		
	}

	void Update () {


		if (Input.GetButton("Fire1") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;

			GameObject bulletGameObject = Instantiate(
				GrenadeLauncherProjectile,
				GrenadeLaunchers[launcherIndex].transform.GetChild(0).position,
				new Quaternion(90,0,0,0)
				) as GameObject;

			Rigidbody bulletRb = bulletGameObject.GetComponent<Rigidbody>();
			bulletRb.velocity = transform.TransformDirection(Vector3.forward * BulletSpeed);

			if (launcherIndex == GrenadeLaunchers.Count - 1) {
				launcherIndex = 0;
			} else {
				launcherIndex++;
			}


		}
	}
}
