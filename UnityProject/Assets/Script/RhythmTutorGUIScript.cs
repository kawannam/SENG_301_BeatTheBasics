using UnityEngine;
using System.Collections;

public class RhythmTutorGUIScript : MonoBehaviour {

	private Rect windowRect = new Rect (20, 200, 200, 200);

	void OnGUI() {
		windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
	}//end OnGUI

	void WindowFunction(int windowID){
		GUI.Label(new Rect(20, 20, 100, 50), "Rhythm Tutor");
	}//end WindowFunction

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
