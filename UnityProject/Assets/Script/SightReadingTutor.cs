/*using UnityEngine;
using System.Collections;

public class SightReadingTutor : MonoBehaviour {
	public int[] musicScore;
	public int[] playerInput;

	public int beatNumber;

	public enum State{
		Play,
		Result}
	public State state;

	// Use this for initialization
	void Start () {
	
		musicScore = new int[]{
		14, 12, 11, 9, 7, 11, 12, 9, 11, 14, 14, 16, 17, 19, 21, 17, 19};
		//MIDDLE D C B A G B C A B // TREBLE MIDDLE D D E F G A F G
		playerInput = new int[]{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		beatNumber = 0;
		state = State.Play;
	}

	int getKeyNote()
	{
	}
	// Update is called once per frame
	void Update () {
	
		switch (state) {
		case State.Play:
			if(beatNumber == 17)
			{
				state = State.Result;
				beatNumber = 0;
				break;
			}
			note = getKeyNote ();
			playerInput[beatNumber] = note;
			if(playerInput[beatNumber] == musicScore[beatNumber])
			{
				//print correct to screen
			}
			else
			{
				//print player input + wrong
			}
			beatNumber++;
			break;

		case State.Result:
			//option to retry or exit
			break;
		}//switch

	}
}*/
