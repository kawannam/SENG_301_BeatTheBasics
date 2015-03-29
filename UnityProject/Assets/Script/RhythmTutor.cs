using UnityEngine;
using System.Collections;

public class RhythmTutor : MonoBehaviour {
	const float MARGIN_OF_ERROR = 0.10f;

	public float changeBeat;
	public int beatNumber;
	public float[] beats;
	public int[] mapScore;

	public bool activeBeat;
	public bool ready;
	public bool played;
	public bool isActive;

	public float Next;
	public AudioSource source;

	public enum State{
		Ready,
		Listen,
		Playback,
		Result}
	public State state;

	// Use this for initialization
	void Start () {
		state = State.Ready;
		isActive = false;
		played = false;
		ready = true;
		beats = new float[]{
			0f, 0.25f, 0.5f, 1f, 1.5f, 1.75f, 2f, 2.25f, 2.5f, 3.5f, 4f, 4.5f};
		mapScore = new int[]{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	}

	// Update is called once per frame
	void Update () {
		switch(state)
		{
		case State.Ready:
			if (ready)
			{
				activeBeat = true;
				beatNumber = 0;
				state = State.Listen;
			}
			break;

		case State.Listen:
			if (!activeBeat)
			{
				state = State.Playback;
				Next = -5;
				beatNumber = 0;
				break;
			}
			if (Next >= beats[beatNumber])
			{
				source.Play();
				beatNumber++;
				if (beatNumber == 12)
					activeBeat = false;
			}
			Next += Time.deltaTime;
			break;

		case State.Playback:
			bool click = Input.GetMouseButtonDown(0); //mouse button thing
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
				if(Next >= (beats[beatNumber] + MARGIN_OF_ERROR))
				{
					state = State.Result;
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
			Next += Time.deltaTime;
			break;

		case State.Result:
			break;
		}//switch
	}//update
}//rhythmtutor
