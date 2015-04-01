using UnityEngine;
using System.Collections;

public class TableOfContentsScript : GameModeScript {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnSelect(int paramNum)
	{
		int selection = paramNum;
		switch(selection)
		{
		case 0:
			gameManager.ChangeState(GameManagerState.Metronome);
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
			gameManager.ChangeState(GameManagerState.StickerBook);
			break;
		}
	}
}
