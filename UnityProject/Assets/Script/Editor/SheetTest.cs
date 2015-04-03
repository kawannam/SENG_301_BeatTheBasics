using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

[TestFixture]
[Category("My Tests")]
internal class SheetMusicNoteTest
{
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_Duration()
	{
		SheetMusicNote sheTest = new SheetMusicNote (NoteType.Whole, PianoKey.L_C);

		float expected = 1.0f;
		float actual = sheTest.Duration;
		Assert.AreEqual (expected, actual, "Duration is incorrect");
	}
}