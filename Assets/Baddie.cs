using UnityEngine;
using System.Collections;

public class Baddie : MonoBehaviour {

	private Transform player;
	NavMeshAgent nav;
	public int Health = 100;

	void Awake() 
	{
		player = GameObject.Find ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();

		GameManager.Instance.onClicked += SubscribeMethod;
	}

	void SubscribeMethod()
	{
		Debug.Log ("From Baddie.cs!");
	}

	public void TakeHit()
	{
		Health = Health - 10;
		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		nav.SetDestination (player.position);
	}
}
