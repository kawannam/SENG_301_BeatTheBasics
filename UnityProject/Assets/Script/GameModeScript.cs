using UnityEngine;
using System.Collections;

public class GameModeScript : MonoBehaviour {

	private GameModeType modeType;
	protected IGameManagerScript gameManager;
	protected Difficulty difficulty;
	
	public void SetManager(IGameManagerScript paramGame)
	{
		gameManager = paramGame;
	}
	
	public void SetModeType(GameModeType paramMode)
	{
		modeType = paramMode;
	}

	public void SetDifficulty(Difficulty paramDiff)
	{
		difficulty = paramDiff;
	}

	public void RegisterScore(int stars)
	{
		int stickerIndex = (int)modeType * Constants.NUM_OF_DIFFICULTY + (int)difficulty;
		StickerBookScript.GameProgress[stickerIndex] = stars;
	}
}
