using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplayScript : MonoBehaviour {

	public Image[] starImages;
	public Sprite[] sourceSprites;
	public int numStars;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numStars; i++)
		{
			starImages[i].sprite = sourceSprites[1];
		}
	}
}
