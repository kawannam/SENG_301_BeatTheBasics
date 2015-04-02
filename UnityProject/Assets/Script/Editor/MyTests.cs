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
		GameObject t = Resources.Load<GameObject> ("Prefabs/PlayByEarScript");
		PlayByEarScript earObj = t.GetComponent<PlayByEarScript> ();

		GameObject g = Resources.Load<GameObject> ("Prefabs/GameModeScript");
		GameModeScript gms = g.GetComponent<GameModeScript> ();

		gms.SetDifficulty (Difficulty.Hard);
		earObj.Start ();
		int expected = 3;
		int actual = earObj.NUM_OF_NOTES;
		Assert.AreEqual (expected, actual);
	}

	[Test]
	[Category("Expected Outcome Test")]
	public void TestSBBlank()
	{
		for (int i =0; i < 9; i++) {
			
			StickerBookScript.GameProgress [i] = 0;
			GameObject t = Resources.Load<GameObject> ("Prefabs/StickerBookObject");
			StickerBookScript stickerObj = t.GetComponent<StickerBookScript> ();
			stickerObj.Update ();
			Color checkClr = new Color (0, 0, 0, 1);
			Color expected = checkClr;
			Color actual = stickerObj.StickerList [i].color;
			Assert.AreEqual (expected, actual);
		}
	}
	[Test]
	[Category("Expected Outcome Test")]
	public void TestSBFilledIn()
	{
		for (int i =0; i < 9; i++) {
			
			StickerBookScript.GameProgress [i] = 1;
			GameObject t = Resources.Load<GameObject> ("Prefabs/StickerBookObject");
			StickerBookScript stickerObj = t.GetComponent<StickerBookScript> ();
			stickerObj.Update ();
			Color checkFull = new Color (1, 1, 1, 1);
			Color expected = checkFull;
			Color actual = stickerObj.StickerList [i].color;
			Assert.AreEqual (expected, actual);
		}
	}
	//throw new Exception("");


}
