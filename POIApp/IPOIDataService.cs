using System;
using System.Collections.Generic;

namespace POIApp
{
	public interface IPOIDataService
	{
		IReadOnlyList<PointOfInterest> POIs { get; }
		void RefreshCache();
		PointOfInterest GetPOI (int id);
		void SavePOI(PointOfInterest poi);
		void DeletePOI(PointOfInterest poi);
	
	}
}

