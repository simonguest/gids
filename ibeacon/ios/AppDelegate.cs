using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Neudesic.iBeacon.Trilat
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public static BeaconRanger BeaconRanger;

		public override UIWindow Window {
			get;
			set;
		}
		public override void OnResignActivation (UIApplication application)
		{
			Console.WriteLine ("Application OnResignActivation");
		}
		public override void DidEnterBackground (UIApplication application)
		{
			Console.WriteLine ("Application DidEnterBackground");
		}
		public override void WillEnterForeground (UIApplication application)
		{
			Console.WriteLine ("Application WillEnterForeground");
		}
		public override void WillTerminate (UIApplication application)
		{
			Console.WriteLine ("Application WillTerminate");
		}
		public override bool FinishedLaunching (UIApplication application, NSDictionary options)
		{ 
			Console.WriteLine ("Application FinishedLaunching");
			BeaconRanger = new BeaconRanger ();
			BeaconRanger.StartListeningForBeacons ();
			return true;
		}

	}
}

