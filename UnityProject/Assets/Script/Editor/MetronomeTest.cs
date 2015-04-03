using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

[TestFixture]
[Category("My Tests")]
internal class MetronomeTests
{
	//Test initializing Metronome
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_initMetronome()
	{
		Metronome metObj = new Metronome ();
		metObj.Start ();

		int expected = 120;
		int actual = metObj.bpm;
		Assert.AreEqual (expected, actual, "Metronome BPM Failed to Initialize properly");
	}

	//Test setting BPM of Metronome
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_setBPM()
	{
		Metronome metObj = new Metronome ();
		metObj.Start ();
		metObj.SetBPM (50);

		int expected = 50;
		int actual = metObj.bpm;
		Assert.AreEqual (expected, actual, "Failed to set BPM");
	}

	//Test BPM range checking
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_minBPM()
	{
		Metronome metObj = new Metronome ();
		metObj.Start ();
		metObj.SetBPM (-1);
		
		int expected = 0;
		int actual = metObj.bpm;
		Assert.AreEqual (expected, actual, "Invalid BPM value");
	}

	//Test BPM range checking
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_maxBPM()
	{
		Metronome metObj = new Metronome ();
		metObj.Start ();
		metObj.SetBPM (260);
		
		int expected = 240;
		int actual = metObj.bpm;
		Assert.AreEqual (expected, actual, "Invalid BPM value");
	}
}