using UnityEngine;
using System.Collections;

public class GameModeScript : MonoBehaviour {

	private GameModeType modeType;
	protected IGameManagerScript gameManager;
	protected Difficulty difficulty;
	public GameObject starPrefab;
	private GameObject starObj;

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
		if (starPrefab == null)
			starPrefab = Resources.Load<GameObject>("Prefabs/StarDisplayPrefab");

		int stickerIndex = (int)modeType * Constants.NUM_OF_DIFFICULTY + (int)difficulty;
		StickerBookScript.GameProgress[stickerIndex] = stars;
	 	starObj = (GameObject)GameObject.Instantiate(starPrefab);
		StarDisplayScript starDisp = starObj.GetComponent<StarDisplayScript>();
		starDisp.numStars = stars;
		starObj.transform.SetParent(transform);
	}

	public void RemoveStarDisplay()
	{
		if (starObj != null)
			Destroy(starObj);
	}

	public void OnMenu(){
		gameManager.ChangeState (GameManagerState.Menu);
	}
}
