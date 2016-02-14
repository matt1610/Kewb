using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Portal Sister;
	public bool Ready = true;
	public Rigidbody PlayerRb;

	void Awake () {
		PlayerRb = GameObject.Find ("Player").GetComponent<Rigidbody> ();
	}

	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.name == "Player" && Ready)
        {
			Sister.Ready = false;
			Vector3 newPos = new Vector3(
				Sister.transform.position.x, 
				Sister.transform.position.y + 0.5f, 
				Sister.transform.position.z);
			other.gameObject.transform.position = newPos;
			PlayerRb.velocity = new Vector3(PlayerRb.velocity.x,
			                                  10,
			                                  PlayerRb.velocity.z);

        }
    }

	void OnCollisionExit(Collision other) 
	{
	
		if (other.gameObject.name == "Player") {
			Ready = true;
		}
	
	}

}
