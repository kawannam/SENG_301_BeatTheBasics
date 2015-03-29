using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StickerBookStuff : MonoBehaviour {

	public Image[] StickerList = new Image[9];
	public Image[] Black_Stickers = new Image[9];

	public static int[] GameProgress = new int[9];		//Checks if game has been completed 
	// Use this for initialization
	void Start () {
		for ( int i = 0; i < GameProgress.Length -1; i++){
			GameProgress[i] = 0;
		}
		//StickerList [0] = GetComponent<Image>("unicorn"); 	
	}



	// Update is called once per frame
	void Update () {
		if (GameProgress [0] == 0) {
			StickerList[0].color = new Color(0,0,0,1);
		}
		else{
			StickerList[0].color = new Color(1, 1, 1, 1);
		}
	}
}
