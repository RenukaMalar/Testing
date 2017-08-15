using Newtonsoft.Json.Linq;
using PrestacapTask3.Interfaces;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace PrestacapTask3.Services
{
	public class HotelRatesServices : IHotelRatesServices
	{
		public dynamic GetHotelDetailsById(int hotelID)
		{
			var hotelRatesJsonFile = JArray.Parse(File.ReadAllText(ConfigurationManager.AppSettings["jsonFile"]));
			return hotelRatesJsonFile.OfType<dynamic>().FirstOrDefault(x => x.hotel.hotelID == hotelID);
		}

		public JArray GetHotelRatesByDate(string arrivalDate, dynamic hotelRates)
		{
			DateTime arrivalDateTime;
			if (DateTime.TryParse(arrivalDate, out arrivalDateTime))
			{
				var hotelRatesResult = new JArray();
				foreach (var hotelRate in hotelRates)
				{
					DateTime targetDateTime;

					if (DateTime.TryParse(Convert.ToString(hotelRate.targetDay), out targetDateTime) && targetDateTime.Date.Equals(arrivalDateTime.Date))
					{
						hotelRatesResult.Add(hotelRate);
					}
				}
				return hotelRatesResult;
			}

			return null;
		}
	}
}
