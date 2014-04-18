using System;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Collections;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;

namespace Neudesic.iBeacon.Trilat
{
	public class Networking
	{
		private static String IP_ADDRESS = "192.168.160.70";
		public Networking ()
		{
		}

		public static void SendEvent (List<Beacon> beacons)
		{
			var orderedBeaconsInSight = beacons.Where (b => (b.Proximity != CLProximity.Unknown)).OrderBy (b => b.Accuracy).ToList<Beacon> ();
			if (orderedBeaconsInSight.Count < 3)
				return; // 3 required for trilat

			String deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString ();

			String json = "{\"deviceId\":\""+deviceId+"\",\"beaconsInSight\" : [";
			for (int f=0; f<=2; f++){
				json += "{\"id\":\"" + orderedBeaconsInSight [f].FriendlyName + "\",\"range\":" + orderedBeaconsInSight [f].Accuracy + "}";
				json += (f == 2 ? "" : ",");
			}
			json += "]}";

			using (WebClient client = new WebClient ()) {
				client.Headers.Add ("Content-Type", "application/json");
				client.UploadStringTaskAsync ("http://" + IP_ADDRESS + ":9000/api/events", json);
			}
		
		}
	}
}

