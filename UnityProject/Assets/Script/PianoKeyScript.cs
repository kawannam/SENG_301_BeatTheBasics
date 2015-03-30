using UnityEngine;
using System.Collections;

public class PianoKeyScript : MonoBehaviour {

	public bool pressed;

	// Use this for initialization
	void Start () {    
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButton(0))
			pressed = false;
	}
	
	void OnMouseDown()
	{
		pressed = true;
	}

	void OnMouseUp()
	{
		pressed = false;
	}
	
	void OnMouseEnter()
	{
		if (Input.GetMouseButton(0))
			pressed = true;
	}

	void OnMouseExit()
	{
		pressed = false;
	}
}
