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
	class BeaconDataAdapter : BaseAdapter<Beacon>
	{
		Activity context;

		public BeaconDataAdapter(Activity context) : base() {
			this.context = context;
		}

		public override long GetItemId (int position)
		{
			return position;
		}
		public override Beacon this[int index] {
			get {
				return MainApplication.DiscoveredBeacons.BeaconsInRange [index];
			}
		}
		public override int Count {
			get {
				return MainApplication.DiscoveredBeacons.BeaconsInRange.Count;
			}
		}
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem2, null);
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = MainApplication.DiscoveredBeacons.BeaconsInRange [position].FriendlyName;
			view.FindViewById<TextView> (Android.Resource.Id.Text2).Text = MainApplication.DiscoveredBeacons.BeaconsInRange [position].ProximityDescription;
			return view;
		}
	}
}

