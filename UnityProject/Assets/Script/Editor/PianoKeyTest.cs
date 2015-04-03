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
	//Test pressed for Mouse press down method
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_pressMouse()
	{
		PianoKeyScript pKey = new PianoKeyScript ();
		pKey.OnMouseDown ();
		bool expected = true;
		bool actual = pKey.pressed;
		Assert.AreEqual (expected, actual, "Mouse press not registered");
	}

	//Test pressed for Mouse up method
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_pressMouse()
	{
		PianoKeyScript pKey = new PianoKeyScript ();
		pKey.OnMouseUp ();
		bool expected = false;
		bool actual = pKey.pressed;
		Assert.AreEqual (expected, actual, "Mouse up not registered");
	}

	//Test pressed for Mouse Enter method
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_pressMouse()
	{
		PianoKeyScript pKey = new PianoKeyScript ();
		pKey.OnMouseEnter ();
		bool expected = true;
		bool actual = pKey.pressed;
		Assert.AreEqual (expected, actual, "Mouse Enter not registered");
	}

	//Test pressed for Mouse exit method
	[Test]
	[Category("Expected Outcome Test")]
	public void Test_pressMouse()
	{
		PianoKeyScript pKey = new PianoKeyScript ();
		pKey.OnMouseExit ();
		bool expected = false;
		bool actual = pKey.pressed;
		Assert.AreEqual (expected, actual, "Mouse exit not registered");
	}
}