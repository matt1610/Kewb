using UnityEngine;
using System.Collections;

public class Talker : MonoBehaviour {

	[SerializeField]
	private int page;
	[SerializeField]
	private int[] key;

	public int messageIndex = 0;

	public void StartDialogue()
	{
		if (messageIndex < key.Length) {
			GameManager.Instance.ui.DisplayText (page, key[messageIndex]);
			messageIndex++;
		} else {
			messageIndex = 0;
			GameManager.Instance.ui.HidePanel();
		}
	}
}
