using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using MonoTouch.CoreLocation;
using MonoTouch.AudioToolbox;

namespace Neudesic.iBeacon.Trilat
{
	public partial class MasterViewController : UITableViewController
	{
		BeaconDataSource dataSource;

		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("iBeacon Explorer", "iBeacon Explorer");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public void HandleBeaconsFound(object sender, BeaconFoundEventArgs e)
		{
			dataSource.Update (e.Beacons);
			TableView.ReloadData ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UIApplication.Notifications.ObserveDidBecomeActive ((sender, args) => {
				AppDelegate.BeaconRanger.BeaconsFound += HandleBeaconsFound;
			});
				
			UIApplication.Notifications.ObserveDidEnterBackground ((sender, args) => {
				AppDelegate.BeaconRanger.BeaconsFound -= HandleBeaconsFound;
			});

			UIActivityIndicatorView spinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
			spinner.Frame = new RectangleF (14, 5, 20, 20);
			spinner.StartAnimating ();
			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (spinner), true);

			TableView.Source = dataSource = new BeaconDataSource ();
		}
			
		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = dataSource.Beacons[indexPath.Row];
				((DetailViewController)segue.DestinationViewController).SetBeacon (item);
			}
		}
	}
}

