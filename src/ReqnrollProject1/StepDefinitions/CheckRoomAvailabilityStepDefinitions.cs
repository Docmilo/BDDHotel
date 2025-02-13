using System;
using System.Globalization;
using BBDTest.Models;
using BBDTest.Services;
using Reqnroll;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class CheckRoomAvailabilityStepDefinitions
    {
        // Setup some fields for the step definitions
        private readonly RoomSearchService _roomSearchService = new();
        private List<HotelRoom> _suitableRooms = new();
        private SearchCriteria _searchCriteria = new();

        private readonly ScenarioContext _scenarioContext;

        public CheckRoomAvailabilityStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the hotel has the following hotel rooms:")]
        public void GivenTheHotelHasTheFollowingHotelRooms(DataTable hotelRooms)
        {
            _suitableRooms.Clear();
            _roomSearchService.Rooms.Clear();
            // 	| RoomNo | Type   | MaxOccupancy | PricePerNight |
            var rooms = hotelRooms.CreateSet<(int roomNo, RoomType roomType, int maxOccupancy, decimal price)>();
            foreach (var room in rooms)
            {
                _roomSearchService.Rooms.Add(new HotelRoom(room.roomNo, room.roomType, room.maxOccupancy, room.price));
            }
        }

        [Given("the following bookings already exist:")]
        public void GivenTheFollowingBookingsAlreadyExist(DataTable roomBookings)
        {
            _roomSearchService.RoomBookings.Clear();
            var bookings = roomBookings.CreateSet<(int roomNo, int guestNumber, string checkInDate, string checkOutDate)>();
            foreach (var booking in bookings)
            {
                _roomSearchService.RoomBookings.Add(new RoomBooking(booking.roomNo, booking.guestNumber,
                    DateOnly.Parse(booking.checkInDate, new CultureInfo("en-GB")),
                    DateOnly.Parse(booking.checkOutDate, new CultureInfo("en-GB"))));
            }
        }

        [Given("the user specifies a checkIn date of {string}")]
        public void GivenTheUserSpecifiesACheckInDateOf(string checkInDate)
        {
            _searchCriteria.CheckInDate = DateOnly.Parse(checkInDate, new CultureInfo("en-GB"));
        }

        [Given("the user specifies a checkOut date of {string}")]
        public void GivenTheUserSpecifiesACheckOutDateOf(string checkOutDate)
        {
            _searchCriteria.CheckOutDate = DateOnly.Parse(checkOutDate, new CultureInfo("en-GB"));
        }

        [When("the user submits the search request")]
        public void WhenTheUserSubmitsTheSearchRequest()
        {
            //if (_checkOutDate <= _checkInDate)
            if (_searchCriteria.CheckOutDate <= _searchCriteria.CheckInDate)
            {
                _roomSearchService.EnableSearch = false;
            }
            else
            {
                _roomSearchService.EnableSearch = true;
                _roomSearchService.Search(_searchCriteria);
            }

        }

        [Then("the user should be informed that the available rooms are:")]
        public void ThenTheUserShouldBeInformedThatTheAvailableRoomsAre(DataTable availableRooms)
        {
            var rooms = availableRooms.CreateSet<(int roomNo, RoomType roomType, int maxOccupancy, decimal price)>();
            List<HotelRoom> expectedRooms = new();
            foreach (var room in rooms)
            {
                expectedRooms.Add(new HotelRoom(room.roomNo, room.roomType, room.maxOccupancy, room.price));
            }
            Assert.Equal(expectedRooms, _roomSearchService.Search(_searchCriteria));
         }

        [Then("the user should not be offered the following rooms:")]
        public void ThenTheUserShouldNotBeOfferedTheFollowingRooms(DataTable unAvailableRooms)
        {
            var rooms = unAvailableRooms.CreateSet<(int roomNo, RoomType roomType, int maxOccupancy, decimal price)>();
            List<HotelRoom> expectedRooms = new();
            foreach (var room in rooms)
            {
                expectedRooms.Add(new HotelRoom(room.roomNo, room.roomType, room.maxOccupancy, room.price));
            }
            Assert.Equal(expectedRooms, _roomSearchService.Search(_searchCriteria));
        }



    }
}
