using UnityEngine;
using System.Collections;

/// <summary>
/// GameModeScript - Basic functionality shared between all game modes, all game modes inherit this class
/// </summary>
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

    /* RegisterScore - show a user's star rating after completing a game mode
     * stars = [0..3]
     */
	public void RegisterScore(int stars)
	{
		if (starPrefab == null)
			starPrefab = Resources.Load<GameObject>("Prefabs/StarDisplayPrefab");   // load prefab only when showing it

		int stickerIndex = (int)modeType + (int)difficulty * Constants.NUM_OF_DIFFICULTY;   // get the correct array index of the stickerbook
        if (StickerBookScript.GameProgress[stickerIndex] < stars)       // set new score only if better than previous score
            StickerBookScript.GameProgress[stickerIndex] = stars;       // store the amount of progress for the mode
	 	starObj = (GameObject)GameObject.Instantiate(starPrefab);
		StarDisplayScript starDisp = starObj.GetComponent<StarDisplayScript>();
		starDisp.numStars = stars;
		starObj.transform.SetParent(transform);
	}

    /* RegisterScore overload method: registers the score and also moves the star display to the specified position
     */
	public void RegisterScore(int stars, Vector3 position)
	{
		RegisterScore (stars);
		starObj.transform.localPosition = position;
	}

    /* RemoveStarDisplay - Turns the star score display off */
	public void RemoveStarDisplay()
	{
		if (starObj != null)
			Destroy(starObj);
	}

	public void OnMenu(){
		gameManager.ChangeState (GameManagerState.Menu);
	}
}
