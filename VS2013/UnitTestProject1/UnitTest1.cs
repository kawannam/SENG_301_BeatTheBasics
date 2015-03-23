using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FreePlay_PressTest()
        {
            IGameModel game = new Keyboard();
            game.InteractPianoKey(PianoKey.H_A, KeyState.Pressed);

            KeyState expected = KeyState.Pressed;
            KeyState actual = game.CurrKeyStates[(int)PianoKey.H_A];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FreePlay_ReleaseTest()
        {
            IGameModel game = new Keyboard();
            game.CurrKeyStates[(int)PianoKey.H_A] = KeyState.Pressed;

            game.InteractPianoKey(PianoKey.H_A, KeyState.Released);

            KeyState expected = KeyState.Released;
            KeyState actual = game.CurrKeyStates[(int)PianoKey.H_A];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FreePlay_PlayNoteTest()
        {
            IGameModel game = new Keyboard();
            game.InteractPianoKey(PianoKey.H_A, KeyState.Pressed);

            bool expected = true;
            bool actual = game.AudioSources[(int)PianoKey.H_A].IsPlaying;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FreePlay_StopNoteTest()
        {
            IGameModel game = new Keyboard();
            game.AudioSources[(int)PianoKey.H_A].IsPlaying = true;
            game.InteractPianoKey(PianoKey.H_A, KeyState.Released);

            bool expected = false;
            bool actual = game.AudioSources[(int)PianoKey.H_A].IsPlaying;
            Assert.AreEqual(expected, actual);
        }
    }
}
