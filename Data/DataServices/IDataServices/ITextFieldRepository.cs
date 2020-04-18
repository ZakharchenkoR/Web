using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.DataServices.IDataServices
{
    public interface ITextFieldRepository
    {
            Task<IList<TextField>> GetTextFieldsAsync();
            Task<TextField> GetTextFieldAsync(Guid id);
            Task<TextField> GetTextFieldAsync(string codeWord);
            Task<int> DeleteTextField(TextField[] entities);
    }
}
