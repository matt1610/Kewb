using UnityEngine;
using System.Collections;
using Kewb;

public class MagicItem : MonoBehaviour {

	public string AbilityName;
	Magic magic;

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			GameManager.Instance.AddMagicAbility(AbilityName);
			Destroy(gameObject);
		}
	}
}
