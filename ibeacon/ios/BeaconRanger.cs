using System;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace Neudesic.iBeacon.Trilat
{
	public class BeaconRanger
	{
		public EventHandler<BeaconFoundEventArgs> BeaconsFound = delegate {
		};
		private CLLocationManager locationManager;
		//private NSUuid broadcastUUID = new NSUuid ("E4C8A4FC-F68B-470D-959F-29382AF72CE7");
		private NSUuid beaconUUID = new NSUuid ("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0");
		private CLBeaconRegion beaconRegion;

		public BeaconRanger ()
		{
			this.BeaconsFound += DebugBeacons;
			this.BeaconsFound += SendBeacons;
		}

		public void StartListeningForBeacons ()
		{
			beaconRegion = new CLBeaconRegion (beaconUUID, "0");
			locationManager = new CLLocationManager ();

			locationManager.Failed += (object sender, NSErrorEventArgs e) => {
				Console.WriteLine ("Failure " + e.ToString ());
			};

			locationManager.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs args) => {
				List<Beacon> foundBeacons = new List<Beacon> ();

				foreach (CLBeacon clBeacon in args.Beacons) {
					foundBeacons.Add(new Beacon() { Major = clBeacon.Major.Int32Value, Minor = clBeacon.Minor.Int32Value, Proximity = clBeacon.Proximity, Accuracy = clBeacon.Accuracy });
				}
				this.BeaconsFound (this, new BeaconFoundEventArgs (foundBeacons));
			};
			locationManager.StartRangingBeacons (beaconRegion);
			locationManager.StartUpdatingLocation ();
		}

		public void DebugBeacons (object sender, BeaconFoundEventArgs e)
		{
			Console.WriteLine ("Beacons Found: " + e.Beacons.Count);
		}

		public void SendBeacons (object sender, BeaconFoundEventArgs e)
		{
			Networking.SendEvent (e.Beacons);
		}
	}
}

