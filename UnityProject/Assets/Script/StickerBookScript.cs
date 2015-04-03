using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class StickerBookScript : GameModeScript {

	public Image[] StickerList = new Image[9];					//Creates an Array of 9 images (Stickers) for sticker book

	public static int[] GameProgress = new int[9];				//Keeps track of which games and difficulties have been completed 

	/* Update will change the colour from black to normal 
	 * depending on what new levels have been complete
	 */

	public void Update() 
	{
		for (int i = 0; i < StickerList.Length; i++) {			//Loops through the Sticker list
			if (GameProgress [i] == 0) {						//Checks if a particular game has been won
				StickerList [i].color = new Color (0, 0, 0, 1); //If not turn the stickers black
			} else {											//If they have been compeleted change colour to normal
				StickerList [i].color = new Color (1, 1, 1, 1);
			}
		}
	}

	public void quit(){
		gameManager.ChangeState (GameManagerState.Menu);		//Connects to the home menu button
	}
}

