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

namespace POIApp
{
	public class POIData
	{
		public static readonly IPOIDataService Service = new
			POIJsonService(
				Path.Combine(
					Android.OS.Environment.ExternalStorageDirectory.Path,
					"POIApp"));
	}
}

