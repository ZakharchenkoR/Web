using Data.Common;
using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.ServiceInterfaces
{
    public interface IModelRepository
    {
        Task<Model> GetModelAsync(Guid modelId);
        Task<IList<Model>> GetModelsAsync(DataRequest<Model> request = null);
        Task<int> UpdateModelAsync(Model model);
        Task<int> DeleteModelAsync(params Model[] models);
    }
}
