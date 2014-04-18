using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Neudesic.iBeacon.Trilat
{
	[Register ("DetailViewController")]
	public partial class DetailViewController : UIViewController
	{
		public Beacon SelectedBeacon;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		void ConfigureView()
		{
			if (IsViewLoaded && SelectedBeacon != null)
			{
				this.Title = SelectedBeacon.FriendlyName;
			}
		}

		public void SetBeacon (Beacon beacon)
		{
			this.SelectedBeacon = beacon;
			ConfigureView ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ConfigureView ();
		}
	}
}

