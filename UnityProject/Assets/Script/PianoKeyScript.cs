using UnityEngine;
using System.Collections;

public class PianoKeyScript : MonoBehaviour {

	public bool pressed;

	// Use this for initialization
	void Start () {    
	}
	
	// Update is called once per frame
	public void Update () {
		if (!Input.GetMouseButton(0))
			pressed = false;
	}
	
	public void OnMouseDown()
	{
		pressed = true;
	}

	public void OnMouseUp()
	{
		pressed = false;
	}
	
	public void OnMouseEnter()
	{
		if (Input.GetMouseButton(0))
			pressed = true;
	}

	public void OnMouseExit()
	{
		pressed = false;
	}
}
