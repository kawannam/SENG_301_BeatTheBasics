using UnityEngine;
using System.Collections;

public class ClickSoundScript : MonoBehaviour {
	
	public AudioSource source;

	void OnMouseDown(){

		Debug.Log ("Stuff");
		source.Play();
	}


	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
	
	}
}
