﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : GameModeScript {

	string[] text = new string[]{
		"TABLE OF CONTENTS",
		"Play By Ear\n\nListen and try to identify the notes",
		"Sight Reading Tutor\n\nPractice reading sheet music",
		"Clap Back\n\nListen to a rhythm and clap it back",
		"Free Play\n\nNo frills piano mode + metronome",
		"Sticker Book\n\nView collected stickers"
	};
	
	public int menuIdx;
	public Text page1;
	public Text page2;

	// Use this for initialization
	void Start () 
	{
		OnPrevNext(0);
	}

	public void SetGameManager(IGameManagerScript paramGame)
	{
		gameManager = paramGame;
	}

	public void OnPrevNext(int paramDir)
	{
		menuIdx += paramDir;
		if (menuIdx < 0)
			menuIdx = text.Length - 2;
		if (menuIdx >= text.Length)
			menuIdx = 0;

		page1.text = text[menuIdx];
		page2.text = text[menuIdx + 1];
	}

	public void OnSelect(int paramNum)
	{
		int selection = paramNum + menuIdx;
		switch(selection)
		{
		case 0:
			break;
		case 1:
			gameManager.ChangeState(GameManagerState.PlayByEar);
			break;
		case 4:
			break;
		}
	}
}
