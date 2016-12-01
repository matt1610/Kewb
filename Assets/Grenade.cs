using UnityEngine;
using System.Collections;
using Kewb;

public class Grenade : MonoBehaviour, IProjectile {
	
	public Vector3 FireAngle 
	{ 
		get {return fireAngle;}
		set {FireAngle = fireAngle;} 
	}
	public float Speed 
	{ 
		get {return speed;}
		set {Speed = speed;} 
	}

	ParticleSystem particleSystem;

	[SerializeField]
	private Vector3 fireAngle;
	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		particleSystem = gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag != "Gun" && other.gameObject.tag != "Player") {
			particleSystem.Emit (500);
			Destroy (gameObject,0.15f);
		}

	}
}
