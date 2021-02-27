using System;
namespace Entities.DTOs
{
    public class CarRentalDetailDto : IDto
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
