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

namespace aadiandroid
{
	//[Application(Debuggable =  true, Label = "Gartner AADI Demo", ManageSpaceActivity = typeof(MainActivity))]
	public class MainApplication 
	{
			public static BeaconCollection DiscoveredBeacons = new BeaconCollection();
	}
}

