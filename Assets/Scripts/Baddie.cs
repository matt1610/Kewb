using UnityEngine;
using System.Collections;
using Kewb;

public class Baddie : MonoBehaviour, IEnemy, ICollideable {

	private Transform player;
	NavMeshAgent nav;
	public float Health = 100;
	public int StandardDamage = 10;
	public PlayerHealth PlayerHealth {get;set;}

	void Awake() 
	{
		player = GameObject.Find ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		GameManager.Instance.onClicked += SubscribeMethod;

		PlayerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

		if (PlayerHealth == null) 
		{
			Debug.Log("It's fucking null WHY");
		}
	}

	void SubscribeMethod()
	{
		Debug.Log ("From Baddie.cs!");
	}

	public void TakeHit(float damage)
	{
		Health = Health - damage;
		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

	public void CollidedWithCharacter(GameObject other) 
	{
		if (other.name == "Player") 
		{			
			PlayerHealth.TakeDamage(StandardDamage);
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
