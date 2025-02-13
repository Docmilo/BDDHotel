using System;
using Reqnroll;
using BBDTest.Models;
using BBDTest.Services;
using System.Globalization;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class SearchForAHotelRoomStepDefinitions
    {

        // Setup some fields for the step definitions

        private readonly RoomSearchService _roomSearchService = new();
        private List<HotelRoom> _hotelRooms = new();
        private List<HotelRoom> _suitableRooms = new();
        private SearchCriteria _searchCriteria = new();
   

        [Given("the hotel has the following hotel rooms:")]
        public void GivenTheHotelHasTheFollowingHotelRooms(DataTable hotelRooms)
        {
            _suitableRooms.Clear();
            _hotelRooms.Clear();
            // 	| RoomNo | Type   | MaxOccupancy | PricePerNight |
            var rooms = hotelRooms.CreateSet<(int roomNo, RoomType roomType, int maxOccupancy, decimal price)>();
            foreach (var room in rooms)
            {
                _hotelRooms.Add(new HotelRoom(room.roomNo, room.roomType, room.maxOccupancy, room.price));
            }
        }

        [Given("a user wants to books a hotel room with a checkIn date of {string}")]
        public void GivenAUserWantsToBooksAHotelRoomWithACheckInDateOf(string checkInDate)
        {
            _searchCriteria.CheckInDate = DateOnly.Parse(checkInDate, new CultureInfo("en-GB"));
        }

        [Given("a checkOut date of {string}")]
        public void GivenACheckOutDateOf(string checkOutDate)
        {
            _searchCriteria.CheckOutDate = DateOnly.Parse(checkOutDate, new CultureInfo("en-GB"));
        }


        [Given("selects {int} adults")]
        public void GivenSelectsAdults(int numberAdults)
        {
            _searchCriteria.NumberAdults = numberAdults;
        }

        [Given("{int} child")]
        public void GivenChild(int numberChildren)
        {
            _searchCriteria.NumberChildren = numberChildren;
        }

        [When("the user searches for a hotel room")]
        public void WhenTheUserSearchesForAHotelRoom()
        {
            _suitableRooms = _roomSearchService.Search(_hotelRooms, _searchCriteria);    
        }

        [Then("the user should be informed that the available rooms are:")]
        public void ThenTheUserShouldBeInformedThatTheAvailableRoomsAre(DataTable actualRooms)
        {
            List<HotelRoom> availableRooms = new();
            var rooms  = actualRooms.CreateSet<(int roomNo, RoomType roomType, int maxOccupancy, decimal price)>();
            foreach (var room in rooms)
            {
                availableRooms.Add(new HotelRoom(room.roomNo, room.roomType, room.maxOccupancy, room.price));
            }

            Assert.Equal(_suitableRooms, availableRooms);
        }

    }
}
