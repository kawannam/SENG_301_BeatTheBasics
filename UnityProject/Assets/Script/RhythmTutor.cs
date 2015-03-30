using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RhythmTutor : MonoBehaviour {
	const float MARGIN_OF_ERROR = 0.10f;

	public float changeBeat;
	public int beatNumber;
	public float[] beats;
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
	//public void onNext()

	//Menu Button
	//public void onMenu()



	public void ChangeState(State paramState){
		switch (paramState) {
			/*case State.Ready:
			listenObject.SetActive(true);
			playObject.SetActive (false);
			scoreObject.SetActive (false);
			break;
		*/case State.Listen:
			listenObject.SetActive(true);
			playObject.SetActive (false);
			scoreObject.SetActive (false);
			buttons1.SetActive(false);
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
			break;
		}
		state = paramState;
	}
	// Use this for initialization
	void Start () {
		isActive = false;
		played = false;
		beats = new float[]{
			0f, 0.25f, 0.5f, 1f, 1.5f, 1.75f, 2f, 2.25f, 2.5f, 3.5f, 4f, 4.5f};
		//Eighth eighth quarter quarter eighth eight eighth eighth half quarter quarter whatever
		mapScore = new int[]{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
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
			if(beatNumber >= 12)
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
			if(beatNumber == 11)
			{
				if(Next >= 6)
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
