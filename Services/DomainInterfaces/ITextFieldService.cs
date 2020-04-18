using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DomainInterfaces
{
    public interface ITextFieldService
    {
        Task<IList<TextFieldModel>> GetTextFieldsAsync();
        Task<TextFieldModel> GetTextFieldAsync(Guid id);
        Task<TextFieldModel> GetTextFieldAsync(string codeWord);
        Task<int> DeleteTextField(TextFieldModel[] entities);
    }
}
