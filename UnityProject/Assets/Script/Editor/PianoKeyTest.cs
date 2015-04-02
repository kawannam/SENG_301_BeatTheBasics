using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityTest;

[TestFixture]
[Category("My Tests")]
internal class PianoKeyTests
{
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_pressMouse()
	{
		PianoKeyScript pKey = new PianoKeyScript ();
		pKey.OnMouseDown ();
		bool expected = true;
		bool actual = pKey.pressed;
		Assert.AreEqual (expected, actual, "Key press was not registered");

	}
}