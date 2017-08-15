using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrestacapTask3.Controllers;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrestacapTask3.Interfaces;
using System;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Newtonsoft.Json;
using System.ComponentModel;

namespace PrestacapTask3.Tests.Controllers
{
	[TestClass]
	public class HotelRatesControllerTest
	{
		private const int hotelID = 8759;
		private const string arrivalDate = "2016-03-15";

		private Mock<IHotelRatesServices> _hotelRatesServicesMock;

		[TestInitialize]
		public void TestInitialize()
		{
			_hotelRatesServicesMock = new Mock<IHotelRatesServices>();
		}

		[TestMethod]
		public void Get()
		{
			// Arrange
			_hotelRatesServicesMock.Setup(x => x.GetHotelDetailsById(hotelID));
			_hotelRatesServicesMock.Setup(x => x.GetHotelRatesByDate(It.IsAny<string>(), It.IsAny<object>()));
			var target = new HotelRatesController(_hotelRatesServicesMock.Object);

			// Act
			var result = target.Get(hotelID, arrivalDate);

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
