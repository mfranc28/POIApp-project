using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace POIApp
{
	[Activity (Label = "POIs", MainLauncher = true)]
	public class POIListActivity : Activity
	{
		ListView _poiListView;
		POIListViewAdapter _adapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.POIList);
			_poiListView = FindViewById<ListView>
				(Resource.Id.poiListView);
			_adapter = new POIListViewAdapter (this);
			_poiListView.Adapter = _adapter;


		}
	}
}


