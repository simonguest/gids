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
	public class MonitorEventArgs : EventArgs
	{
		public Region Region { get; set; }
		public int State { get; set; }
	}

	public class MonitorNotifier : Java.Lang.Object, IMonitorNotifier
	{
		public event EventHandler<MonitorEventArgs> DetermineStateForRegionComplete;
		public event EventHandler<MonitorEventArgs> EnterRegionComplete;
		public event EventHandler<MonitorEventArgs> ExitRegionComplete;

		public void DidDetermineStateForRegion(int p0, Region p1)
		{
			OnDetermineStateForRegionComplete();
		}

		public void DidEnterRegion(Region p0)
		{
			OnEnterRegionComplete();
		}

		public void DidExitRegion(Region p0)
		{
			OnExitRegionComplete();
		}

		private void OnDetermineStateForRegionComplete()
		{
			if (DetermineStateForRegionComplete != null)
			{
				DetermineStateForRegionComplete(this, new MonitorEventArgs());
			}
		}

		private void OnEnterRegionComplete()
		{
			if (EnterRegionComplete != null)
			{
				EnterRegionComplete(this, new MonitorEventArgs());
			}
		}

		private void OnExitRegionComplete()
		{
			if (ExitRegionComplete != null)
			{
				ExitRegionComplete(this, new MonitorEventArgs());
			}
		}
	}
}

