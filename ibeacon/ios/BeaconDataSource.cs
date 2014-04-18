using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Threading;
using MonoTouch.Foundation;

namespace Neudesic.iBeacon.Trilat
{
	public class BeaconDataSource : UITableViewSource
	{
		static readonly NSString cellIdentifier = new NSString ("Cell");
		List<Beacon> beacons = new List<Beacon>();
		public BeaconDataSource()
		{
		}
		public BeaconDataSource (List<Beacon> beacons)
		{
			Update (beacons);
		}

		public void Update(List<Beacon> beacons)
		{
			this.beacons = beacons;
		}

		public List<Beacon> Beacons {
			get {
				return this.beacons;
			}
		}

		// Customize the number of sections in the table view.
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return beacons.Count;
		}
		// Customize the appearance of table view cells.
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (UITableViewCell)tableView.DequeueReusableCell (cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);



			cell.TextLabel.Text = beacons [indexPath.Row].FriendlyName;
			float greyColor = ((float)beacons [indexPath.Row].Accuracy / 60.0f);
			UIColor textColor = new UIColor (greyColor, greyColor, greyColor, 1);
			cell.TextLabel.TextColor = textColor;

			cell.DetailTextLabel.Text = beacons [indexPath.Row].ProximityDescription;
			cell.DetailTextLabel.TextColor = textColor;

			//cell.Accessory = Application.DiscoveredBeacons.BeaconsInRange [indexPath.Row].CheckedIn ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			// Return false if you do not want the specified item to be editable.
			return false;
		}
	}
}

