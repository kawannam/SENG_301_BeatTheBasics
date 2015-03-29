using UnityEngine;
using System.Collections;



public class Metronome : MonoBehaviour {
	const int MAX_BPM = 240;
	const int MIN_BPM = 0;
	const int BPM_INC = 10;
	public int bpm;
	public bool isActive;
	public float Next;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		bpm = 240;
		isActive = true;
	}
	public void SetBPM(int paramBPM)
	{
		if (paramBPM < MIN_BPM)
			bpm = 0;
		else if (paramBPM > MAX_BPM)
			bpm = 240;
		else
			bpm = paramBPM;
		Next = bpm / 60f;
		source.Play();   
	}
	public void IncreaseBPM()
	{
		if ((bpm + BPM_INC) > MAX_BPM)
			bpm = MAX_BPM;
		else
			bpm = bpm + BPM_INC;
	}
	
	public void DecreaseBPM()
	{
		if ((bpm - BPM_INC) < MIN_BPM)
			bpm = MIN_BPM;
		else
			bpm = bpm - BPM_INC;
	}
	public Metronome()
	{
	}
	// Update is called once per frame
	void Update () {
		if (!isActive)
			return;
		if (Next <= 0)
		{
			source.Play();
			Next = 60f/bpm;
		}
		Next -= Time.deltaTime;
	}
}
