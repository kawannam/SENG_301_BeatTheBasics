/*
Last Updated: April 2, 2015
Description: Describes the menu features
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : GameModeScript {

	string[] text = new string[]{	// description text for each mode
		"TABLE OF CONTENTS",
		"Play By Ear\n\nListen and try to identify the notes",
		"Sight Reading Tutor\n\nPractice reading sheet music",
		"Clap Back\n\nListen to a rhythm and clap it back",
		"Free Play\n\nNo frills piano mode + metronome",
		"Sticker Book\n\nView collected stickers"
	};

	//VARIABLES

	public int menuIdx;		// which page of menu we are on
	public Text page1;		// page 1 text object
	public Text page2;		// page 2 text object

	//FUNCTIONS

	// Use this for initialization
	void Start () 
	{
		OnPrevNext(0);
	}

	//Update game manager
	public void SetGameManager(IGameManagerScript paramGame)
	{
		gameManager = paramGame;
	}

	//Cycle to the previous/next menu screen
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

	//Change state to the feature selected
	public void OnSelect(int paramNum)
	{
		int selection = paramNum + menuIdx;
		switch(selection)
		{
		case 0:
			gameManager.ChangeState(GameManagerState.TableOfContents);
			break;
		case 1:
			gameManager.ChangeState(GameManagerState.PlayByEar);
			break;
		case 2:
			gameManager.ChangeState(GameManagerState.SightReading);
			break;
		case 3:
			gameManager.ChangeState(GameManagerState.ClapBack);
			break;
		case 4:
			gameManager.ChangeState(GameManagerState.Metronome);
			break;
		case 5:
			gameManager.ChangeState(GameManagerState.StickerBook);
			break;
		}
	}
}
