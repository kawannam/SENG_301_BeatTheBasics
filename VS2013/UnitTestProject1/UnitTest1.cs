using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Keyboard_PressTest()
        {
            IKeyboardModel game = new KeyboardModel();
            game.InteractPianoKey(PianoKey.H_A, KeyState.Pressed);

            KeyState expected = KeyState.Pressed;
            KeyState actual = game.CurrKeyStates[(int)PianoKey.H_A];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Keyboard_ReleaseTest()
        {
            IKeyboardModel game = new KeyboardModel();
            game.CurrKeyStates[(int)PianoKey.H_A] = KeyState.Pressed;

            game.InteractPianoKey(PianoKey.H_A, KeyState.Released);

            KeyState expected = KeyState.Released;
            KeyState actual = game.CurrKeyStates[(int)PianoKey.H_A];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Keyboard_PlayNoteTest()
        {
            IKeyboardModel game = new KeyboardModel();
            game.InteractPianoKey(PianoKey.H_A, KeyState.Pressed);

            bool expected = true;
            bool actual = game.AudioSources[(int)PianoKey.H_A].IsPlaying;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Keyboard_StopNoteTest()
        {
            IKeyboardModel game = new KeyboardModel();
            game.AudioSources[(int)PianoKey.H_A].IsPlaying = true;
            game.InteractPianoKey(PianoKey.H_A, KeyState.Released);

            bool expected = false;
            bool actual = game.AudioSources[(int)PianoKey.H_A].IsPlaying;
            Assert.AreEqual(expected, actual);
        }
    }
}
