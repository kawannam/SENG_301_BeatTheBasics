using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RhythmTutor : GameModeScript {
	const float MARGIN_OF_ERROR = 0.10f;

	public float changeBeat;
	public int beatNumber;
	public float[] beats;
	public float[] rhythmMapHard;
	public float[] rhythmMapEasy;
	public float[] rhythmMapMed;
	public int[] mapScore;

//	public bool activeBeat;
//	public bool ready;
	public bool played;
	public bool isActive;

	public float Next;
	public AudioSource source;

	public enum State{
	//	Ready,
		Listen,
		Playback,
		Result}
	public State state;

	public GameObject listenObject;
	public GameObject playObject;
	public GameObject scoreObject;
	public GameObject buttons1;
	public Text countdownText;
	public GameObject quarterNotePrefab;
	public Transform noteGroup1;

	//READY BUTTON
	public void onReady (){
		ChangeState(State.Playback);
	}

	//REPEAT BUTTON
	public void onRepeat(){
		ChangeState (State.Listen);
	}

	//REPLAY BUTTON
	public void onReplay(){
		ChangeState (State.Listen);
	}

	//Next Button
	public void onNext(){
		int diff = (int)difficulty;
		diff++;
		diff = diff % Constants.NUM_OF_DIFFICULTY;
		SetDifficulty ((Difficulty)diff);
		ChangeState (State.Listen);
	}



	public void ChangeState(State paramState){
		switch (paramState) {
			/*case State.Ready:
			listenObject.SetActive(true);
			playObject.SetActive (false);
			scoreObject.SetActive (false);
			break;
		*/case State.Listen:
			List<GameObject> children = new List<GameObject>();
			foreach (Transform child in noteGroup1.transform) 
				children.Add(child.gameObject);
			children.ForEach(child => Destroy(child));
			if (difficulty == Difficulty.Easy)
				beats = rhythmMapEasy;
			else if (difficulty == Difficulty.Medium)
				beats = rhythmMapMed;
			else if (difficulty == Difficulty.Hard)
				beats = rhythmMapHard;
			mapScore = new int[beats.Length];
			listenObject.SetActive(true);
			playObject.SetActive (false);
			scoreObject.SetActive (false);
			buttons1.SetActive(false);
			beatNumber = 0;
			isActive = false;
			while(beatNumber < beats.Length)
			{
				mapScore[beatNumber] = 0;
				beatNumber++;
			}
			beatNumber = 0;
			Next = -3;
			countdownText.text = "3";
			break;
		case State.Playback:
			listenObject.SetActive(false);
			playObject.SetActive (true);
			scoreObject.SetActive (false);
			Next = 0;
			beatNumber = 0;
			break;
		case State.Result:
			listenObject.SetActive(false);
			playObject.SetActive (false);
			scoreObject.SetActive (true);
			int y = 65;
			beatNumber = 0;
			for(int i = 0; i < 2; i++)
			{
				int count = 1;
				if(beatNumber >= mapScore.Length)
					count = 9;
				while(count < 9)
				{
					GameObject note = (GameObject)GameObject.Instantiate(quarterNotePrefab);
					note.transform.SetParent(noteGroup1);
					Vector3 pos = note.transform.localPosition;
					pos.x += (100 * count);
					pos.y = y;
					note.transform.localPosition = pos;
					Image noteImg = note.GetComponent<Image>();
					if(mapScore[beatNumber] == 0)
						noteImg.color = Color.red;
					else
						noteImg.color = Color.green;
					count++;
					beatNumber++;
					if(beatNumber >= mapScore.Length)
						count = 9;//quit loop
				}
				y -= 100;
			}
			break;
		}
		state = paramState;
	}
	// Use this for initialization
	void Start () {
		played = false;
		rhythmMapHard = new float[]{
			0f, 0.25f, 0.5f, 1f, 1.5f, 1.75f, 2f, 2.25f, 2.5f, 3.5f, 4f, 4.5f};//12 notes
		//Eighth eighth quarter quarter eighth eighth eighth eighth half quarter quarter whatever
		rhythmMapEasy = new float[]{
		0f, 0.5f, 1f, 2f, 2.5f, 3f};//6 notes
		//Quarter quarter half quarter quarter half
		rhythmMapMed = new float[]{
		0f, 0.25f, 0.5f, 1f, 1.25f, 2.75f, 3f};//7 notes
		//Eighth eighth quarter eighth 3/4 note eighth whatever
		ChangeState (State.Listen);
	}

	// Update is called once per frame
	void Update () {
		switch(state)
		{
		/*case State.Ready:
			if (ready)
			{
				activeBeat = true;
				beatNumber = 0;
				Next = -3;
				ChangeState(State.Listen);
			}
			break;

		*/case State.Listen:
			/*if (!activeBeat)
			{
				ChangeState(State.Ready);
				Next = -5;
				beatNumber = 0;
				break;
			}*/
			if(Next >= -2 && Next < -1)
				countdownText.text = "2";
			else if(Next >= -1 && Next < 0)
				countdownText.text = "1";
			else if(Next >= 0)
				countdownText.text = "Listen to the Beat!";
			if(beatNumber >= beats.Length)
			{
				buttons1.SetActive(true);
				break;
			}
			if (Next >= beats[beatNumber])
			{
				source.Play();
				beatNumber++;
				//if (beatNumber == 12)
				//	activeBeat = false;
			}
			Next += Time.deltaTime;
			break;

		case State.Playback:
			bool click = Input.GetMouseButtonDown(0); //mouse button thing
			if(click)
				isActive = true;
			//CLICKED IN THE MARGIN OF ERROR
			if(Next < (beats[beatNumber] + MARGIN_OF_ERROR) && Next > (beats[beatNumber] - MARGIN_OF_ERROR))
			{
				if(click)
				{
					if(played)
						mapScore[beatNumber] = 0;
					else
					{
						played = true;
						mapScore[beatNumber] = 1;
					}
				}
			}
			//CLICKED OUTSIDE THE MARGIN OF ERROR
			else
			{
				if(click)
				{
					played = true;
					mapScore[beatNumber] = 0;
				}
			}
			//CHECK TO CHANGE THE BEAT NUMBER
			if(beatNumber == (beats.Length - 1))
			{
				if(Next >= (beats[beats.Length-1] + 1))
				{
					ChangeState(State.Result);
					break;
				}
			}
			else
			{
				changeBeat = beats[beatNumber] + ((beats[beatNumber + 1] - beats[beatNumber])/2);
				if(Next >= changeBeat)
				{
					played = false;
					beatNumber++;
				}
			}
			if(isActive == true)
				Next += Time.deltaTime;
			break;

		case State.Result:
			break;
		}//switch
	}//update
}//rhythmtutor
