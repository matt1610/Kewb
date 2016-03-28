using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kewb;

public class GameManager : Singleton<GameManager> {


	public float TimeRemaining { get; set;}
	private float maxTime = 5 * 60;
	public List<Button> Buttons { get; set;}
	public int pressedButtons = 0;
	public UpdateUI ui { get; set;}
	public bool LevelComplete = false;
	public float Gems = 0;
	public List<Magic> MagicAbilities { get; set;}
	public int SelectedMagic { get; set; }

	public string LanguageCode = "en";
	public string LANGPATH = "/Languages/";

	public Rigidbody playerRigidBody;

	void Start () 
	{
		TimeRemaining = maxTime;
		Debug.Log (StringContainer.GetString(1,3));
		SelectedMagic = 0;
	}

	void Awake()
	{
		ui = GameObject.Find ("HUDCanvas").GetComponentsInChildren<UpdateUI> () [0];
		MagicAbilities = new List<Magic>();
		Buttons = new List<Button>();
		playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody>();
	}

	void Update () 
	{
		HandleMagicGemCount ();

		if (Input.GetKey ("r")) {
			Application.LoadLevel(Application.loadedLevel);	
		}

		if (Input.GetKeyDown("m")) {
			DoMagic();
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

	public void AddMagicAbility(string abilityName)
	{
		Magic magic;
		switch (abilityName) 
		{
			case "ZeroGravity":
				magic = new ZeroGravity();
				break;
			default:
				magic = new ZeroGravity();
				break;
		}

		GameManager.Instance.MagicAbilities.Add(magic);
	}

	public void DoMagic()
	{
		if (MagicAbilities.Count > SelectedMagic - 1) {
			MagicAbilities[SelectedMagic].Execute();
		}
	}

	public void HandleMagicGemCount()
	{
		if (!playerRigidBody.useGravity) {
			Gems -= Time.deltaTime * MagicAbilities[0].GemUsage;
		}

		if (Gems < 1) {
			playerRigidBody.useGravity = true;
		}
	}
	
	










}
