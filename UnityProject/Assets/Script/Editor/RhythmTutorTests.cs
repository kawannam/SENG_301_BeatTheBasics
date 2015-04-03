using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

[TestFixture]
[Category("My Tests")]
internal class RhythmTutorTests
{
	[Test]
	[Category("Expected Outcome Test")]
	public void RhythmTutor_test()
	{
		GameObject t = Resources.Load<GameObject> ("Prefabs/Rhythm Object");
		RhythmTutor rhyTut = t.GetComponent<RhythmTutor> ();
		rhyTut.mapScore = new int[12];
		for (int counter = 0; counter < 12; counter++) {
			rhyTut.mapScore[counter] = 1;
		}
		rhyTut.SetDifficulty (Difficulty.Hard);
		int actual = rhyTut.NumWrong ();
		int expected = 0;
		Assert.AreEqual (actual, expected);
	}

}
