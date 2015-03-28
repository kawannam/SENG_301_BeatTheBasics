using UnityEngine;
using System.Collections;

public class GameModeScript : MonoBehaviour {

	protected IGameManagerScript gameManager;

	public void SetManager(IGameManagerScript paramGame)
	{
		Debug.Log("find manager start");
		gameManager = paramGame;
	}
}
