using System;

namespace Models.Models
{
    public class ManufacturerModel : BaseModel
    {
        public Guid CountryId { get; set; }
        public CountryModel CountryModel { get; set; }
    }
}
