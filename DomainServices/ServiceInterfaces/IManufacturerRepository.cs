using Data.Common;
using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.ServiceInterfaces
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> GetManufacturerAsync(Guid manufacturerId);
        Task<IList<Manufacturer>> GetManufacturersAsync(DataRequest<Manufacturer> request = null);
        Task<int> UpdateManufacturerAsync(Manufacturer model);
        Task<int> DeleteManufacturerAsync(params Manufacturer[] models);
    }
}
