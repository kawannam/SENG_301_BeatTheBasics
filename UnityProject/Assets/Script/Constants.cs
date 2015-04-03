/*
Last updated: April 1, 2015
Description: Data file: holds constants and sound information
*/
using UnityEngine;
using System.Collections;

//State of a piano key: is it being pressed or is it released
public enum KeyState
{
	Released,
	Pressed
}

//Minigames
public enum GameModeType
{
	PlayByEar,
	SightReading,
	ClapBack
}

//Piano notes: from low C to high B
public enum PianoKey
{
	L_C,
	L_Cs,
	L_D,
	L_Ds,
	L_E,
	L_F,
	L_Fs,
	L_G,
	L_Gs,
	L_A,
	L_As,
	L_B,
	H_C,
	H_Cs,
	H_D,
	H_Ds,
	H_E,
	H_F,
	H_Fs,
	H_G,
	H_Gs,
	H_A,
	H_As,
	H_B,
	MAX
}

//Constants and piano sounds
public static class Constants
{	
	public const int PIANO_NUM_KEYS = 24;
	public static int MAX_BPM = 240;
	public static int MIN_BPM = 1;
	public const int NUM_OF_DIFFICULTY = 3;//Number of difficulty modes
	public const int MAX_STARS = 3;
	public static string[] PIANO_SOUND_FILES = new string[]{
			"Sounds/piano2/piano.mf.C3",
			"Sounds/piano2/piano.mf.Db3",
			"Sounds/piano2/piano.mf.D3",
			"Sounds/piano2/piano.mf.Eb3",
			"Sounds/piano2/piano.mf.E3",
			"Sounds/piano2/piano.mf.F3",
			"Sounds/piano2/piano.mf.Gb3",
			"Sounds/piano2/piano.mf.G3",
			"Sounds/piano2/piano.mf.Ab3",
			"Sounds/piano2/piano.mf.A3",
			"Sounds/piano2/piano.mf.Bb3",
			"Sounds/piano2/piano.mf.B3",
			"Sounds/piano2/piano.mf.C5",
			"Sounds/piano2/piano.mf.Db5",
			"Sounds/piano2/piano.mf.D5",
			"Sounds/piano2/piano.mf.Eb5",
			"Sounds/piano2/piano.mf.E5",
			"Sounds/piano2/piano.mf.F5",
			"Sounds/piano2/piano.mf.Gb5",
			"Sounds/piano2/piano.mf.G5",
			"Sounds/piano2/piano.mf.Ab5",
			"Sounds/piano2/piano.mf.A5",
			"Sounds/piano2/piano.mf.Bb5",
			"Sounds/piano2/piano.mf.B5"
		};

	//Piano key bindings to the computer keyboard
	public static KeyCode[] PIANO_KEY_BINDING = new KeyCode[]{
			KeyCode.Q,
			KeyCode.Alpha2,
			KeyCode.W,
			KeyCode.Alpha3,
			KeyCode.E,
			KeyCode.R,
			KeyCode.Alpha5,
			KeyCode.T,
			KeyCode.Alpha6,
			KeyCode.Y,
			KeyCode.Alpha7,
			KeyCode.U,
			KeyCode.B,
			KeyCode.H,
			KeyCode.N,
			KeyCode.J,
			KeyCode.M,
			KeyCode.Comma,
			KeyCode.L,
			KeyCode.Period,
			KeyCode.Semicolon,
			KeyCode.Slash,
			KeyCode.Quote,
			KeyCode.RightShift
		};
}
