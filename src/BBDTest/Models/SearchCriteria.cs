namespace BBDTest.Models
{
    public class SearchCriteria
    {
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public RoomType DesiredRoomType { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
    }
}
