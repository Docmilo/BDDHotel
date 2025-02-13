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
        public List<HotelRoom> Rooms { get; set; } = new();
        public List<RoomBooking> RoomBookings { get; set; } = new();

        public List<HotelRoom> Search(List<HotelRoom> hotelRooms, SearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public List<HotelRoom> Search(SearchCriteria searchCriteria)
        {
            return new List<HotelRoom>();
            //throw new NotImplementedException();
        }
    }
}
