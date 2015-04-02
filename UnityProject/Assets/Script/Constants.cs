using UnityEngine;
using System.Collections;

public enum KeyState	// The state of a piano key
{
	Released,
	Pressed
}

public enum PianoKey	// the keys of the game piano keyboard
{
	L_C,		// starting from LOWER C-note
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
	H_C,		// HIGH C-note
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

public static class Constants
{	
	public const int PIANO_NUM_KEYS = 24;		// 2 full octaves worth of keys
	public static int MAX_BPM = 240;			// maximum BPM metronome setting
	public static int MIN_BPM = 1;				// minimum BPM metronome setting
	public const int NUM_OF_DIFFICULTY = 3;		// the number of difficulty levels
	public const int MAX_STARS = 3;				// number of stars in a perfect game performance
	public static string[] PIANO_SOUND_FILES = new string[]{	// file path of all piano soundclips, ordered according to the PianoKeys enum
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

	public static KeyCode[] PIANO_KEY_BINDING = new KeyCode[]{		// a list of which keys are bound to each note in the PianoKey enum
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
