using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDTest.Models;

namespace BBDTest.Services
{
    public class RoomSearchService
    {
        public bool EnableSearch { get; set;}
        public List<HotelRoom> Rooms { get; set; } = [];
        public List<RoomBooking> RoomBookings { get; set; } = [];

        public List<HotelRoom> Search(List<HotelRoom> hotelRooms, SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public List<HotelRoom> Search(SearchCriteria searchCriteria)
        {
            var unAvailableRooms = RoomBookings
                .GroupBy(b => b.RoomNo)
                .Where(g => !g.Any(b =>
                    (b.CheckInDate < searchCriteria.CheckOutDate && b.CheckOutDate > searchCriteria.CheckOutDate)
                    && (b.CheckOutDate > searchCriteria.CheckInDate && b.CheckInDate > searchCriteria.CheckInDate)))
                .Select(g => g.Key)
                .ToList();

            List<HotelRoom> availableRooms = Rooms.Where(obj => !unAvailableRooms.Contains(obj.RoomNumber)).ToList();
            
            return availableRooms;
            
        }

        public List<HotelRoom> SearchUnavailableRooms(SearchCriteria searchCriteria)
        {
            var availableRooms = RoomBookings
                .GroupBy(b => b.RoomNo)
                .Where(g => g.Any(b =>
                    (b.CheckInDate < searchCriteria.CheckOutDate && b.CheckOutDate > searchCriteria.CheckOutDate)
                    && (b.CheckOutDate > searchCriteria.CheckInDate && b.CheckInDate > searchCriteria.CheckInDate)))
                .Select(g => g.Key)
                .ToList();

            List<HotelRoom> unAvailableRooms = Rooms.Where(obj => !availableRooms.Contains(obj.RoomNumber)).ToList();

            return unAvailableRooms;

        }
    }
}
