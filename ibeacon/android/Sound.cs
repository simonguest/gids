using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

namespace aadiandroid
{
	public class Sound
	{
		public static void Play ()
		{
			try {
				Android.Net.Uri notification = RingtoneManager.GetDefaultUri (RingtoneType.Notification);
				Ringtone r = RingtoneManager.GetRingtone (Application.Context, notification);
				r.Play ();
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		
		}
	}
}
