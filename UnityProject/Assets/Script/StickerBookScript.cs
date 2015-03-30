using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameModeType
{
	PlayByEar,
	SightReading,
	ClapBack
}

public class StickerBookScript : GameModeScript {

	public Image[] StickerList = new Image[9];

	public static int[] GameProgress = new int[9];		//Checks if game has been completed 
	
	void Start () 
	{
		for (int i = 0; i < StickerList.Length; i++) {
			if (GameProgress [i] == 0) {
				StickerList [i].color = new Color (0, 0, 0, 1);
			} else {
				StickerList [i].color = new Color (1, 1, 1, 1);
			}
		}
	}

	public void OnCompletion(GameModeType paramMode, Difficulty paramDiff)
	{
		int index = (int)paramMode * 3 + (int)paramDiff; 
		GameProgress[index] = 1;
	}

	public void quit(){
		gameManager.ChangeState (GameManagerState.Menu);
	}
}

