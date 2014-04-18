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
using RadiusNetworks.IBeaconAndroid;

namespace aadiandroid
{
	public class BeaconCollection
	{
		private List<Beacon> beacons = new List<Beacon> ();

		public BeaconCollection ()
		{
		}

		public int Count {
			get {
				return beacons.Count;
			}
		}

		public bool Contains (int major, int minor)
		{
			return beacons.Any (b => (b.Major == major && b.Minor == minor));
		}

		public Beacon First {
			get {
				return BeaconsInRange.FirstOrDefault ();
			}
		}

		public void SetAllOutOfRange ()
		{
			for (int f = 0; f < beacons.Count; f++) {
				beacons [f].InRange = false;
			}
		}

		public List<Beacon> BeaconsInRange {
			get {
				return beacons.Where (b => (b.InRange == true && b.Proximity != ProximityType.Unknown)).OrderBy (b => b.Accuracy).ToList<Beacon> ();
			}
		}

		public void SetInRange (int major, int minor, bool inRange)
		{
			if (Contains (major, minor)) {
				beacons.FirstOrDefault (b => (b.Major == major && b.Minor == minor)).InRange = inRange;
			}
		}

		public void SetCheckedIn (int major, int minor, bool checkedIn)
		{
			if (Contains (major, minor)) {
				beacons.FirstOrDefault (b => (b.Major == major && b.Minor == minor)).CheckedIn = checkedIn;
			}
		}

		public void SetFriendlyName (int major, int minor, string friendlyName)
		{
			if (Contains (major, minor)) {
				beacons.FirstOrDefault (b => (b.Major == major && b.Minor == minor)).FriendlyName = friendlyName;
			}
		}

		public void Found (Beacon beacon)
		{
			if (!Contains (beacon.Major, beacon.Minor)) {
				beacons.Add (beacon);
			} else {
				beacons.FirstOrDefault (b => (b.Major == beacon.Major && b.Minor == beacon.Minor)).InRange = true;
				beacons.FirstOrDefault (b => (b.Major == beacon.Major && b.Minor == beacon.Minor)).Proximity = beacon.Proximity;
				beacons.FirstOrDefault (b => (b.Major == beacon.Major && b.Minor == beacon.Minor)).Accuracy = beacon.Accuracy;
			}
		}
	}
}

