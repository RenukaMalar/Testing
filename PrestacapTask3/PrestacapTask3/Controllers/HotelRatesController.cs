using Newtonsoft.Json.Linq;
using PrestacapTask3.Interfaces;
using System.Web.Http;

namespace PrestacapTask3.Controllers
{
	public class HotelRatesController : ApiController
	{
		private readonly IHotelRatesServices _hotelRatesServices;

		public HotelRatesController(IHotelRatesServices hotelRatesServices)
		{
			_hotelRatesServices = hotelRatesServices;
		}

		// GET api/<controller>
		[HttpGet]
		public object Get(int hotelID, string arrivalDate)
		{
			dynamic result = new JObject();
			var hotelDetails = _hotelRatesServices.GetHotelDetailsById(hotelID);

			if (hotelDetails != null)
			{
				result.hotel = hotelDetails.hotel;
				result.hotelRates = _hotelRatesServices.GetHotelRatesByDate(arrivalDate, hotelDetails.hotelRates);
			}

			return result;
		}
	}
}