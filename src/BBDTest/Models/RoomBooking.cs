namespace BBDTest.Models
{
    public  class RoomBooking
    {
        public RoomBooking(int roomNo, int guestNumber, DateOnly checkInDate, DateOnly checkOutDate)
        {
            RoomNo = roomNo;
            GuestNo = guestNumber;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        //	| RoomNo | GuestNo  | CheckInDate	 | CheckOutDate |

        public int RoomNo { get; set; }
        public int GuestNo { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int GuestNumber { get; }
    }
}