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
	public class Beacon
	{
		public Beacon ()
		{
		}

		public String GUID {
			get;
			set;
		}

		public int Minor {
			get;
			set;
		}

		public int Major {
			get;
			set;
		}

		public String FriendlyName {
			get;
			set;
		}

		public ProximityType Proximity {
			get;
			set;
		}

		public String ProximityDescription {
			get {
				String proximity = "";
				switch (Proximity) {
				case ProximityType.Immediate:
					proximity += "Immediate";
					break;
				case ProximityType.Near:
					proximity += "Near";
					break;
				case ProximityType.Far:
					proximity += "Far";
					break;
				default:
					proximity += "Unknown distance";
					break;
				}

				proximity += String.Format (" : +/- {0:F2}m", Accuracy);
				return proximity;
			}
		}

		public bool InRange {
			get;
			set;
		}

		public bool CheckedIn {
			get;
			set;
		}

		public double Accuracy {
			get;
			set;
		}
	}
}

