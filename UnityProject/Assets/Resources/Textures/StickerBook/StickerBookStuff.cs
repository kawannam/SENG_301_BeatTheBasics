﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StickerBookStuff : GameModeScript{

	public Image[] StickerList = new Image[9];

	public static int[] GameProgress = new int[9];		//Checks if game has been completed 
	// Use this for initialization
	void Start () {
		for ( int i = 0; i < GameProgress.Length; i++){
			GameProgress[i] = 0;
		}
	}



	// Update is called once per frame
	void Update () {
		for (int i = 0; i < StickerList.Length; i++) {
			if (GameProgress [i] == 0) {
				StickerList [i].color = new Color (0, 0, 0, 1);
			} else {
				StickerList [i].color = new Color (1, 1, 1, 1);
			}
		}
	}
	public void quit(){
		gameManager.ChangeState (GameManagerState.Menu);
	}
}
