using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kewb;

public class UpdateUI : MonoBehaviour {

	[SerializeField]
	private Text timerLabel;

	[SerializeField]
	private Text levelComplete;

	[SerializeField]
	private Text gemCounter;

	[SerializeField]
	private GameObject dialoguePanel;

	public Text dialogueText;

	void Start () {
		levelComplete.enabled = false;
		levelComplete.text = StringContainer.GetString (1,2);
		dialogueText = dialoguePanel.GetComponentsInChildren<Text> ()[0];
		dialoguePanel.SetActive (false);
	}

	public void DisplayText(int page, int id) 
	{
		dialoguePanel.SetActive (true);
		dialogueText.text = StringContainer.GetString (page, id);
	}

	public void HidePanel()
	{
		dialoguePanel.SetActive (false);
	}

	void Update () {
		timerLabel.text = FormatTime(GameManager.Instance.TimeRemaining);
		gemCounter.text = ((int)GameManager.Instance.Gems).ToString ();
	}

	public void ShowLevelComplete () {
		Text LC = GameObject.Find ("LevelCompleteText").GetComponent<Text>();
		LC.enabled = true;
		Animator anim = GameObject.Find ("LevelCompleteBG").GetComponent<Animator> ();
		anim.SetBool ("Down", true);
	}

	private string FormatTime(float timeInSeconds)
	{
		return string.Format ("{0}:{1:00}", Mathf.FloorToInt (timeInSeconds / 60), Mathf.FloorToInt (timeInSeconds % 60));
	}
}
