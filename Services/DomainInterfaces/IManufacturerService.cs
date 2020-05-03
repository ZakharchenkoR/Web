using Data.Common;
using Data.Domain.Entities;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DomainInterfaces
{
    public interface IManufacturerService
    {
        Task<ManufacturerModel> GetManufacturerAsync(Guid manufacturerId);
        Task<IList<ManufacturerModel>> GetManufacturersAsync(DataRequest<Manufacturer> request = null);
        Task<int> UpdateManufacturerAsync(ManufacturerModel model);
        Task<int> DeleteManufacturerAsync(params ManufacturerModel[] models);
    }
}
