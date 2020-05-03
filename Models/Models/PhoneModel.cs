using System;

namespace Models.Models
{
    public class PhoneModel : BaseModel
    {
        public Guid ManufacturerId { get; set; }
        public ManufacturerModel ManufacturerModel { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
