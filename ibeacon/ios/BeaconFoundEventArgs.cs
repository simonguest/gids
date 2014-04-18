using System;
using System.Collections.Generic;

namespace Neudesic.iBeacon.Trilat
{
	public class BeaconFoundEventArgs : EventArgs
	{
		List<Beacon> beacons = new List<Beacon>();

		public BeaconFoundEventArgs (List<Beacon> beacons)
		{
			this.beacons = beacons;
		}

		public List<Beacon> Beacons {
			get {
				return beacons;
			}
		}
	}
}

