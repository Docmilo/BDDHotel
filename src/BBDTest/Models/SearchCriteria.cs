using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDTest.Models
{
    public class SearchCriteria
    {
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public RoomType DesiredRoomType { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
    }
}
