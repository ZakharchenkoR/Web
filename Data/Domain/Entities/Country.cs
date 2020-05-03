using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Country : BaseEntity
    {
        public static Country China = new Country { Id = new System.Guid("ef87c39b-2cc6-407e-b974-edbcf20781ad"), Name = "China" };
        public static Country USA = new Country { Id = new System.Guid("cc61583f-4ebd-4b68-8e41-b56822aec84e"), Name = "USA" };
        public static List<Country> ToList() => new List<Country> { China, USA };

        [Required]
        public override string Name { get; set; }
    }
}
