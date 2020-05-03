using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Manufacturer : BaseEntity
    {
        public static Manufacturer Iphone = new Manufacturer { Id = new System.Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), Name = "Iphone" };
        public static Manufacturer Google = new Manufacturer { Id = new System.Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), Name = "Google" };
        public static Manufacturer Xiaomi = new Manufacturer { Id = new System.Guid("f639ccdd-39d5-40b5-98af-d07211f7b61a"), Name = "Xiaomi" };
        public static Manufacturer Huawei = new Manufacturer { Id = new System.Guid("1bea5a7c-03ca-40a4-aad4-7911b69b39fd"), Name = "Huawei" };
        public static Manufacturer Samsung = new Manufacturer { Id = new System.Guid("b12dabf7-4845-4788-b55e-b0d7e3d673fb"), Name = "Samsung" };
        public static List<Manufacturer> ToList() => new List<Manufacturer> { Iphone, Google, Xiaomi, Huawei, Samsung };

        [Required]
        [MaxLength(64)]
        public override string Name { get; set; }

        [Required]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
