using Newtonsoft.Json.Linq;

namespace PrestacapTask3.Interfaces
{
	public interface IHotelRatesServices
	{
		dynamic GetHotelDetailsById(int hotelID);

		JArray GetHotelRatesByDate(string arrivalDate, dynamic hotelRates);
	}
}
