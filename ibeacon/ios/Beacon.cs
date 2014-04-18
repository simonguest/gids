using System;
using MonoTouch.CoreLocation;

namespace Neudesic.iBeacon.Trilat
{
	public class Beacon
	{
		public Beacon ()
		{
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
			get {
				return "Beacon " + Major.ToString () + "." + Minor.ToString ();
			}
		}

		public CLProximity Proximity {
			get;
			set;
		}

		public String ProximityDescription {
			get {
				String proximity = "";
				switch (Proximity) {
				case CLProximity.Immediate:
					proximity += "Immediate";
					break;
				case CLProximity.Near:
					proximity += "Near";
					break;
				case CLProximity.Far:
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
			
		public double Accuracy {
			get;
			set;
		}
	}
}

