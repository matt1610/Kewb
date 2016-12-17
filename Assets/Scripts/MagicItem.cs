using UnityEngine;
using System.Collections;
using Kewb;

public class MagicItem : MonoBehaviour, ICollideable {

	public string AbilityName;
	Magic magic;

	public void CollidedWithCharacter(GameObject other) {
		GameManager.Instance.AddMagicAbility(AbilityName);
		Destroy(gameObject);
	}
}
