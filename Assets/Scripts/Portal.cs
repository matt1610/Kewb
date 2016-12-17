using UnityEngine;
using System.Collections;
using Kewb;

public class Portal : MonoBehaviour, ICollideable {

	public Portal Sister;
	public bool Ready = true;

	void Awake () {
		
	}

	void Update () {

	}

	void Teleport(GameObject go) {
		if (Ready)
        {
			Sister.Ready = false;
			Vector3 newPos = new Vector3(
				Sister.transform.position.x, 
				Sister.transform.position.y + 0.5f, 
				Sister.transform.position.z);
			go.transform.position = newPos;

			StartCoroutine(WaitToReEnable());

        }
	}

	void OnCollisionEnter(Collision other)
    {
		Teleport(other.gameObject);
    }

	public void CollidedWithCharacter(GameObject go) {
		Teleport(go);
	}

	void OnCollisionExit(Collision other) 
	{
		Ready = true;
	}

	void OnTriggerExit()
	{
		Ready = true;
	}

	IEnumerator WaitToReEnable() {
        yield return new WaitForSeconds(2);
		Sister.Ready = true;
    }

}
