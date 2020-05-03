using System;

namespace Models.Models
{
    public class PhoneModel : BaseModel
    {
        public Guid ManufacturerId { get; set; }
        public ManufacturerModel ManufacturerModel { get; set; }
        public decimal Prise { get; set; }
        public int Count { get; set; }
    }
}
