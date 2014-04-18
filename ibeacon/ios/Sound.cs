using System;
using MonoTouch.AudioToolbox;

namespace Neudesic.iBeacon.Trilat
{
	public class Sound
	{
		public Sound ()
		{
		}

		public static void Play()
		{
			SystemSound sound = SystemSound.FromFile ("Sounds/CrystalBell.aiff");
			sound.PlayAlertSound ();
		}
	}
}

