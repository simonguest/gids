using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RadiusNetworks.IBeaconAndroid;
using System.Linq;

namespace aadiandroid
{
	[Activity (Label = "iBeacon Explorer", MainLauncher = true)]
	public class MainActivity : ListActivity, IBeaconConsumer
	{
		private readonly IBeaconManager iBeaconManager;
		private readonly MonitorNotifier monitorNotifier;
		private readonly RangeNotifier rangeNotifier;
		private readonly Region monitoringRegion;
		private readonly Region rangingRegion;
		private const string UUID = "e2c56db5dffb48d2b060d0f5a71096e0";
		private Beacon firstBeacon;

		public MainActivity ()
		{
			iBeaconManager = IBeaconManager.GetInstanceForApplication (this);
			monitorNotifier = new MonitorNotifier ();
			rangeNotifier = new RangeNotifier ();
			monitoringRegion = new Region ("r2MonitoringUniqueId", UUID, null, null);
			rangingRegion = new Region ("r2RangingUniqueId", UUID, null, null);

		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			iBeaconManager.Bind (this);
		}

		public void EnteredRegion (object sender, MonitorEventArgs e)
		{
			Console.WriteLine ("Entered region");
		}

		public void ExitedRegion (object sender, MonitorEventArgs e)
		{
			Console.WriteLine ("Exited region");
		}

		public void OnIBeaconServiceConnect ()
		{
			iBeaconManager.SetMonitorNotifier (monitorNotifier);
			iBeaconManager.SetRangeNotifier (rangeNotifier);
			iBeaconManager.StartMonitoringBeaconsInRegion (monitoringRegion);
			iBeaconManager.StartRangingBeaconsInRegion (rangingRegion);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			monitorNotifier.EnterRegionComplete += EnteredRegion;
			monitorNotifier.ExitRegionComplete += ExitedRegion;

			rangeNotifier.DidRangeBeaconsInRegionComplete += RangingBeaconsInRegion;
		}

		protected override void OnPause ()
		{
			base.OnPause ();

			monitorNotifier.EnterRegionComplete -= EnteredRegion;
			monitorNotifier.ExitRegionComplete -= ExitedRegion;

			rangeNotifier.DidRangeBeaconsInRegionComplete -= RangingBeaconsInRegion;
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			iBeaconManager.UnBind (this);
		}

		private void RangingBeaconsInRegion (object sender, RangeEventArgs e)
		{
			try {
				if (e.Beacons == null)
					return;

				MainApplication.DiscoveredBeacons.SetAllOutOfRange ();

				if (e.Beacons.Count > 0) {
					Console.WriteLine ("Found " + e.Beacons.Count + " beacons.");


					foreach (var beacon in e.Beacons) {
						if (beacon != null) {
							String id = beacon.Major + "." + beacon.Minor;
							String name = "Beacon: "+id;

							MainApplication.DiscoveredBeacons.Found (new Beacon () {Major = Int32.Parse (beacon.Major.ToString ()), 
								Minor = Int32.Parse (beacon.Minor.ToString ()), 
								FriendlyName = name, 
								Proximity = (ProximityType)beacon.Proximity, 
								Accuracy = beacon.Accuracy
							});
						}
					}

					// check to see whether the first beacon has changed
					if (firstBeacon == null) {
						firstBeacon = MainApplication.DiscoveredBeacons.First;
					}

					if (MainApplication.DiscoveredBeacons.First != null) {
						if (firstBeacon != MainApplication.DiscoveredBeacons.First) {
							// new beacon in first position
							firstBeacon = MainApplication.DiscoveredBeacons.First;
							Toast.MakeText(this, "Welcome to "+firstBeacon.FriendlyName, ToastLength.Short).Show();

							// perform a checkin
							MainApplication.DiscoveredBeacons.SetCheckedIn(firstBeacon.Major, firstBeacon.Minor, true);
							Sound.Play ();
						}
					}

				} else {
					Console.WriteLine ("No beacons found");
				}

				// Update the UI?
				ListAdapter = new BeaconDataAdapter (this);

			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}
		}
	}
}


