using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public enum MenuAction
    {
        Nav_Left,
        Nav_Right,
        Nav_Yes,
        Nav_No
    }

    public enum PianoKey
    {
        L_A,
        L_As,
        L_B,
        L_C,
        L_Cs,
        L_D,
        L_Ds,
        L_E,
        L_F,
        L_Fs,
        L_G,
        L_Gs,
        H_A,
        H_As,
        H_B,
        H_C,
        H_Cs,
        H_D,
        H_Ds,
        H_E,
        H_F,
        H_Fs,
        H_G,
        H_Gs,
        MAX
    }

    public enum KeyState
    {
        Released,
        Pressed
    }

    public class AudioClip
    {
        private string filePath;
        public string FilePath { get { return filePath; } }

        private float pitch;
        public float Pitch { get { return pitch; } }

        public AudioClip(string paramFilepath, float paramPitch)
        {
            filePath = paramFilepath;
            pitch = paramPitch;
        }
    }

    public class AudioSource
    {
        private AudioClip clip;

        public bool IsPlaying { get; set; }
        public bool IsLooping { get; set; }
        public float Position { get; set; }

        public AudioSource(AudioClip paramClip)
        {
            clip = paramClip;
        }
    }

}