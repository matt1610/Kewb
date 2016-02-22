using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

	[SerializeField]
	private Text timerLabel;

	[SerializeField]
	private Text levelComplete;

	[SerializeField]
	private Text gemCounter;

	void Start () {
		levelComplete.enabled = false;
	}

	void Update () {
		timerLabel.text = FormatTime(GameManager.Instance.TimeRemaining);
		gemCounter.text = GameManager.Instance.Gems.ToString();
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
