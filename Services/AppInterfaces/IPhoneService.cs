using Data.Common;
using Data.Domain.Entities;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.AppInterfaces
{
    public interface IPhoneService
    {
        Task<PhoneModel> GetPhoneModelAsync(Guid modelId);
        Task<IList<PhoneModel>> GetPhoneModelsAsync(DataRequest<Model> request = null);
        Task<int> UpdatePhoneModelAsync(PhoneModel model);
        Task<int> DeletePhoneModelAsync(params PhoneModel[] models);
    }
}
