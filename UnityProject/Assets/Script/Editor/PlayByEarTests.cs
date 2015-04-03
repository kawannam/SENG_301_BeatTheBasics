using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

[TestFixture]
[Category("My Tests")]
internal class GameTests
{
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_PBE_Difficulty()
	{
		GameObject testGame = Resources.Load<GameObject> ("Prefabs/PlayByEarObject");
		
		PlayByEarScript earObj = testGame.GetComponent<PlayByEarScript> ();
		GameObject pianoDef = Resources.Load<GameObject> ("Prefabs/PianoKeyboardPrefab");
		GameObject pianoObj = (GameObject)GameObject.Instantiate (pianoDef);

		earObj.SetDifficulty (Difficulty.Hard);
		earObj.Start ();
		int expected = 3;
		int actual = earObj.NUM_OF_NOTES;
		Assert.AreEqual (expected, actual);
		
		earObj.SetDifficulty (Difficulty.Medium);
		earObj.Start ();
		expected = 2;
		actual = earObj.NUM_OF_NOTES;
		Assert.AreEqual (expected, actual);
		
		earObj.SetDifficulty (Difficulty.Easy);
		earObj.Start ();
		expected = 1;
		actual = earObj.NUM_OF_NOTES;
		Assert.AreEqual (expected, actual);
	}
}
