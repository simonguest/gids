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
	public class RangeEventArgs : EventArgs
	{
		public Region Region { get; set; }
		public ICollection<IBeacon> Beacons { get; set; }
	}

	public class RangeNotifier : Java.Lang.Object, IRangeNotifier
	{
		public event EventHandler<RangeEventArgs> DidRangeBeaconsInRegionComplete;

		public void DidRangeBeaconsInRegion(ICollection<IBeacon> beacons, Region region)
		{
			OnDidRangeBeaconsInRegion(beacons, region);
		}

		private void OnDidRangeBeaconsInRegion(ICollection<IBeacon> beacons, Region region)
		{
			if (DidRangeBeaconsInRegionComplete != null)
			{
				DidRangeBeaconsInRegionComplete(this, new RangeEventArgs { Beacons = beacons, Region = region });
			}
		}
	}
}

