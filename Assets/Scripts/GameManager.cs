using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {


	public float TimeRemaining { get; set;}
	private float maxTime = 5 * 60;
	public List<Button> Buttons = new List<Button>();
	public int pressedButtons = 0;
	public UpdateUI ui;
	public bool LevelComplete = false;

	// Use this for initialization
	void Start () {
		TimeRemaining = maxTime;
	}

	void Awake(){
		ui = new UpdateUI ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("r")) {
			Application.LoadLevel(Application.loadedLevel);	
		}

		if (!LevelComplete) {
			TimeRemaining -= Time.deltaTime;		
		}

		if (TimeRemaining <= 0) 
		{
			Application.LoadLevel(Application.loadedLevel);
			TimeRemaining = maxTime;
		}

		if (pressedButtons == Buttons.Count) {
			LevelComplete = true;
			ui.ShowLevelComplete();
		}
	}
}
