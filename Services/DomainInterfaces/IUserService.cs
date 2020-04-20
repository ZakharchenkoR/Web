using Data.Domain.Entities;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DomainInterfaces
{
    public interface IUserService
    {
        Task<IList<ApplicationUserModel>> GetUsersAsync();
        Task<ApplicationUserModel> GetUserAsync(Guid id);
        Task<ApplicationUserModel> GetUserAsync(Data.Common.DataRequest<AppUser> request);
        Task<int> UpdateUserAsync(ApplicationUserModel entity);
        Task<int> DeleteUserAsync(ApplicationUserModel[] entities);
    }
}
