using UnityEngine;
using System.Collections;

public class Metronome : GameModeScript {
	const int MAX_BPM = 240;
	const int MIN_BPM = 0;
	const int BPM_INC = 10;
	public int bpm;
	public bool isActive;
	public float Next;
	public AudioSource source;

//Sets the initial bpm to 120 (Standard speed)
	void Start () {
		bpm = 120;										
	}

/* Compares user's bpm input with the min and max values
 * If the input is out of bounds, set at closest possible value
 * Starts the 
 */
	public void SetBPM(int paramBPM)
	{
		if (paramBPM < MIN_BPM)							
			bpm = 0;									
		else if (paramBPM > MAX_BPM)					
			bpm = 240;									
		else
			bpm = paramBPM;
		Next = 60f / bpm;
		if (isActive)
			source.Play();   
	}
// Increases the BPM and resets it
	public void IncreaseBPM()
	{
		SetBPM (bpm + BPM_INC);
	}

// Decrease the BPM and resets it
	public void DecreaseBPM()
	{
		SetBPM (bpm - BPM_INC);
	}

//Stops the metronome from playing noises 
	public void ToggleActive()
	{
		isActive = !isActive;
	}

/* Checks if Metronome is on
 * If it is off, do nothing
 * If the speed is greater than 0 play metronome
 * Keeps track of when a noise should be made
 */
	void Update () {
		if (!isActive)
			return;
		if (Next <= 0)
		{
			source.Play();
			Next = 60f / bpm;
		}
		Next -= Time.deltaTime;
	}
}
