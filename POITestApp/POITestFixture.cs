using System;
using NUnit.Framework;
using POIApp;
using System.IO;

namespace POITestApp
{
	[TestFixture]
	public class POITestFixture
	{
		IPOIDataService _poiService;

		[SetUp]
		public void Setup ()
		{
			string storagePath =
				Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			_poiService = new POIJsonService (storagePath);
			// clear any existing json files
			foreach (string filename in Directory.EnumerateFiles(storagePath,"*.json")) {
				File.Delete (filename);
			}
		}

		[TearDown]
		public void Tear ()
		{
		}

		[Test]
		public void CreatePOI()
		{
			PointOfInterest newPOI = new PointOfInterest ();
			newPOI.Name = "NEW POI";
			newPOI.Description = "POI to test creating a new POI";
			newPOI.Address = "100 Main Street";
			_poiService.SavePOI (newPOI);

			int testId = newPOI.Id.Value;

			// refresh the cache to be sure the data was
			// saved appropriately
			_poiService.RefreshCache ();

			// verify if the newly create POI exists
			PointOfInterest poi = _poiService.GetPOI (testId);
			Assert.NotNull (poi);
			Assert.AreEqual (poi.Name, "NEW POI");
		}

		[Test]
		public void UpdatePOI ()
		{
			PointOfInterest testPOI = new PointOfInterest ();
			testPOI.Name = "Update POI";
			testPOI.Description = "POI being saved so we can test update";
			testPOI.Address = "100 Main street";
			_poiService.SavePOI (testPOI);

			int testId = testPOI.Id.Value;

			// refresh the cache to be sure the data and
			// poi was saved appropriately
			_poiService.RefreshCache ();

			PointOfInterest poi = _poiService.GetPOI (testId);
			poi.Description = "Updated Description for Update POI";
			_poiService.SavePOI (poi);

			// refresh the cache to be sure the data was
			// updated appropriately
			_poiService.RefreshCache ();

			PointOfInterest ppoi = _poiService.GetPOI(testId);
			Assert.NotNull(ppoi);
			Assert.AreEqual (ppoi.Description, "Updated Description for Update POI");
		}

		string GetFilename (int? id)
		{
			throw new NotImplementedException ();
		}

		[Test]
		public void DeletePOI (PointOfInterest poi)
		{
			PointOfInterest testPOI = new PointOfInterest ();
			testPOI.Name = "Delete POI";
			testPOI.Description = "POI being saved so we can test delete";
			testPOI.Address = "100 Main Street\nAnywhere, TX 75069";
			_poiService.SavePOI (testPOI);
			int testId = testPOI.Id.Value;
			// refresh the cache to be sure the data and
			// poi was saved appropriately
			_poiService.RefreshCache ();
			PointOfInterest deletePOI = _poiService.GetPOI (testId);
			Assert.IsNotNull (deletePOI);
			_poiService.DeletePOI (deletePOI);
			// refresh the cache to be sure the data was
			// deleted appropriately
			_poiService.RefreshCache ();
			Assert.Null (poi);
		}
	
		[Test]
		public void Pass ()
		{
			Console.WriteLine ("test1");
			Assert.True (true);
		}

		[Test]
		public void Fail ()
		{
			Assert.False (true);
		}

		[Test]
		[Ignore ("another time")]
		public void Ignore ()
		{
			Assert.True (false);
		}

		[Test]
		public void Inconclusive ()
		{
			Assert.Inconclusive ("Inconclusive");
		}
	}
}

